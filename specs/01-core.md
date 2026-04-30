# Spec 01: Base de Dados e Multi-tenancy

## Objetivo
Configurar o banco de dados inicial para suportar múltiplas oficinas.

## Schema Sugerido
- **Oficinas (Tenants):** Id, Nome, CNPJ, DataCriacao.
- **Usuarios:** Id, Nome, Email, SenhaHash, TenantId (FK).

## Tarefas para o Jira (ConnectaSys)
- [ ] Criar projeto Web API em .NET 8.
- [ ] Configurar Entity Framework Core com SQL Server.
- [ ] Gerar migration inicial para as tabelas de Tenant e Usuário.