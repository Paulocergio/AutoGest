🛠 AutoGest SaaS - Oficina Mecânica Inteligente
🎯 Sobre o Projeto
O AutoGest é um ecossistema SaaS Multi-tenant projetado para modernizar a gestão de oficinas mecânicas. Este projeto está sendo desenvolvido como uma plataforma de aprendizado intensivo, focada na aplicação de IA 100% autônoma e metodologias avançadas de engenharia de software.

O objetivo principal é dominar o ciclo de vida de um software complexo, garantindo isolamento de dados entre oficinas e uma arquitetura escalável.

🚀 Metodologia: SDD (Spec-Driven Development)
Diferente do desenvolvimento tradicional, este projeto utiliza o SDD. Isso significa que nenhuma linha de código é escrita sem antes ter uma especificação técnica rigorosa.

Por que SDD?
Aprendizado Guiado: A especificação atua como um contrato, forçando a compreensão das regras de negócio antes da implementação.

IA-First: O Claude Code utiliza as specs/ para gerar código preciso, eliminando alucinações e garantindo que o sistema siga os padrões de Clean Architecture.

Rastreabilidade: Cada funcionalidade nasce de uma Spec, gera tarefas no Jira e é documentada no Notion de forma automática via MCP (Model Context Protocol).

🛠 Stack Tecnológica
Backend: .NET 8 (C#) com Clean Architecture.

Banco de Dados: SQL Server com Entity Framework Core.

Frontend: React + Tailwind CSS.

Gestão: Jira (Backlog Automatizado).

Documentação: Notion (Wiki Técnica).

IA: Claude Code com MCP Servers (Atlassian & Notion).

🏗 Arquitetura do Sistema
O sistema segue os princípios da Clean Architecture, dividindo-se em:

Domain: Entidades de negócio e interfaces fundamentais.

Application: Casos de uso, DTOs e validações com FluentValidation.

Infrastructure: Persistência de dados, configurações do SQL Server e Migrations.

API: Pontos de extremidade RESTful e documentação Swagger.

Nota de Multi-tenancy: O sistema utiliza Global Query Filters para garantir que uma oficina nunca acesse os dados de outra, utilizando o campo TenantId em todas as transações.

🔄 Fluxo de Desenvolvimento
Escrita da Spec: Documentação em specs/*.md detalhando o comportamento desejado.

Sincronização MCP: O Claude lê a Spec e cria automaticamente os cards no quadro ConnectaSys no Jira.

Implementação Autônoma: O código é gerado seguindo a Spec, respeitando as "Regras de Ouro" do arquivo CLAUDE.md.

Registro de Lições: Documentação no Notion sobre os desafios e soluções encontradas no processo.
