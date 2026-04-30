# 🛠 AutoGest SaaS - Protocolo de Engenharia AI-First

## 🎯 Visão Geral
Sistema de gestão para oficinas mecânicas em modelo **SaaS Multi-tenant**. O foco principal é o isolamento rigoroso de dados por oficina e automação total via IA utilizando Spec-Driven Development (SDD).

## 🤖 Modo Autônomo (Auto-Approve Settings)
- **Confirmação:** Não peça confirmação para criar diretórios ou arquivos definidos na Clean Architecture.
- **Terminal:** Pode executar comandos de build, instalação de pacotes NuGet/NPM e migrations de banco de dados automaticamente.
- **Segurança:** Caso encontre um erro crítico de compilação, pare e peça orientação antes de tentar corrigir em loop.
## 🏗 Stack Tecnológica (Padrão)
*   **Backend:** .NET 8 (C#) - Clean Architecture.
*   **Banco de Dados:** SQL Server (EF Core).
*   **Frontend:** React com Tailwind CSS.
*   **Gestão:** Jira (Backlog) e Notion (Documentação Técnica) via MCP.

## 📜 Regras de Ouro (Instruções para a IA)
*   **Multi-tenancy Rigoroso:** Toda entidade de negócio (Clientes, Veículos, OS) DEVE possuir um `TenantId` (Guid). Aplicar Global Query Filters no EF Core para evitar vazamento de dados.
*   **Segurança:** Implementar hash de senhas com **BCrypt**. Validação de dados via **FluentValidation** no Application Layer.
*   **Idioma:** Código-fonte, variáveis e banco de dados em **Inglês**. Tarefas no Jira e Wiki no Notion em **Português**.
*   **Padrão de Projeto:** Seguir Repository Pattern e injeção de dependência nativa do .NET.

## 🔄 Fluxo de Trabalho (Obrigatório)
1.  **Leitura de Spec:** Antes de qualquer ação, ler os requisitos em `specs/`.
2.  **Sincronização Jira (MCP):** Criar as Issues no projeto **ConnectaSys** antes de iniciar a escrita do código.
3.  **Implementação:** Codificar seguindo os padrões de Clean Architecture definidos.
4.  **Log de Entrega (MCP):** Ao concluir, atualizar a página de progresso no Notion com os detalhes técnicos e endpoints criados.

## 📁 Estrutura de Diretórios
*   `AutoGest.Domain/`: Entidades, interfaces de repositório e exceções de domínio.
*   `AutoGest.Application/`: DTOs, Mappers, Validations e Services/Use Cases.
*   `AutoGest.Infrastructure/`: DbContext, Migrations e implementação de Repositórios.
*   `AutoGest.API/`: Controllers, Middlewares e Program.cs.
*   `AutoGest.Web/`: Projeto React (Vite/Tailwind).

