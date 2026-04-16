# Atividade 70 - API com Boas Práticas de Código (DRY e KISS)

## Descrição da Atividade

Esta atividade demonstra a implementação de uma API REST em C# ASP.NET Core aplicando os princípios de boas práticas de código:

- **DRY (Don't Repeat Yourself)**: Evitar duplicação de código através de serviços reutilizáveis
- **KISS (Keep It Simple, Stupid)**: Manter a simplicidade e clareza no código

A API permite o cadastro de pessoas com validação de CPF, incluindo exemplos de violações e implementações corretas desses princípios.

## Tecnologias Utilizadas

- **C# .NET 9.0** - Linguagem e runtime
- **ASP.NET Core Web API** - Framework para APIs REST
- **Entity Framework Core 8.0.4** - ORM para acesso a dados
- **PostgreSQL** - Banco de dados relacional
- **Docker & Docker Compose** - Containerização do banco de dados
- **AutoMapper** - Mapeamento objeto-objeto

## Estrutura do Projeto

```
ApiBoasPraticas/
├── Controllers/           # Controladores da API
├── Data/                  # Contexto do banco e repositório
├── DTOs/                  # Objetos de transferência de dados
├── Models/                # Entidades do domínio
├── Services/              # Lógica de negócio (seguindo KISS)
├── Validacao/             # Serviços de validação (seguindo DRY)
├── Program.cs             # Configuração da aplicação
├── appsettings.json       # Configurações
├── docker-compose.yml     # Configuração do banco Docker
└── ApiBoasPraticas.http   # Arquivo de testes da API
```

## Como Executar

### Pré-requisitos

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)

### Passos para Execução

1. **Clonar/Entrar no diretório do projeto:**
   ```bash
   cd "70 - API - Boas práticas de código - Conceitos DRY e KISS/ApiBoasPraticas"
   ```

2. **Iniciar o banco de dados PostgreSQL com Docker:**
   ```bash
   docker-compose up -d
   ```

3. **Executar as migrações do Entity Framework:**
   ```bash
   dotnet ef database update
   ```

4. **Executar a aplicação:**
   ```bash
   dotnet run
   ```

5. **Testar a API:**
   - A API estará disponível em: `https://localhost:5001`
   - Use o arquivo `ApiBoasPraticas.http` no VS Code para testar os endpoints
   - Ou use ferramentas como Postman, Insomnia, etc.

## Endpoints da API

### Endpoints Principais (Boas Práticas)

- `GET /api/pessoas` - Listar todas as pessoas
- `GET /api/pessoas/{id}` - Obter pessoa por ID
- `POST /api/pessoas` - Criar nova pessoa (com validações DRY)
- `PUT /api/pessoas/{id}` - Atualizar pessoa
- `DELETE /api/pessoas/{id}` - Deletar pessoa

### Endpoints de Demonstração (Violações)

- `POST /api/pessoas/violacao/dry` - Exemplo violando DRY
- `POST /api/pessoas/violacao/kiss` - Exemplo violando KISS

## Exemplos de Uso

### Criar pessoa com CPF válido:
```json
POST /api/pessoas
{
  "nome": "Ana Costa",
  "cpf": "529.982.247-25",
  "dataNascimento": "1998-03-15"
}
```

### Resposta de erro (CPF inválido):
```json
{
  "type": "https://tools.ietf.org/html/rfc9110#section-15.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "Cpf": ["CPF inválido"]
  }
}
```

## Conceitos Demonstrados

### DRY (Don't Repeat Yourself)
- **Violação**: Código de validação de CPF duplicado em múltiplos locais
- **Correto**: Serviço `CpfValidator` reutilizável injetado via DI

### KISS (Keep It Simple, Stupid)
- **Violação**: Métodos complexos com múltiplas responsabilidades
- **Correto**: Serviços simples e focados em uma única responsabilidade

## Validações Implementadas

- **CPF**: Validação de formato e dígitos verificadores
- **Nome**: Comprimento mínimo e máximo
- **Data de Nascimento**: Não pode ser futura
- **CPF Duplicado**: Verificação de unicidade no banco

## Arquivos de Evidência

- `documentation.md` - Explicação detalhada dos conceitos DRY e KISS
- `guia-execucao-evidencias.md` - Guia completo de execução e evidências
- `ApiBoasPraticas.http` - Testes automatizados dos endpoints

## Limpeza

Para parar o banco de dados Docker:
```bash
docker-compose down
```

Para remover volumes (dados persistidos):
```bash
docker-compose down -v
```