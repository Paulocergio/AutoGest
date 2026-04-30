# 🛠 AutoGest SaaS - Oficina Mecânica Inteligente

## 🎯 Sobre o Projeto
O **AutoGest** é um ecossistema **SaaS Multi-tenant** projetado para modernizar a gestão de oficinas mecânicas. Este projeto nasceu do desejo de dominar as tecnologias mais avançadas do mercado, unindo o desenvolvimento de software robusto com a eficiência da Inteligência Artificial.

Este projeto é uma jornada de aprendizado prático, onde cada funcionalidade é construída para garantir isolamento de dados entre diferentes oficinas e uma arquitetura de nível empresarial.

---

## 🚀 Metodologia: SDD (Spec-Driven Development)
O diferencial deste sistema é a aplicação do **Spec-Driven Development (SDD)**. Nenhuma linha de código é gerada por acaso. O fluxo segue um contrato técnico rigoroso:

1.  **OpenSpec:** Definição clara de requisitos e esquemas de dados em arquivos de especificação (`specs/`) antes da codificação.
2.  **IA 100% Autônoma:** Uso do **Claude Code** para interpretar as especificações e transformar requisitos em código funcional sem intervenção manual constante.
3.  **Sincronização via MCP (Model Context Protocol):**
    *   **Jira (ConnectaSys):** Criação automática de tarefas e acompanhamento de backlog diretamente da especificação.
    *   **Notion:** Registro automático do diário de bordo e documentação técnica para consulta futura.

---

## 🛠 Stack Tecnológica
*   **Backend:** .NET 8 (C#) utilizando Clean Architecture.
*   **Banco de Dados:** SQL Server com Entity Framework Core.
*   **Frontend:** React + Tailwind CSS.
*   **Ferramentas de IA:** Claude Code, MCP Servers e OpenSpec.
*   **Gestão e Docs:** Jira (Backlog) e Notion (Wiki).

---

## 🏗 Arquitetura & Regras de Ouro
O projeto segue os princípios de **Clean Architecture**, garantindo que o código seja testável e fácil de manter:

*   **Multi-tenancy:** Implementação de `TenantId` em todas as entidades para garantir que uma oficina nunca acesse os dados de outra.
*   **Segurança:** Uso de **BCrypt** para proteção de senhas e validações rigorosas com **FluentValidation**.
*   **Padrão de Código:** Código e variáveis em Inglês; tarefas e documentação em Português para agilidade no aprendizado.

---

## 👨‍💻 Desenvolvedor
**Paulo Cérgio de Almeida Costa Júnior**


---

## 📝 Como este projeto é desenvolvido
Para manter o aprendizado acelerado e o código limpo, utilizo o comando de aprovação automática da IA:
```bash
claude --auto-approve
