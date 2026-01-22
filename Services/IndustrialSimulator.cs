using IndustrialMonitor.Data;
using IndustrialMonitor.Hubs;
using IndustrialMonitor.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace IndustrialMonitor.Services;

public class IndustrialSimulator(IServiceScopeFactory scopeFactory, ILogger<IndustrialSimulator> logger, IHubContext<IndustrialHub> hubContext) : BackgroundService
{
    private readonly string[] _momentos = ["Aquecimento", "Presurização", "Injeção", "Recalque", "Resfriamento", "Extração"];

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("Simulador Industrial iniciado.");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = scopeFactory.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var maquinas = await dbContext.Maquinas.ToListAsync(stoppingToken);

                foreach (var maquina in maquinas)
                {
                    SimularMaquina(maquina);
                }

                await dbContext.SaveChangesAsync(stoppingToken);

                // Notificar clientes via SignalR
                await hubContext.Clients.All.SendAsync("ReceiveUpdate", stoppingToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro no loop de simulação.");
            }

            await Task.Delay(TimeSpan.FromSeconds(2), stoppingToken);
        }
    }

    private void SimularMaquina(Maquina maquina)
    {
        maquina.UltimaComunicacao = DateTime.UtcNow;

        // Se estiver operando, simula o ciclo
        if (maquina.Status == StatusMaquina.Operando)
        {
            maquina.TempoFuncionamento = maquina.TempoFuncionamento.Add(TimeSpan.FromSeconds(2));
            maquina.ConsumoEnergia += Random.Shared.NextDouble() * 0.05;
            
            // Simular flutuação de temperatura e pressão baseada no momento
            AtualizarMetricaseMomento(maquina);
        }
        else if (maquina.Status == StatusMaquina.DesligamentoSolicitado)
        {
            ExecutarRotinaParada(maquina);
        }
        else if (maquina.Status == StatusMaquina.EmParadaTecnica)
        {
             // Continua a rotina de parada
             ExecutarRotinaParada(maquina);
        }
    }

    private void AtualizarMetricaseMomento(Maquina maquina)
    {
        // Encontra o índice atual para rotacionar
        int index = Array.IndexOf(_momentos, maquina.MomentoProcesso);
        if (index == -1 || Random.Shared.Next(0, 10) > 7) // 30% de chance de mudar de fase
        {
            index = (index + 1) % _momentos.Length;
            maquina.MomentoProcesso = _momentos[index];
        }

        // Ajusta métricas conforme o momento
        switch (maquina.MomentoProcesso)
        {
            case "Aquecimento":
                maquina.Temperatura = Math.Min(220, maquina.Temperatura + Random.Shared.NextDouble() * 2);
                maquina.Pressao = Math.Max(5, maquina.Pressao - 1);
                break;
            case "Injeção":
                maquina.Temperatura = 210 + Random.Shared.NextDouble() * 5;
                maquina.Pressao = Math.Min(150, maquina.Pressao + Random.Shared.NextDouble() * 20);
                break;
            case "Resfriamento":
                maquina.Temperatura = Math.Max(60, maquina.Temperatura - Random.Shared.NextDouble() * 3);
                maquina.Pressao = Math.Max(10, maquina.Pressao - 5);
                break;
            default:
                maquina.Temperatura += Random.Shared.NextDouble() - 0.5;
                maquina.Pressao += Random.Shared.NextDouble() * 2 - 1;
                break;
        }
    }

    private void ExecutarRotinaParada(Maquina maquina)
    {
        maquina.Status = StatusMaquina.EmParadaTecnica;
        
        // Simular resfriamento de segurança antes de desligar
        if (maquina.Temperatura > 40)
        {
            maquina.MomentoProcesso = "Resfriamento de Segurança";
            maquina.Temperatura -= 5;
            maquina.Pressao = Math.Max(0, maquina.Pressao - 10);
        }
        else
        {
            maquina.Status = StatusMaquina.Parada;
            maquina.MomentoProcesso = "Desligada";
            maquina.Temperatura = 25; // Ambiente
            maquina.Pressao = 0;
            maquina.MotivoDesligamento = "Rotina de parada concluída";
        }
    }
}
