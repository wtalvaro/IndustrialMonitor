---
description: # Workflow: Debug ASP.NET Core (Linux/Arch)
---

## Objetivo
Configurar o `launch.json` e garantir que o `netcoredbg` esteja pronto para debugar o projeto atual.

## Contexto do Ambiente
- **Debugger:** `/usr/bin/netcoredbg`
- **SDK:** .NET 10.0
- **Runtime:** Microsoft.AspNetCore.App 10.0

## Passos do Agente
1. **Verificar Projeto:** Identificar o arquivo `.csproj` no diretório raiz.
2. **Validar Launch Config:** Verificar se o arquivo `.vscode/launch.json` existe. Se não, criar uma configuração do tipo `coreclr` apontando para o binário `/usr/bin/netcoredbg`.
3. **Build de Debug:** Executar `dotnet build` para garantir que os símbolos `.pdb` existam.
4. **Mapeamento de Source:** Garantir que o `sourceFileMap` no JSON esteja configurado para o path do container Distrobox.

## Comando de Execução Sugerido
"Agente, configure meu ambiente de debug para este projeto ASP.NET Core usando o netcoredbg do sistema."