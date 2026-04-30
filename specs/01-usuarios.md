# SPEC-001: CRUD de Usuários e Autenticação
**Status:** Planejamento
**Contexto:** Gestão de acesso para o SaaS ConnectaSys.

## 1. Definição de Dados (SQL Server)
- **Tabela:** `Users`
- **Campos:**
  - `Id`: Guid (Primary Key)
  - `FullName`: String (150, Obrigatório)
  - `Email`: String (100, Único, Validação de Formato)
  - `PasswordHash`: String (Obrigatório)
  - `TenantId`: Guid (Foreign Key - Isolamento de dados)
  - `CreatedAt`: DateTime

## 2. Regras de Validação
- O e-mail deve ser um endereço válido.
- A senha deve ter no mínimo 8 caracteres, incluindo um número e um caractere especial.
- Não podem existir dois usuários com o mesmo e-mail no mesmo Tenant.

## 3. Tarefas para o Jira (MCP)
- [ ] [BACKEND] Criar Migration para tabela Users no SQL Server.
- [ ] [BACKEND] Implementar UserDTO e FluentValidation para cadastro.
- [ ] [BACKEND] Criar Endpoints de CRUD (GET, POST, PUT, DELETE) no ASP.NET Core.
- [ ] [FRONTEND] Criar formulário de cadastro de usuário com React e Tailwind.
- [ ] [SECURITY] Implementar Hash de senha usando BCrypt ou similar.