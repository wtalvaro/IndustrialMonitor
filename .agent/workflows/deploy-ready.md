---
description: # Workflow: Deploy & Publish Readiness
---

## Objetivo
Gerar builds otimizados e prontos para produção, garantindo que todas as dependências do .NET 10 estejam incluídas.

## Configurações de Publicação
- **Target Runtime:** `linux-x64`
- **Configuration:** `Release`
- **Optimization:** Self-contained (opcional) e ReadyToRun.

## Instruções para o Agente
1. **Sanity Check:** Executar `dotnet build` e verificar se não há warnings críticos.
2. **Execução do Publish:** - Comando: `dotnet publish -c Release -r linux-x64 --self-contained false`
3. **Verificação de Artefatos:** Listar os arquivos na pasta `bin/Release/net10.0/publish/` e confirmar a presença da DLL principal.
4. **Limpeza Pré-Build:** Oferecer para rodar `dotnet clean` antes de gerar o pacote final.

## Gatilhos
- "Agente, prepare o BRFrete para deploy em produção."
- "Gere um build de release otimizado para o Arch Linux."
- "Verifique se o projeto publica sem erros de dependência."