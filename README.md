# Industrial Monitor

Este é um projeto de monitoramento industrial desenvolvido como uma Blazor Web App. O sistema permite o monitoramento de máquinas, exibindo status, temperatura e data da última comunicação.

## Tecnologias Utilizadas

- **Platforma**: .NET 10
- **Framework Web**: ASP.NET Core Blazor (Interactive Server)
- **Banco de Dados**: PostgreSQL
- **ORM**: Entity Framework Core

## Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [PostgreSQL](https://www.postgresql.org/download/)

## Configuração

1. **Banco de Dados**: Certifique-se de que o PostgreSQL esteja rodando.
2. **Connection String**: Verifique o arquivo `appsettings.json` e ajuste a string de conexão `DefaultConnection` se necessário.
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Host=localhost;Database=IndustrialMonitor;Username=postgres;Password=sua_senha"
   }
   ```
3. **Migrações**: Aplique as migrações para criar o banco de dados.
   ```bash
   dotnet ef database update
   ```

## Executando o Projeto

### Via Linha de Comando
```bash
dotnet run
```
Acesse: `http://localhost:5081`

### Via VS Code
O projeto já está configurado para o VS Code.
1. Abra a aba "Run and Debug" (Ctrl+Shift+D).
2. Selecione a configuração **.NET Core Launch (web)**.
3. Pressione `F5`.

## Estrutura do Projeto

- **Models**: Contém as classes de domínio (ex: `Maquina`).
- **Data**: Contexto do banco de dados (`ApplicationDbContext`).
- **Components/Pages**: Páginas Blazor da aplicação.
