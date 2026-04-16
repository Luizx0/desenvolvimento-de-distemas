# 📚 DOCUMENTAÇÃO TÉCNICA - Atividade 70

## 🎯 API - Boas Práticas de Código (DRY e KISS)

### 📋 Descrição da Atividade

Criar uma API REST em C# utilizando ASP.NET Core que demonstra os princípios de boas práticas de código através dos conceitos **DRY (Don't Repeat Yourself)** e **KISS (Keep It Simple, Stupid)**. A API gerencia pessoas com validação de CPF e utiliza banco de dados PostgreSQL em container Docker.

---

## 🎯 Conceitos Demonstrados

### 🔄 DRY - Don't Repeat Yourself
**Princípio**: Evitar duplicação de código. Cada conceito deve ter uma representação única, não ambígua e autoritativa.

#### ❌ Exemplo Ferindo DRY (Código Duplicado)
```csharp
// Validação de CPF duplicada em múltiplos lugares
public bool ValidarCpfUsuario(string cpf) {
    // Lógica de validação aqui...
}

public bool ValidarCpfCliente(string cpf) {
    // MESMA lógica de validação duplicada...
}

public bool ValidarCpfFornecedor(string cpf) {
    // MESMA lógica de validação duplicada novamente...
}
```

#### ✅ Exemplo Contemplando DRY (Código Reutilizável)
```csharp
// Serviço único e reutilizável
public class ValidacaoService {
    public bool ValidarCpf(string cpf) {
        // Lógica centralizada
    }
}

// Uso em diferentes contextos
_validacaoService.ValidarCpf(cpfUsuario);
_validacaoService.ValidarCpf(cpfCliente);
_validacaoService.ValidarCpf(cpfFornecedor);
```

### 🎯 KISS - Keep It Simple, Stupid
**Princípio**: Manter as coisas simples. Evitar complexidade desnecessária e soluções complicadas para problemas simples.

#### ❌ Exemplo Ferindo KISS (Solução Complexa)
```csharp
// Método complexo com múltiplas responsabilidades
public async Task<Result<Pessoa>> CadastrarPessoaComValidacaoCompleta(
    string nome, string cpf, DateTime dataNascimento,
    string endereco, string telefone, string email,
    bool validarCpfRemoto, bool enviarEmailConfirmacao,
    bool gerarRelatorio, bool notificarAdministrador) {

    // 50+ linhas de código complexo
    // Múltiplas validações aninhadas
    // Lógica de negócio misturada
    // Tratamento de erros complexo
}
```

#### ✅ Exemplo Contemplando KISS (Solução Simples)
```csharp
// Método simples e focado
public async Task<Pessoa> CadastrarPessoa(string nome, string cpf) {
    var pessoa = new Pessoa { Nome = nome, Cpf = cpf };
    await _repository.AdicionarAsync(pessoa);
    return pessoa;
}
```

---

## 🏗️ Arquitetura da Solução

### 📁 Estrutura do Projeto
```
ApiBoasPraticas/
├── Controllers/
│   ├── PessoasController.cs          # Controller principal
│   └── PessoasViolacaoController.cs  # Controller demonstrando violações
├── Models/
│   ├── Pessoa.cs                     # Entidade Pessoa
│   └── Validacao/
│       ├── CpfValidator.cs           # Validador DRY
│       └── ValidacaoService.cs       # Serviço de validação
├── Data/
│   ├── ApplicationDbContext.cs       # EF Core Context
│   ├── PessoaRepository.cs           # Repository pattern
│   └── Migrations/                   # Migrations do banco
├── Services/
│   ├── PessoaService.cs              # Serviço de negócio (KISS)
│   └── PessoaServiceViolacao.cs      # Serviço violando princípios
├── DTOs/
│   ├── PessoaDto.cs                  # Data Transfer Object
│   └── CreatePessoaDto.cs            # DTO para criação
└── Program.cs                        # Configuração da aplicação
```

### 🗄️ Banco de Dados
- **Tecnologia**: PostgreSQL em Docker
- **ORM**: Entity Framework Core
- **Padrão**: Repository Pattern

---

## 🔧 Funcionalidades Implementadas

### ✅ Endpoints da API

#### PessoasController (Boas Práticas)
```
GET    /api/pessoas           # Lista todas as pessoas
GET    /api/pessoas/{id}      # Obtém pessoa por ID
POST   /api/pessoas           # Cria nova pessoa (com validação CPF)
PUT    /api/pessoas/{id}      # Atualiza pessoa
DELETE /api/pessoas/{id}      # Remove pessoa
```

#### PessoasViolacaoController (Demonstração de Violações)
```
POST   /api/pessoas/violacao/dry      # Exemplo ferindo DRY
POST   /api/pessoas/violacao/kiss     # Exemplo ferindo KISS
```

### ✅ Validações Implementadas

#### CPF
- **Formato**: XXX.XXX.XXX-XX ou XXXXXXXXXXX
- **Algoritmo**: Validação dos dígitos verificadores
- **Regras**: Não permite CPFs inválidos ou sequenciais

#### Dados Pessoais
- **Nome**: Obrigatório, mínimo 2 caracteres
- **CPF**: Único no sistema, formato válido
- **Data Nascimento**: Não futura, idade mínima 0 anos

---

## 🔄 Demonstrações DRY

### 1. **Validação de CPF Centralizada**
```csharp
// Serviço único reutilizável
public class CpfValidator : ICpfValidator
{
    public bool IsValid(string cpf) { /* Lógica única */ }
    public string Format(string cpf) { /* Formatação única */ }
}

// Uso consistente em toda aplicação
if (!_cpfValidator.IsValid(cpf)) throw new ValidationException();
```

### 2. **Tratamento de Erros Padronizado**
```csharp
// Método único para tratamento de erros
public IActionResult HandleError(Exception ex) { /* Lógica única */ }

// Uso em todos os controllers
catch (Exception ex) { return HandleError(ex); }
```

### 3. **Mapeamento DTO Centralizado**
```csharp
// AutoMapper ou método único
public PessoaDto MapToDto(Pessoa pessoa) { /* Lógica única */ }
```

---

## 🎯 Demonstrações KISS

### 1. **Método Simples de Criação**
```csharp
// Método focado em uma responsabilidade
[HttpPost]
public async Task<IActionResult> Create(CreatePessoaDto dto) {
    var pessoa = await _service.CriarAsync(dto);
    return CreatedAtAction(nameof(GetById), new { id = pessoa.Id }, pessoa);
}
```

### 2. **Validação Direta no Model**
```csharp
// Validação simples e direta
public class Pessoa {
    [Required, MinLength(2)]
    public string Nome { get; set; }

    [Required, RegularExpression(@"\d{3}\.\d{3}\.\d{3}-\d{2}")]
    public string Cpf { get; set; }
}
```

### 3. **Serviço com Interface Clara**
```csharp
// Interface simples e intuitiva
public interface IPessoaService {
    Task<Pessoa> CriarAsync(CreatePessoaDto dto);
    Task<Pessoa?> ObterPorIdAsync(int id);
    Task AtualizarAsync(int id, UpdatePessoaDto dto);
    Task RemoverAsync(int id);
}
```

---

## 🐳 Docker Configuration

### 📄 docker-compose.yml
```yaml
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

volumes:
  postgres_data:
```

### 🔗 Connection String
```
Host=localhost;Port=5432;Database=boaspraticas;Username=postgres;Password=postgres
```

---

## 🧪 Testes Demonstrativos

### 📋 Casos de Teste DRY

#### ❌ Violação DRY - Código Duplicado
```csharp
// Controller com validação duplicada
[HttpPost("violacao/dry")]
public async Task<IActionResult> CreateComDuplicacao(CreatePessoaDto dto) {
    // Validação CPF duplicada aqui
    if (string.IsNullOrEmpty(dto.Cpf)) return BadRequest("CPF obrigatório");
    if (!ValidarFormatoCpf(dto.Cpf)) return BadRequest("CPF inválido");
    if (!ValidarDigitosCpf(dto.Cpf)) return BadRequest("CPF com dígitos inválidos");

    // Mesmo código duplicado em outros métodos...
}
```

#### ✅ Boa Prática DRY - Código Reutilizável
```csharp
[HttpPost]
public async Task<IActionResult> Create(CreatePessoaDto dto) {
    try {
        var pessoa = await _service.CriarAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = pessoa.Id }, pessoa);
    } catch (ValidationException ex) {
        return BadRequest(ex.Message);
    }
}
```

### 📋 Casos de Teste KISS

#### ❌ Violação KISS - Método Complexo
```csharp
[HttpPost("violacao/kiss")]
public async Task<IActionResult> CreateComplexo(CreatePessoaDto dto) {
    // Método fazendo tudo: validação, negócio, persistência, logs, emails...
    if (dto == null) return BadRequest();
    if (string.IsNullOrEmpty(dto.Nome)) return BadRequest();
    if (string.IsNullOrEmpty(dto.Cpf)) return BadRequest();

    // Validação CPF complexa inline
    var cpf = dto.Cpf.Replace(".", "").Replace("-", "");
    if (cpf.Length != 11) return BadRequest();
    // ... 20+ linhas de validação complexa

    // Verificar duplicidade no banco
    var existente = await _context.Pessoas.FirstOrDefaultAsync(p => p.Cpf == dto.Cpf);
    if (existente != null) return Conflict();

    // Criar entidade
    var pessoa = new Pessoa { Nome = dto.Nome, Cpf = dto.Cpf };

    // Salvar
    _context.Pessoas.Add(pessoa);
    await _context.SaveChangesAsync();

    // Log
    _logger.LogInformation($"Pessoa criada: {pessoa.Id}");

    // Retornar
    return CreatedAtAction(nameof(GetById), new { id = pessoa.Id }, pessoa);
}
```

#### ✅ Boa Prática KISS - Método Simples
```csharp
[HttpPost]
public async Task<IActionResult> Create(CreatePessoaDto dto) {
    var pessoa = await _service.CriarAsync(dto);
    return CreatedAtAction(nameof(GetById), new { id = pessoa.Id }, pessoa);
}
```

---

## 📊 Comparação de Implementações

| Aspecto | Violação DRY/KISS | Boa Prática DRY/KISS |
|---------|-------------------|----------------------|
| **Linhas de Código** | 50+ linhas | 5-10 linhas |
| **Responsabilidades** | Múltiplas | Uma principal |
| **Reutilização** | Nenhuma | Alta |
| **Manutenibilidade** | Difícil | Fácil |
| **Testabilidade** | Complexa | Simples |
| **Legibilidade** | Baixa | Alta |

---

## 🚀 Como Executar

### Pré-requisitos
- .NET 9.0+
- Docker Desktop
- Visual Studio Code ou Visual Studio

### Passos
1. **Iniciar banco**: `docker-compose up -d`
2. **Executar migrations**: `dotnet ef database update`
3. **Rodar API**: `dotnet run`
4. **Testar**: Usar `ApiBoasPraticas.http`

---

## 📈 Benefícios Demonstrados

### ✅ DRY Benefits
- **Redução de bugs**: Menos código duplicado = menos bugs
- **Manutenibilidade**: Alteração em um lugar afeta todos
- **Consistência**: Comportamento uniforme
- **Produtividade**: Desenvolvimento mais rápido

### ✅ KISS Benefits
- **Simplicidade**: Código fácil de entender
- **Testabilidade**: Métodos simples são fáceis de testar
- **Debugging**: Problemas mais fáceis de identificar
- **Escalabilidade**: Código simples escala melhor

---

## 🎯 Conclusão

Esta atividade demonstra como os princípios DRY e KISS podem transformar código complexo e problemático em soluções elegantes e manuteníveis. Através de exemplos práticos de violações e correções, fica clara a importância de aplicar boas práticas de desenvolvimento de software.

**Tecnologias**: C#, ASP.NET Core, Entity Framework Core, PostgreSQL, Docker
**Conceitos**: DRY, KISS, Clean Code, SOLID Principles
**Padrões**: Repository, Service Layer, DTO Pattern</content>
<parameter name="filePath">d:\LUIZ\!Program\CEUB\ds de sis\desenvolvimento-de-distemas\70 - API - Boas práticas de código - Conceitos DRY e KISS\documentation.md