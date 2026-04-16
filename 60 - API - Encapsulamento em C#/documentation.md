# 📚 Documentação – API em C# com Encapsulamento

## 👤 Disciplina
Desenvolvimento de Sistemas

## 🎯 Objetivo

Compreender e aplicar o conceito de **encapsulamento** em Programação Orientada a Objetos através da implementação de uma **API REST em C#** utilizando **ASP.NET Core**. O encapsulamento será demonstrado através de:

- Propriedades privadas com getters/setters públicos
- Validação de dados nas propriedades
- Métodos públicos que controlam acesso aos dados privados
- Separação clara entre interface pública e implementação privada

---

## 📋 Descrição da Atividade

Nesta atividade foi desenvolvida uma **API REST em C# utilizando ASP.NET Core** que demonstra o conceito de encapsulamento através de uma aplicação de gerenciamento de usuários. A API permite operações CRUD (Create, Read, Update, Delete) sobre usuários, com validação de dados e controle de acesso aos atributos.

O encapsulamento é implementado através de:

- **Propriedades privadas** com **getters e setters públicos**
- **Validação de dados** nos setters
- **Métodos de negócio** que controlam o acesso aos dados
- **Separação entre interface e implementação**

---

## 🏗️ Estrutura do Projeto

```
ApiEncapsulamento/
│
├── Controllers/
│   └── UsuariosController.cs      # Controller da API
│
├── Models/
│   └── Usuario.cs                 # Modelo com encapsulamento
│
├── Data/
│   └── UsuarioRepository.cs       # Repositório (simula banco)
│
├── Program.cs                     # Arquivo principal
│
├── appsettings.json               # Configurações
│
├── appsettings.Development.json   # Configurações dev
│
├── ApiEncapsulamento.csproj       # Projeto C#
│
├── ApiEncapsulamento.http         # Testes REST Client
│
└── Properties/
    └── launchSettings.json        # Configurações de execução
```

---

## 📚 Conceito de Encapsulamento

### O que é Encapsulamento?

**Encapsulamento** é um dos pilares da Programação Orientada a Objetos que consiste em:

- **Ocultar a implementação interna** de uma classe
- **Proteger os dados** através de modificadores de acesso
- **Controlar o acesso** aos atributos através de métodos
- **Fornecer uma interface pública** consistente

### Benefícios

- **Segurança**: Dados não podem ser modificados diretamente
- **Manutenibilidade**: Mudanças na implementação não afetam o código externo
- **Validação**: Dados podem ser validados antes de serem armazenados
- **Flexibilidade**: Implementação pode mudar sem quebrar contratos

---

## 💻 Implementação do Encapsulamento

### Classe Usuario.cs

```csharp
public class Usuario
{
    // Campos privados (encapsulados)
    private int _id;
    private string _nome;
    private string _email;
    private DateTime _dataNascimento;
    private bool _ativo;

    // Propriedade com getter/setter (encapsulamento controlado)
    public int Id
    {
        get { return _id; }
        private set { _id = value; }  // Setter privado
    }

    // Propriedade com validação no setter
    public string Nome
    {
        get { return _nome; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Nome não pode ser vazio");
            if (value.Length < 2)
                throw new ArgumentException("Nome deve ter pelo menos 2 caracteres");
            _nome = value.Trim();
        }
    }

    // Propriedade com validação de email
    public string Email
    {
        get { return _email; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Email não pode ser vazio");
            if (!IsValidEmail(value))
                throw new ArgumentException("Email inválido");
            _email = value.ToLower().Trim();
        }
    }

    // Propriedade com validação de idade
    public DateTime DataNascimento
    {
        get { return _dataNascimento; }
        set
        {
            if (value > DateTime.Now)
                throw new ArgumentException("Data de nascimento não pode ser futura");
            if (CalcularIdade(value) < 13)
                throw new ArgumentException("Usuário deve ter pelo menos 13 anos");
            _dataNascimento = value;
        }
    }

    // Propriedade somente leitura (calculada)
    public int Idade
    {
        get { return CalcularIdade(_dataNascimento); }
    }

    // Propriedade com lógica de negócio
    public bool Ativo
    {
        get { return _ativo; }
        set
        {
            // Lógica adicional pode ser implementada aqui
            _ativo = value;
        }
    }

    // Construtor que utiliza as propriedades (encapsulamento)
    public Usuario(string nome, string email, DateTime dataNascimento)
    {
        Nome = nome;           // Usa setter com validação
        Email = email;         // Usa setter com validação
        DataNascimento = dataNascimento;  // Usa setter com validação
        Ativo = true;          // Valor padrão
    }

    // Método privado auxiliar
    private bool IsValidEmail(string email)
    {
        // Implementação simplificada de validação de email
        return email.Contains("@") && email.Contains(".");
    }

    // Método privado auxiliar
    private int CalcularIdade(DateTime dataNascimento)
    {
        var hoje = DateTime.Today;
        var idade = hoje.Year - dataNascimento.Year;
        if (dataNascimento.Date > hoje.AddYears(-idade)) idade--;
        return idade;
    }

    // Método público que expõe funcionalidade encapsulada
    public string ObterInformacoesFormatadas()
    {
        return $"{Nome} ({Email}) - {Idade} anos - Status: {(Ativo ? "Ativo" : "Inativo")}";
    }

    // Método público para ativar/desativar (controle de estado)
    public void AlterarStatus(bool ativo)
    {
        Ativo = ativo;
    }

    // Método público para atualizar dados (usa setters com validação)
    public void AtualizarDados(string nome, string email, DateTime dataNascimento)
    {
        Nome = nome;
        Email = email;
        DataNascimento = dataNascimento;
    }
}
```

### Análise da Implementação

#### 1. Campos Privados
```csharp
private int _id;
private string _nome;
private string _email;
private DateTime _dataNascimento;
private bool _ativo;
```
- Dados internos não são acessíveis diretamente
- Protegidos contra modificação externa

#### 2. Propriedades com Getters/Setters
```csharp
public string Nome
{
    get { return _nome; }
    set
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Nome não pode ser vazio");
        _nome = value.Trim();
    }
}
```
- **Getter**: Permite leitura controlada
- **Setter**: Valida dados antes de armazenar
- **Trim()**: Limpa espaços em branco
- **Validação**: Garante integridade dos dados

#### 3. Propriedade Somente Leitura
```csharp
public int Idade
{
    get { return CalcularIdade(_dataNascimento); }
}
```
- Calculada dinamicamente
- Não pode ser modificada externamente
- Encapsula lógica de cálculo

#### 4. Métodos Privados
```csharp
private bool IsValidEmail(string email)
private int CalcularIdade(DateTime dataNascimento)
```
- Implementação interna oculta
- Podem mudar sem afetar código externo

#### 5. Métodos Públicos
```csharp
public string ObterInformacoesFormatadas()
public void AlterarStatus(bool ativo)
public void AtualizarDados(string nome, string email, DateTime dataNascimento)
```
- Interface pública da classe
- Controlam acesso aos dados encapsulados

---

## 🔧 Funcionamento da API

### Endpoints Disponíveis

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/usuarios` | Listar todos os usuários |
| GET | `/api/usuarios/{id}` | Obter usuário por ID |
| POST | `/api/usuarios` | Criar novo usuário |
| PUT | `/api/usuarios/{id}` | Atualizar usuário |
| DELETE | `/api/usuarios/{id}` | Deletar usuário |

### Exemplo de Uso

#### Criar Usuário (POST /api/usuarios)
```json
{
  "nome": "João Silva",
  "email": "joao.silva@email.com",
  "dataNascimento": "1990-05-15"
}
```

**Resposta:**
```json
{
  "id": 1,
  "nome": "João Silva",
  "email": "joao.silva@email.com",
  "dataNascimento": "1990-05-15T00:00:00",
  "idade": 36,
  "ativo": true
}
```

#### Tentativa de Dados Inválidos
```json
{
  "nome": "",  // Nome vazio
  "email": "email-invalido",  // Email inválido
  "dataNascimento": "2030-01-01"  // Data futura
}
```

**Resposta de Erro:**
```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "Nome": ["Nome não pode ser vazio"],
    "Email": ["Email inválido"],
    "DataNascimento": ["Data de nascimento não pode ser futura"]
  }
}
```

---

## 🧪 Demonstração do Encapsulamento

### Cenário 1: Acesso Direto Bloqueado

```csharp
// ❌ ERRO: Campos são privados
Usuario usuario = new Usuario();
usuario._nome = "João";  // Erro de compilação!

// ✅ CORRETO: Usa propriedade com validação
usuario.Nome = "João";  // Funciona e valida
```

### Cenário 2: Validação Automática

```csharp
Usuario usuario = new Usuario("João", "joao@email.com", new DateTime(1990, 5, 15));

// ✅ Dados válidos são aceitos
usuario.Nome = "João Silva";  // OK

// ❌ Dados inválidos geram erro
usuario.Nome = "";  // ArgumentException: "Nome não pode ser vazio"
usuario.Email = "email-invalido";  // ArgumentException: "Email inválido"
```

### Cenário 3: Propriedade Calculada

```csharp
Usuario usuario = new Usuario("João", "joao@email.com", new DateTime(1990, 5, 15));

// ✅ Idade calculada automaticamente
int idade = usuario.Idade;  // Retorna 36 (calculado)

// ❌ Não pode ser modificada
usuario.Idade = 40;  // Erro de compilação!
```

### Cenário 4: Método de Controle

```csharp
Usuario usuario = new Usuario("João", "joao@email.com", new DateTime(1990, 5, 15));

// ✅ Método público controla acesso
usuario.AlterarStatus(false);  // Desativa usuário

// ✅ Método público valida e atualiza
usuario.AtualizarDados("João Silva", "joao.silva@email.com", new DateTime(1990, 5, 15));
```

---

## 📊 Dados de Exemplo

A API vem com 3 usuários pré-cadastrados:

1. **João Silva**
   - Email: joao.silva@email.com
   - Data Nascimento: 15/05/1990
   - Idade: 36 anos
   - Status: Ativo

2. **Maria Santos**
   - Email: maria.santos@email.com
   - Data Nascimento: 22/08/1985
   - Idade: 41 anos
   - Status: Ativo

3. **Pedro Oliveira**
   - Email: pedro.oliveira@email.com
   - Data Nascimento: 10/12/1995
   - Idade: 31 anos
   - Status: Ativo

---

## 🚀 Como Executar

### Pré-requisitos

- **.NET 6.0 ou superior**
- **Visual Studio 2022** ou **VS Code** com extensão C#
- **Windows/Linux/Mac**

### Passo 1: Clonar o Repositório

```bash
git clone https://github.com/Luizx0/desenvolvimento-de-distemas.git
cd desenvolvimento-de-distemas/60 - API - Encapsulamento em C#
```

### Passo 2: Executar a API

```bash
# No Visual Studio: Abrir ApiEncapsulamento.csproj e executar

# Ou via linha de comando:
dotnet run
```

### Passo 3: Testar

A API estará disponível em: `https://localhost:5001` ou `http://localhost:5000`

#### Usar Swagger
- Acesse: `https://localhost:5001/swagger`
- Interface gráfica para testar endpoints

#### Usar REST Client (VSCode)
- Abra `ApiEncapsulamento.http`
- Clique em "Send Request"

#### Usar Postman
- Importe os endpoints ou crie manualmente

---

## 📡 Exemplos de Requisições

### 1. Listar Todos os Usuários
```
GET https://localhost:5001/api/usuarios
```

### 2. Obter Usuário Específico
```
GET https://localhost:5001/api/usuarios/1
```

### 3. Criar Novo Usuário
```
POST https://localhost:5001/api/usuarios
Content-Type: application/json

{
  "nome": "Ana Costa",
  "email": "ana.costa@email.com",
  "dataNascimento": "1988-03-20"
}
```

### 4. Atualizar Usuário
```
PUT https://localhost:5001/api/usuarios/1
Content-Type: application/json

{
  "nome": "João Silva Junior",
  "email": "joao.silva.jr@email.com",
  "dataNascimento": "1990-05-15"
}
```

### 5. Deletar Usuário
```
DELETE https://localhost:5001/api/usuarios/1
```

---

## 🔍 Análise Técnica

### Vantagens da Implementação

#### 1. **Segurança de Dados**
- Campos privados não podem ser acessados diretamente
- Validações garantem integridade dos dados

#### 2. **Manutenibilidade**
- Mudanças na implementação interna não afetam código externo
- Lógica de validação centralizada

#### 3. **Reutilização**
- Classe pode ser usada em diferentes contextos
- Métodos públicos fornecem interface consistente

#### 4. **Testabilidade**
- Métodos podem ser testados isoladamente
- Validações podem ser verificadas

### Comparação com Código sem Encapsulamento

#### ❌ Sem Encapsulamento
```csharp
public class UsuarioRuim
{
    public string Nome;      // Público direto
    public string Email;     // Sem validação
    public DateTime DataNascimento;  // Sem validação
}
```

**Problemas:**
- Dados podem ser modificados sem validação
- Email pode ser inválido
- Data pode ser futura
- Nome pode ser vazio

#### ✅ Com Encapsulamento
```csharp
public class Usuario
{
    private string _nome;
    public string Nome
    {
        get { return _nome; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Nome não pode ser vazio");
            _nome = value.Trim();
        }
    }
    // ... outras propriedades com validação
}
```

**Benefícios:**
- Validação automática
- Dados protegidos
- Interface consistente

---

## 📈 Conclusão

Esta API demonstra de forma prática como o **encapsulamento** é fundamental em Programação Orientada a Objetos:

✅ **Proteção de Dados**: Campos privados inacessíveis diretamente
✅ **Validação**: Dados validados automaticamente nos setters
✅ **Controle de Acesso**: Métodos públicos controlam operações
✅ **Manutenibilidade**: Mudanças internas não quebram código externo
✅ **Segurança**: Integridade dos dados garantida
✅ **Flexibilidade**: Implementação pode evoluir sem impactar usuários

A implementação segue as melhores práticas de desenvolvimento C# e ASP.NET Core, proporcionando uma base sólida para aplicações reais que necessitam de controle rigoroso sobre os dados.

---

**Desenvolvido como atividade de Desenvolvimento de Sistemas**
**Data**: Abril 2026
**Linguagem**: C# (.NET 6)
**Framework**: ASP.NET Core Web API
