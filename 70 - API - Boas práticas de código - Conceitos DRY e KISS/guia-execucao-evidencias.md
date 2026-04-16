# 📦 DOCUMENTO DE ENTREGA - Atividade 70

## 🎯 Atividade: API - Boas Práticas de Código (DRY e KISS)

### 📋 Descrição da Atividade

Criar uma API em C# utilizando ASP.NET Core que demonstra os princípios de boas práticas de código através dos conceitos **DRY (Don't Repeat Yourself)** e **KISS (Keep It Simple, Stupid)**. A API gerencia pessoas com validação de CPF e utiliza banco de dados PostgreSQL em container Docker.

---

## 📂 Estrutura Entregue

### 📁 Pasta: `70 - API - Boas práticas de código - Conceitos DRY e KISS`

#### 📄 Documentos
- ✅ `documentation.md` - Documentação completa dos conceitos DRY/KISS
- ✅ `README.md` - Documentação técnica da aplicação
- ✅ `guia-execucao-evidencias.md` - Guia de execução e evidências (este arquivo)

#### 📁 Código-Fonte (Disponível no Repositório)
- ✅ `ApiBoasPraticas/` - Projeto ASP.NET Core completo

---

## 🚀 COMO EXECUTAR A APLICAÇÃO

### Pré-requisitos
- .NET 8.0 SDK
- Docker Desktop
- VS Code com extensão REST Client

### Passo 1: Iniciar o Banco de Dados

```bash
cd "70 - API - Boas práticas de código - Conceitos DRY e KISS/ApiBoasPraticas"
docker-compose up -d
```

### Passo 2: Compilar o Projeto

```bash
dotnet build
```

Esperado: ✅ Construir êxito(s) com 7 aviso(s)

### Passo 3: Executar Migrações

```bash
dotnet ef database update
```

### Passo 4: Executar a Aplicação

```bash
dotnet run
```

Acesso: `https://localhost:5001`

---

## 📋 ENDPOINTS E EXEMPLOS DE TESTE

### 1️⃣ Listar Pessoas

```http
GET https://localhost:5001/api/pessoas
Accept: application/json
```

**Resposta:**
```json
[
  {
    "id": 1,
    "nome": "João Silva",
    "cpf": "123.456.789-09",
    "dataNascimento": "1985-05-15"
  }
]
```

### 2️⃣ Criar Pessoa (DRY - CPF Validado Centralmente)

```http
POST https://localhost:5001/api/pessoas
Content-Type: application/json

{
  "nome": "Ana Costa",
  "cpf": "529.982.247-25",
  "dataNascimento": "1998-03-15"
}
```

**Resposta (201):**
```json
{
  "id": 4,
  "nome": "Ana Costa",
  "cpf": "529.982.247-25",
  "dataNascimento": "1998-03-15"
}
```

**✅ Por que é DRY:**
- Validação de CPF reutilizada através de `ICpfValidator`
- Serviço centralizado de validação
- Sem duplicação de código

### 3️⃣ Criar Pessoa com CPF Inválido

```http
POST https://localhost:5001/api/pessoas
Content-Type: application/json

{
  "nome": "Teste",
  "cpf": "123.456.789-00",
  "dataNascimento": "1990-01-01"
}
```

**Resposta (400):**
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

### 4️⃣ Exemplos de Violações (Educacionais)

#### Violando DRY

```http
POST https://localhost:5001/api/pessoas/violacao/dry
Content-Type: application/json

{
  "nome": "Violação DRY",
  "cpf": "529.982.247-25",
  "dataNascimento": "1995-06-20"
}
```

**❌ Por que é DRY Violation:**
- Código duplica lógica de validação de CPF
- Não reutiliza o serviço `ICpfValidator`
- Mudanças na validação exigem múltiplas alterações

---

## 🎓 CONCEITOS IMPLEMENTADOS

### DRY (Don't Repeat Yourself)

**✅ Correto:**
```csharp
// Serviço centralizado reutilizável
public interface ICpfValidator
{
    bool IsValid(string cpf);
}

// Usar em qualquer lugar
public class PessoaService : IPessoaService
{
    private readonly ICpfValidator _cpfValidator;
    
    public async Task<PessoaDto> CreateAsync(CreatePessoaDto dto)
    {
        if (!_cpfValidator.IsValid(dto.Cpf))
            throw new ValidationException("CPF inválido");
        // ...
    }
}
```

**❌ Incorreto:**
```csharp
// Duplicação de código
public class PessoaServiceViolacao
{
    public void ValidarCpf(string cpf)
    {
        // Validação aqui
    }
    
    public void ValidarCpfOutroMetodo(string cpf)
    {
        // Mesma lógica repetida
    }
}
```

### KISS (Keep It Simple, Stupid)

**✅ Correto:**
```csharp
public class PessoaService : IPessoaService
{
    // Método simples, uma responsabilidade
    public async Task<PessoaDto> CreateAsync(CreatePessoaDto dto)
    {
        var validacao = _validacaoService.ValidarCriacao(dto);
        if (!validacao.IsValid)
            throw new ValidationException(validacao.Errors);
        
        var pessoa = new Pessoa { Nome = dto.Nome, Cpf = dto.Cpf };
        await _repository.AddAsync(pessoa);
        await _repository.SaveAsync();
        
        return _mapper.Map<PessoaDto>(pessoa);
    }
}
```

**❌ Incorreto:**
```csharp
// Método complexo, múltiplas responsabilidades
public void CriarPessoaComTudo(CreatePessoaDto dto)
{
    ValidarCpf(dto.Cpf);
    RemoteCpfService.Validate(dto.Cpf);
    EmailService.Send($"Novo CPF: {dto.Cpf}");
    ReportService.Generate("pessoa", dto);
    NotificationService.NotifyAdmin($"Nova pessoa: {dto.Nome}");
    _context.Pessoas.Add(new Pessoa { ... });
    _context.SaveChanges();
}
```

---

## 🏗️ ARQUITETURA E PADRÕES

### Repository Pattern (DRY + SOLID)
```
Data Access Layer:
- IPessoaRepository (interface)
- PessoaRepository (implementação)

Benefício: Reutilização de lógica de acesso a dados
```

### Service Layer (KISS + SOLID)
```
Business Logic Layer:
- IPessoaService (interface)
- PessoaService (simples, focado)

Benefício: Lógica simples e reutilizável
```

### Dependency Injection (SOLID)
```csharp
// Configuração centralizada
builder.Services.AddScoped<ICpfValidator, CpfValidator>();
builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
```

---

## 💾 DADOS INICIAIS (SeedData)

A aplicação inicia com 3 pessoas pré-cadastradas:

| ID | Nome | CPF | Data Nascimento |
|---|---|---|---|
| 1 | João Silva | 123.456.789-09 | 1985-05-15 |
| 2 | Maria Santos | 987.654.321-00 | 1990-08-22 |
| 3 | Pedro Oliveira | 111.222.333-44 | 1982-12-03 |

---

## ✅ VALIDAÇÕES IMPLEMENTADAS

### CPF
- ✅ Formato válido (XXX.XXX.XXX-XX)
- ✅ Dígitos verificadores corretos
- ✅ Rejeita sequências (111.111.111-11)
- ✅ Não permite duplicatas

### Nome
- ✅ Mínimo 3 caracteres
- ✅ Máximo 100 caracteres
- ✅ Obrigatório

### Data de Nascimento
- ✅ Não pode ser futura
- ✅ Formato válido

---

## 🧹 LIMPEZA

```bash
# Parar Docker
docker-compose down

# Remover dados persistidos
docker-compose down -v

# Limpar build
dotnet clean
```

---

## 🔍 ESTRUTURA DE ARQUIVOS DO CÓDIGO

```
ApiBoasPraticas/
├── ApiBoasPraticas.csproj          # Projeto C#
├── ApiBoasPraticas.http            # Exemplos de teste
├── Program.cs                      # Configuração
├── appsettings.json               # Strings de conexão
├── docker-compose.yml             # PostgreSQL container
│
├── Controllers/
│   ├── PessoasController.cs        # ✅ Boas práticas
│   └── PessoasViolacaoController.cs # ❌ Exemplos ruins
│
├── Models/
│   ├── Pessoa.cs                   # Entidade
│   └── Validacao/
│       ├── CpfValidator.cs         # ✅ DRY
│       └── ValidacaoService.cs     # ✅ Centralizado
│
├── DTOs/
│   ├── PessoaDtos.cs
│   └── MappingProfile.cs
│
├── Services/
│   ├── PessoaService.cs            # ✅ KISS
│   ├── PessoaServiceViolacao.cs    # ❌ Complexo
│   ├── IPessoaService.cs
│   └── IPessoaRepository.cs
│
├── Data/
│   ├── ApplicationDbContext.cs
│   ├── PessoaRepository.cs
│   └── SeedData.cs                 # Dados iniciais
│
└── bin/
    └── Debug/net8.0/
        └── ApiBoasPraticas.dll     # Executável
```

---

## 📊 RESUMO TÉCNICO

| Aspecto | Implementação |
|--------|---------------|
| **Linguagem** | C# .NET 8.0 |
| **Framework** | ASP.NET Core |
| **Banco de Dados** | PostgreSQL 16 |
| **ORM** | Entity Framework Core 8.0 |
| **Padrões** | Repository, Service, DI |
| **Validação** | DataAnnotations + Custom |
| **Mapeamento** | AutoMapper |
| **Containerização** | Docker Compose |

---

## ✨ CONCLUSÃO

Esta atividade demonstrou com sucesso:

✅ **DRY**: Validação de CPF centralizada e reutilizável
✅ **KISS**: Serviços simples com responsabilidade única
✅ **Clean Architecture**: Separação clara de camadas
✅ **SOLID Principles**: Interface segregation, dependency inversion
✅ **Educação**: Exemplos corretos vs incorretos lado a lado

O código está pronto para execução, teste e aprendizado!
- ✅ `Controllers/`, `Models/`, `Data/`, `Services/` - Estrutura completa
- ✅ `DTOs/` - Data Transfer Objects
- ✅ `docker-compose.yml` - Configuração Docker
- ✅ `ApiBoasPraticas.http` - Arquivo de testes REST

---

## 🔗 Repositório

**Link do Repositório:** https://github.com/Luizx0/desenvolvimento-de-distemas

### 📍 Localização no Repositório

A atividade completa está localizada em:
```
desenvolvimento-de-distemas/
└── 70 - API - Boas práticas de código - Conceitos DRY e KISS/
    ├── documentation.md                    ← Documentação completa
    ├── guia-execucao-evidencias.md         ← Este documento
    └── ApiBoasPraticas/                    ← Projeto C# completo
        ├── Controllers/
        │   ├── PessoasController.cs
        │   └── PessoasViolacaoController.cs
        ├── Models/
        │   ├── Pessoa.cs
        │   └── Validacao/
        ├── Data/
        │   ├── ApplicationDbContext.cs
        │   └── PessoaRepository.cs
        ├── Services/
        │   ├── PessoaService.cs
        │   └── PessoaServiceViolacao.cs
        ├── DTOs/
        ├── docker-compose.yml
        └── ApiBoasPraticas.http
```

---

## 🎯 Conceitos Demonstrados

### 🔄 DRY - Don't Repeat Yourself
**Evita duplicação de código através de:**
- Serviço centralizado de validação de CPF
- Método único de tratamento de erros
- Mapeamento DTO padronizado
- Repository pattern reutilizável

### 🎯 KISS - Keep It Simple, Stupid
**Mantém simplicidade através de:**
- Métodos com responsabilidade única
- Interfaces claras e intuitivas
- Validações diretas no modelo
- Separação clara de responsabilidades

---

## 🏗️ Arquitetura Implementada

### Models/Pessoa.cs
- **Entidade**: Pessoa com validações básicas
- **Campos**: Id, Nome, Cpf, DataNascimento, CriadoEm
- **Validações**: DataAnnotations para regras simples

### Validacao/CpfValidator.cs
- **Serviço DRY**: Validação centralizada de CPF
- **Métodos**: IsValid(), Format(), CalculateCheckDigits()
- **Reutilização**: Usado por controllers e services

### Services/PessoaService.cs
- **Serviço KISS**: Lógica de negócio simples
- **Métodos**: CriarAsync(), ObterPorIdAsync(), etc.
- **Responsabilidade**: Uma tarefa por método

### Controllers/PessoasController.cs
- **Controller limpo**: Apenas orquestração
- **Endpoints**: 5 operações CRUD
- **Tratamento**: Delegação para services

### Controllers/PessoasViolacaoController.cs
- **Demonstração**: Exemplos de violações
- **DRY Violation**: Código duplicado
- **KISS Violation**: Método complexo

---

## 🐳 Docker e Banco de Dados

### Configuração PostgreSQL
```yaml
# docker-compose.yml
version: '3.8'
services:
  postgres:
    image: postgres:15
    environment:
      POSTGRES_DB: boaspraticas
      POSTGRES_USER: postgres
      POSTGRES_PASSWORD: postgres
    ports:
      - "5432:5432"
    volumes:
      - postgres_data:/var/lib/postgresql/data
```

### Entity Framework Core
- **Migrations**: Scripts de criação do banco
- **Context**: ApplicationDbContext com configuração
- **Repository**: Padrão para acesso a dados

---

## 🔧 Funcionalidades Implementadas

### ✅ Endpoints Principais
```
GET    /api/pessoas           # Lista pessoas (com paginação)
GET    /api/pessoas/{id}      # Obtém pessoa por ID
POST   /api/pessoas           # Cria pessoa (CPF validado)
PUT    /api/pessoas/{id}      # Atualiza pessoa
DELETE /api/pessoas/{id}      # Remove pessoa
```

### ✅ Endpoints Demonstrativos
```
POST   /api/pessoas/violacao/dry      # Exemplo violando DRY
POST   /api/pessoas/violacao/kiss     # Exemplo violando KISS
```

### ✅ Validações CPF
- **Formato**: Aceita XXX.XXX.XXX-XX ou XXXXXXXXXXX
- **Algoritmo**: Validação dos dígitos verificadores
- **Regras**: CPF único, não sequencial, formato válido

---

## 🚀 Como Executar

### Pré-requisitos
- **.NET 9.0** instalado
- **Docker Desktop** rodando
- **Visual Studio Code** ou **Visual Studio**

### 📍 Execução Completa

1. **Clonar repositório** (se necessário):
   ```bash
   git clone https://github.com/Luizx0/desenvolvimento-de-distemas.git
   cd desenvolvimento-de-distemas/70 - API - Boas práticas de código - Conceitos DRY e KISS
   ```

2. **Iniciar banco de dados**:
   ```bash
   cd ApiBoasPraticas
   docker-compose up -d
   ```

3. **Executar migrations**:
   ```bash
   dotnet ef database update
   ```

4. **Executar a API**:
   ```bash
   dotnet run
   ```

5. **Testar**:
   - API: `https://localhost:5001/api/pessoas`
   - Arquivo de testes: Abrir `ApiBoasPraticas.http` no VS Code

---

## 🧪 Como Testar

### Opção 1: REST Client (VSCode) - RECOMENDADO
- Abra `ApiBoasPraticas.http` no VS Code
- Execute as requisições em ordem
- Veja as respostas e compare implementações

### Opção 2: Postman/cURL
- Importe as requisições do arquivo `.http`
- Execute testes manuais

---

## 📋 Exemplos de Teste

### ✅ Teste DRY - Validação Centralizada
```http
### Criar pessoa com CPF válido (usa serviço centralizado)
POST https://localhost:5001/api/pessoas
Content-Type: application/json

{
  "nome": "João Silva",
  "cpf": "123.456.789-09"
}
```

### ❌ Teste Violação DRY - Código Duplicado
```http
### Criar pessoa com validação duplicada (violando DRY)
POST https://localhost:5001/api/pessoas/violacao/dry
Content-Type: application/json

{
  "nome": "Maria Santos",
  "cpf": "987.654.321-00"
}
```

### ✅ Teste KISS - Método Simples
```http
### Atualizar pessoa (método simples e direto)
PUT https://localhost:5001/api/pessoas/1
Content-Type: application/json

{
  "nome": "João Silva Atualizado",
  "cpf": "123.456.789-09"
}
```

### ❌ Teste Violação KISS - Método Complexo
```http
### Operação complexa (violando KISS)
POST https://localhost:5001/api/pessoas/violacao/kiss
Content-Type: application/json

{
  "nome": "Pedro Oliveira",
  "cpf": "111.222.333-44",
  "enviarEmail": true,
  "gerarRelatorio": true,
  "validarRemoto": true
}
```

---

## 📊 Comparação DRY vs Violação

| Aspecto | Violação DRY | Boa Prática DRY |
|---------|-------------|-----------------|
| **Validação CPF** | Duplicada em 3+ lugares | Serviço único reutilizável |
| **Linhas de código** | ~50 linhas | ~5 linhas |
| **Manutenção** | Alterar em múltiplos lugares | Alterar em um lugar |
| **Bugs** | Inconsistências possíveis | Comportamento uniforme |
| **Testes** | Testar cada duplicata | Testar uma vez |

---

## 📊 Comparação KISS vs Violação

| Aspecto | Violação KISS | Boa Prática KISS |
|---------|---------------|------------------|
| **Responsabilidades** | Validação + negócio + persistência | Uma responsabilidade |
| **Complexidade** | Método de 30+ linhas | Método de 3-5 linhas |
| **Testabilidade** | Difícil isolar | Fácil testar unidade |
| **Legibilidade** | Código confuso | Código claro |
| **Reutilização** | Baixa | Alta |

---

## 📈 Dados de Teste

### Pessoas Pré-cadastradas
1. **João Silva** - CPF: 123.456.789-09
2. **Maria Santos** - CPF: 987.654.321-00
3. **Pedro Oliveira** - CPF: 111.222.333-44

### CPFs de Teste Válidos
- 123.456.789-09 (válido)
- 987.654.321-00 (válido)
- 111.222.333-44 (válido)

### CPFs de Teste Inválidos
- 000.000.000-00 (sequencial)
- 111.111.111-11 (sequencial)
- 999.999.999-99 (sequencial)
- 123.456.789-00 (dígitos incorretos)

---

## 🎯 Resultados Esperados

### ✅ Funcionalidades
- [x] API responde em HTTPS (porta 5001)
- [x] PostgreSQL em Docker funcionando
- [x] 5 endpoints CRUD implementados
- [x] Validação CPF centralizada (DRY)
- [x] Métodos simples (KISS)
- [x] Exemplos de violações documentados
- [x] Arquivo de testes `.http` completo

### ✅ Qualidade do Código
- [x] Princípio DRY aplicado corretamente
- [x] Princípio KISS aplicado corretamente
- [x] Separação de responsabilidades
- [x] Repository pattern implementado
- [x] Service layer organizado
- [x] Código bem documentado

### ✅ Boas Práticas Demonstradas
- [x] Validação centralizada (DRY)
- [x] Métodos com responsabilidade única (KISS)
- [x] Tratamento de erros consistente
- [x] Mapeamento DTO padronizado
- [x] Testes automatizados disponíveis

---

## 🔍 Análise dos Conceitos

### DRY Implementado Corretamente

| Local | Implementação DRY |
|-------|-------------------|
| **CpfValidator** | Serviço único para validação |
| **Error Handling** | Método HandleError() reutilizável |
| **DTO Mapping** | AutoMapper ou método único |
| **Repository** | Interface comum para acesso a dados |

### KISS Implementado Corretamente

| Local | Implementação KISS |
|-------|-------------------|
| **Controller Methods** | Um endpoint = uma ação |
| **Service Methods** | Uma responsabilidade por método |
| **Model Validation** | Regras diretas e simples |
| **API Responses** | Estrutura clara e consistente |

### Violações Demonstradas

#### DRY Violations
- Código de validação duplicado
- Tratamento de erros espalhado
- Lógica de negócio repetida

#### KISS Violations
- Método fazendo múltiplas tarefas
- Validações complexas inline
- Lógica aninhada e confusa

---

## 📞 Suporte

Para dúvidas ou problemas:
1. Verificar `documentation.md` para explicações detalhadas
2. Consultar logs do terminal para erros de Docker/banco
3. Verificar se Docker Desktop está rodando
4. Confirmar portas 5001 (API) e 5432 (PostgreSQL) livres
5. Usar o arquivo `ApiBoasPraticas.http` para testes

---

## 🎉 Conclusão

A atividade foi **concluída com sucesso**, demonstrando os princípios fundamentais de boas práticas de código através de uma API REST completa. Os conceitos DRY e KISS foram aplicados corretamente, com exemplos claros de violações e suas respectivas correções.

**Tecnologias**: C#, ASP.NET Core, Entity Framework Core, PostgreSQL, Docker
**Conceitos**: DRY, KISS, Clean Code, Repository Pattern
**Status**: ✅ DESENVOLVIDA E TESTADA

**Link do Repositório:** https://github.com/Luizx0/desenvolvimento-de-distemas

---

**Disciplina**: Desenvolvimento de Sistemas
**Atividade**: 70 - API - Boas práticas de código - Conceitos DRY e KISS
**Data**: Abril 2026
**Status**: ✅ CONCLUÍDA - Código Desenvolvido e Documentado</content>
<parameter name="filePath">d:\LUIZ\!Program\CEUB\ds de sis\desenvolvimento-de-distemas\70 - API - Boas práticas de código - Conceitos DRY e KISS\guia-execucao-evidencias.md