# HospDevGroup - Contact Management System

Esta é uma API REST robusta desenvolvida em **.NET 8** para o gerenciamento de contatos hospitalares, focada em alta performance e separação de responsabilidades.

## 🏗️ Arquitetura (DDD Patterns)
A solução utiliza uma arquitetura desacoplada para garantir manutenibilidade:
- **HospDevGroup.Domain**: Regras de negócio, entidades e validações de maioridade.
- **HospDevGroup.API**: Endpoints REST e persistência com Entity Framework Core.
- **HospDevGroup.Tests**: Testes unitários para garantir a integridade dos dados.

## 🧠 Diferenciais Técnicos
- **Runtime Processing**: Cálculo de idade em tempo de execução sem persistência redundante.
- **Data Integrity**: Validações de domínio que impedem registros de menores de idade ou datas inconsistentes.
- **Global Query Filtering**: Implementação de filtro global para que contatos inativos sejam omitidos automaticamente em todas as consultas.

## 🚀 Execução e Testes
1. Atualize a ConnectionString no `appsettings.json`.
2. Execute as migrations: `dotnet ef database update`.
3. Rode o projeto: `dotnet run --project HospDevGroup.API`.
4. Testes: `dotnet test`.

## 🧪 Exemplos de Requisição (JSON)
**POST /api/contatos**
```json
{
  "nome": "João Victor Farias",
  "dataNascimento": "1996-05-15",
  "sexo": "M"
}