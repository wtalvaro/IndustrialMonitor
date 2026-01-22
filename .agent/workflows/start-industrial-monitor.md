---
description: # Workflow: Run & Monitor IndustrialMonitor
---

## Objetivo
Executar o ciclo completo de build e execução da aplicação, garantindo que o BackgroundService e o SignalR subam corretamente no container Arch.

## Instruções para o Agente

### 1. Preparação (Pre-run)
Antes de rodar, o agente deve garantir que não há conflitos:
1. Executar o docker db-automacao
2. Executar `dotnet clean`.
3. Executar `dotnet build` e verificar se há erros de compilação.

### 2. Execução (Launch)
Executar o comando: `dotnet run --urls=http://0.0.0.0:5081` no terminal integrado.

### 3. Monitoramento de Logs (Watchdog)
O agente deve ler o output do console e procurar pelas seguintes confirmações:
- **Simulador:** "Simulador Industrial iniciado."
- **Servidor:** "Now listening on: http://localhost:5081"
- **SignalR:** Verificar se não há erros de registro do Hub `/industrialhub`.

### 4. Diagnóstico em Tempo Real
Se solicitado "como está o sistema?", o agente deve:
1. Mostrar as últimas 5 linhas do log de console.
2. Verificar se o processo `dotnet` está consumindo CPU (indicando que o simulador está em loop).

## Gatilhos (User Prompts)
- "Agente, rode o programa e monitore o simulador."
- "Iniciar aplicação IndustrialMonitor."
- "Reinstanciar tudo e rodar o build de novo."

## Script de Encerramento Sugerido
Ao parar a execução, o agente deve oferecer: "Deseja que eu limpe os recursos agora?" e executar `pkill -f IndustrialMonitor`.