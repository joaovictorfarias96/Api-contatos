MedgrupoContatoApi
Sistema de Gerenciamento de Contatos desenvolvido como parte de um processo seletivo técnico para Desenvolvedor .NET Core. O projeto foca em boas práticas de arquitetura, integridade de dados e conformidade com requisitos de negócio hospitalares.
🏗️ Arquitetura do Projeto
A solução foi estruturada seguindo princípios de Separation of Concerns (SoC) e Clean Code, dividida nos seguintes projetos:

Medgrupo.Domain: Camada de domínio contendo a entidade Contato, lógica de validação de maioridade e cálculos em tempo de execução.
Medgrupo.API: Camada de interface RESTful utilizando ASP.NET Core, Entity Framework Core e Injeção de Dependência.
Medgrupo.Tests: Suíte de testes unitários utilizando xUnit para garantir a qualidade das regras de negócio.
🧠 Regras de Negócio Implementadas
Conforme solicitado no edital, o sistema implementa:

Cálculo de Idade (1a): A idade é calculada dinamicamente no get da propriedade, não sendo persistida no banco de dados.
Validação de Maioridade (1b): O sistema impede o cadastro de menores de 18 anos.
Integridade de Dados (1c, 1d): Validações para impedir idade igual a zero ou datas de nascimento futuras.
Filtro de Ativos (*): Implementação de Global Query Filter no EF Core para garantir que apenas contatos ativos sejam retornados nas consultas.
🛠️ Tecnologias e Ferramentas
Framework: .NET 8
ORM: Entity Framework Core (Code First)
Banco de Dados: SQL Server
Testes: xUnit
Documentação & Testes de API: Postman
🚀 Como Executar e Testar
1. Preparação do Banco de Dados
Certifique-se de configurar a Connection String no appsettings.json e execute:

dotnet ef database update
2. Executando a API
dotnet run --project Medgrupo.API
3. Testando via Postman (Exemplos de JSON)
A API foi validada via Postman. Abaixo, exemplos para teste dos endpoints:

POST /api/contatos (Sucesso - Maior de 18 anos)

{

  "nome": "João Victor Farias",

  "dataNascimento": "1996-05-15",

  "sexo": "M"

}

POST /api/contatos (Erro - Menor de 18 anos)

{

  "nome": "Criança Teste",

  "dataNascimento": "2020-01-01",

  "sexo": "F"

}

O sistema retornará 400 Bad Request com a mensagem de erro correspondente.
4. Executando Testes Unitários
dotnet test



Projeto desenvolvido para fins de avaliação técnica.
