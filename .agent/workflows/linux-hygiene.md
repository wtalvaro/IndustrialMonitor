---
description: # Workflow: Linux System Hygiene (Resource Management)
---

## Objetivo
Identificar e encerrar processos "zumbis" ou órfãos que continuam consumindo CPU/RAM após o fechamento do editor ou interrupção do debug.

## Alvos de Limpeza
- **Editores:** Processos `antigravity`, `code-oss`, `electron`.
- **LSPs:** `OmniSharp`, `jdtls` (Java), `Microsoft.CodeAnalysis.LanguageServer`.
- **Runtime:** Processos `dotnet` travados e o debugger `netcoredbg`.

## Instruções para o Agente
1. **Análise de Recursos:** Executar `top -b -n 1 | head -n 20` ou `ps aux --sort=-%cpu` para identificar ofensores.
2. **Limpeza Seletiva:** Se o usuário pedir para "limpar o sistema" ou "parar consumo alto":
   - Encerrar o debugger: `pkill -f netcoredbg`
   - Encerrar processos dotnet órfãos: `pkill -f 'dotnet exec'`
   - Se o Antigravity estiver fechado mas lento: `pkill -f antigravity`
3. **Relatório:** Informar ao usuário quanto de memória foi liberada após os comandos.

## Gatilhos
- "Agente, limpe os processos zumbis do .NET."
- "Por que meu computador está lento? Verifique o consumo do container."
- "Mate todos os processos do debugger que ficaram abertos."