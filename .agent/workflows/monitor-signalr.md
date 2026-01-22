---
description: # Workflow: Monitoramento SignalR & Realtime
---

## Objetivo
Validar se o simulador está enviando mensagens via SignalR e se o client está recebendo.

## Instruções para o Agente
1. **Verificar Logs de Conexão:** Procurar por "HubConnection" e "Handshake" nos logs de console do .NET.
2. **Inspecionar Tráfego:** Sugerir o uso de ferramentas CLI como `curl` para testar o endpoint do Hub `/industrialhub`.
3. **Debug de Hub:** Se as máquinas não atualizarem, verificar se o `IHubContext` está disparando mensagens após o loop de 2 segundos.

## Gatilho
- "Agente, verifique se o SignalR está disparando as atualizações do simulador."