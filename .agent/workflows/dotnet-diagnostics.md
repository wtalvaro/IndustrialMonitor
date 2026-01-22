---
description: # Workflow: Diagnóstico de Performance .NET
---

## Objetivo
Utilizar as ferramentas globais instaladas para analisar vazamentos de memória ou alto consumo de CPU.

## Ferramentas Disponíveis
- Counters: `~/.dotnet/tools/dotnet-counters`
- Dumps: `~/.dotnet/tools/dotnet-dump`
- Tracing: `~/.dotnet/tools/dotnet-trace`

## Passos do Agente
1. **Listar Processos:** Executar `dotnet-counters list` para identificar o PID da aplicação rodando.
2. **Monitorar:** Iniciar o monitoramento de métricas (GC, CPU, ThreadPool).
3. **Analisar:** Se solicitado, tirar um dump e sugerir onde pode estar o gargalo baseado nas métricas de memória coletadas.

## Gatilho
"Agente, monitore o consumo de recursos da minha aplicação .NET e me diga se há algo anormal no Garbage Collector."