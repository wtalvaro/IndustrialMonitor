---
description: # Workflow: Entity Framework Core Migrations (dotnet-ef 10)
---

## Objetivo
Automatizar a criação, aplicação e remoção de migrações do Entity Framework Core, garantindo que o banco de dados esteja sincronizado com o modelo C#.

## Ferramentas de Contexto
- **CLI:** `dotnet ef` (Localizado em ~/.dotnet/tools)
- **SDK:** .NET 10.0
- **Projetos Alvo:** Projetos ASP.NET Core (.csproj)

## Instruções para o Agente

### 1. Criar Nova Migração
Quando o usuário solicitar "criar migração" ou "sincronizar modelo":
1. **Identificar o DbContext:** Procurar por classes que herdam de `DbContext`.
2. **Gerar Nome:** Se o usuário não fornecer um nome, sugira um baseado nas classes alteradas (ex: `AddFreightTable`, `UpdateUserSchema`).
3. **Comando:** Executar `dotnet ef migrations add [Nome] --project [Caminho-do-Projeto]`.

### 2. Atualizar Banco de Dados
Quando solicitado "atualizar banco" ou "aplicar alterações":
1. **Comando:** Executar `dotnet ef database update --project [Caminho-do-Projeto]`.
2. **Validação:** Verificar se a saída do comando indica sucesso. Se houver erro de conexão, verificar se o serviço de banco de dados (ex: SQL Server/Postgres) está rodando no container ou host.

### 3. Diagnóstico e Histórico
Quando solicitado "status do banco":
1. **Comando:** `dotnet ef migrations list` para mostrar o que já foi aplicado.
2. **Comando:** `dotnet ef dbContext info` para mostrar os detalhes da conexão atual.

## Regras de Segurança
- Sempre executar `dotnet build` antes de tentar uma migração para garantir que não há erros de sintaxe.
- Se houver falha na aplicação, sugerir o comando `dotnet ef migrations remove` para limpar a migração pendente que falhou.

## Exemplos de Gatilhos (User Prompts)
- "Agente, crie uma migração chamada 'InitialCreate' para o BRFrete."
- "Sincronize meu banco de dados com as últimas mudanças nas Models."
- "Quais migrações ainda não foram aplicadas?"