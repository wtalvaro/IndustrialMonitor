---
description: # Workflow: Stop & Cleanup IndustrialMonitor
---

"Agente, encerre a execução do IndustrialMonitor seguindo este protocolo de segurança para não travar:

Tente primeiro o comando pkill -15 -f IndustrialMonitor (SIGTERM) para um fechamento limpo.

Aguarde 3 segundos para o BackgroundService processar a parada.

Se o processo ainda aparecer no ps aux, use o pkill -9 -f IndustrialMonitor.

Por fim, limpe apenas os processos dotnet órfãos, mas não toque nos processos que contenham 'antigravity' no nome para evitar que você mesmo quebre."