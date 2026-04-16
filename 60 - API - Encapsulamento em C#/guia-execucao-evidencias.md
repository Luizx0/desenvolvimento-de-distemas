# 📦 DOCUMENTO DE ENTREGA - Atividade 60

## 🎯 Atividade: API em C# com Encapsulamento

### 📋 Descrição da Atividade

Criar uma API em C# utilizando o conceito de encapsulamento, demonstrando os princípios de Programação Orientada a Objetos através de uma aplicação ASP.NET Core que gerencia usuários com validação de dados e controle de acesso.

---

## 📂 Estrutura Entregue

### 📁 Pasta: `60 - API - Encapsulamento em C#`

#### 📄 Documentos
- ✅ `documentation.md` - Documentação completa da API e conceitos de encapsulamento
- ✅ `guia-execucao-evidencias.md` - Guia de execução e evidências (este arquivo)

#### 📁 Código-Fonte (Disponível no Repositório)
- ✅ `ApiEncapsulamento/` - Pasta com código C# completo
- ✅ `Controllers/`, `Models/`, `Data/` - Estrutura do projeto
- ✅ `Program.cs`, `appsettings.json` - Arquivos de configuração
- ✅ `ApiEncapsulamento.http` - Arquivo de testes REST

---

## 🔗 Repositório

**Link do Repositório:** https://github.com/Luizx0/desenvolvimento-de-distemas

### 📍 Localização no Repositório

A atividade completa está localizada em:
```
desenvolvimento-de-distemas/
└── 60 - API - Encapsulamento em C#/
    ├── documentation.md                    ← Documentação completa
    ├── guia-execucao-evidencias.md         ← Este documento
    └── ApiEncapsulamento/                  ← Projeto C# completo
        ├── Controllers/
        │   └── UsuariosController.cs
        ├── Models/
        │   └── Usuario.cs
        ├── Data/
        │   └── UsuarioRepository.cs
        ├── Program.cs
        ├── appsettings.json
        ├── appsettings.Development.json
        ├── ApiEncapsulamento.csproj
        └── ApiEncapsulamento.http
```

**Nota:** Todo o código-fonte C# foi desenvolvido e está disponível tanto no repositório GitHub quanto na estrutura local da atividade.

---

## 📚 Conteúdo da Atividade

### 🎯 Objetivos Alcançados

✅ **API em C#**: Implementada com ASP.NET Core
✅ **Encapsulamento**: Demonstrado através de propriedades e métodos
✅ **Validação de Dados**: Setters com regras de negócio
✅ **Controle de Acesso**: Campos privados, métodos públicos
✅ **CRUD Completo**: Create, Read, Update, Delete
✅ **Documentação**: Explicação detalhada dos conceitos

### 🏗️ Arquitetura Implementada

#### Models/Usuario.cs
- **Campos privados**: `_id`, `_nome`, `_email`, `_dataNascimento`, `_ativo`
- **Propriedades públicas**: `Id`, `Nome`, `Email`, `DataNascimento`, `Idade`, `Ativo`
- **Validações**: Nome não vazio, email válido, idade mínima 13 anos
- **Métodos**: `ObterInformacoesFormatadas()`, `AlterarStatus()`, `AtualizarDados()`

#### Controllers/UsuariosController.cs
- **Endpoints REST**: 5 endpoints (GET, POST, PUT, DELETE)
- **Injeção de dependência**: Repository pattern
- **Tratamento de erros**: HTTP status codes apropriados

#### Data/UsuarioRepository.cs
- **Simulação de banco**: Lista em memória
- **Operações CRUD**: Métodos para manipular usuários

---

## 📊 Funcionalidades Implementadas

### 🔵 Operações GET
- **Listar usuários**: `GET /api/usuarios`
- **Obter por ID**: `GET /api/usuarios/{id}`

### 🟢 Operação POST
- **Criar usuário**: `POST /api/usuarios`
- Validação automática via encapsulamento

### 🟡 Operação PUT
- **Atualizar usuário**: `PUT /api/usuarios/{id}`
- Usa métodos de atualização com validação

### 🔴 Operação DELETE
- **Deletar usuário**: `DELETE /api/usuarios/{id}`

---

## 🎓 Conceitos de Encapsulamento Demonstrados

### 1. **Campos Privados**
```csharp
private string _nome;
private string _email;
```
- Dados internos protegidos

### 2. **Propriedades com Validação**
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
- Getters permitem leitura
- Setters validam antes de armazenar

### 3. **Propriedades Somente Leitura**
```csharp
public int Idade
{
    get { return CalcularIdade(_dataNascimento); }
}
```
- Calculadas dinamicamente
- Não modificáveis externamente

### 4. **Métodos de Controle**
```csharp
public void AtualizarDados(string nome, string email, DateTime dataNascimento)
{
    Nome = nome;        // Usa setter com validação
    Email = email;      // Usa setter com validação
    DataNascimento = dataNascimento;  // Usa setter com validação
}
```
- Interface pública consistente
- Validação automática

---

## 📈 Dados de Teste

### Usuários Pré-cadastrados

1. **João Silva**
   - Email: joao.silva@email.com
   - Nascimento: 15/05/1990 (36 anos)
   - Status: Ativo

2. **Maria Santos**
   - Email: maria.santos@email.com
   - Nascimento: 22/08/1985 (41 anos)
   - Status: Ativo

3. **Pedro Oliveira**
   - Email: pedro.oliveira@email.com
   - Nascimento: 10/12/1995 (31 anos)
   - Status: Ativo

---

## 🚀 Como Executar

### Pré-requisitos
- **.NET 9.0** instalado (ou .NET 6.0+)
- **Visual Studio 2022** ou **VS Code** (opcional)

### 📍 Opção 1: Execução Local (Código já disponível)

Se você tem acesso à pasta local da atividade:

1. **Navegar para pasta do projeto**:
   ```bash
   cd "60 - API - Encapsulamento em C#/ApiEncapsulamento"
   ```

2. **Executar a API**:
   ```bash
   dotnet run
   ```

3. **Testar**:
   - API: `https://localhost:5001/api/usuarios`
   - Arquivo de testes: Abrir `ApiEncapsulamento.http` no VS Code

### 📍 Opção 2: Execução via Repositório

Se precisar clonar do repositório:

1. **Clonar repositório**:
   ```bash
   git clone https://github.com/Luizx0/desenvolvimento-de-distemas.git
   ```

2. **Navegar para pasta**:
   ```bash
   cd desenvolvimento-de-distemas/60 - API - Encapsulamento em C#/ApiEncapsulamento
   ```

3. **Executar**:
   ```bash
   dotnet run
   ```

4. **Testar**:
   - API: `https://localhost:5001/api/usuarios`
   - Arquivo de testes: `ApiEncapsulamento.http`

---

---

## 🧪 Como Testar

### Opção 1: REST Client (VSCode) - RECOMENDADO
- Abra `ApiEncapsulamento.http` no VS Code
- Clique em "Send Request" para cada requisição
- Veja as respostas diretamente no editor

### Opção 2: Postman/cURL
- Use os endpoints documentados em `documentation.md`
- Importe as requisições do arquivo `ApiEncapsulamento.http`

### Opção 3: Navegador/Insomnia
- Use as URLs dos endpoints para testes manuais

---

## 📋 Verificação de Funcionamento

### ✅ Testes de Encapsulamento

#### 1. **Tentativa de Acesso Direto** (Deve falhar)
```csharp
Usuario usuario = new Usuario();
// usuario._nome = "João";  // ❌ Erro: campo privado
```

#### 2. **Uso Correto via Propriedade** (Deve funcionar)
```csharp
Usuario usuario = new Usuario("João", "joao@email.com", new DateTime(1990, 5, 15));
// ✅ Funciona: valida e armazena
```

#### 3. **Validação Automática** (Deve lançar exception)
```csharp
usuario.Nome = "";  // ❌ ArgumentException: "Nome não pode ser vazio"
usuario.Email = "email-invalido";  // ❌ ArgumentException: "Email inválido"
```

#### 4. **Propriedade Calculada** (Deve retornar valor correto)
```csharp
int idade = usuario.Idade;  // ✅ Retorna 36 (calculado)
```

---

## 📊 Evidências de Execução

### Capturas de Tela Recomendadas

1. **Terminal com `dotnet run`** - Mostrar servidor iniciando
2. **Swagger UI** - Interface da API funcionando
3. **GET /api/usuarios** - Listando usuários
4. **POST /api/usuarios** - Criando usuário com validação
5. **PUT /api/usuarios/1** - Atualizando usuário
6. **Tentativa de dados inválidos** - Mostrar erro de validação

### Logs de Execução

```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
```

---

## 🎯 Resultados Esperados

### ✅ Funcionalidades
- [x] API responde em HTTPS (porta 5001)
- [x] 5 endpoints REST funcionais (GET, POST, PUT, DELETE)
- [x] CRUD completo implementado
- [x] Validações de encapsulamento ativas
- [x] Dados de teste carregados
- [x] Arquivo de testes `ApiEncapsulamento.http` disponível
- [x] 5 endpoints REST funcionais
- [x] CRUD completo implementado
- [x] Validações de encapsulamento ativas
- [x] Dados de teste carregados

### ✅ Qualidade do Código
- [x] Encapsulamento implementado corretamente
- [x] Propriedades com getters/setters
- [x] Validações nos setters
- [x] Métodos de controle público
- [x] Tratamento de erros adequado
- [x] Código bem comentado

### ✅ Documentação
- [x] Conceitos explicados
- [x] Exemplos de código
- [x] Instruções de execução
- [x] Casos de uso
- [x] Evidências de teste

---

## 🔍 Suporte

Para dúvidas ou problemas:
1. Verificar `documentation.md` para explicações detalhadas
2. Consultar logs do terminal para erros
3. Verificar se .NET 9.0 está instalado
4. Confirmar portas 5000/5001 livres
5. Usar o arquivo `ApiEncapsulamento.http` para testes

---

## 🎉 Conclusão

A atividade foi **concluída com sucesso**, demonstrando o conceito de encapsulamento através de uma API REST em C# com ASP.NET Core. Todos os requisitos foram atendidos:

✅ **API em C#**: Implementada com ASP.NET Core (.NET 9.0)
✅ **Encapsulamento**: Campos privados, propriedades validadas
✅ **CRUD**: Operações completas de gerenciamento
✅ **Validação**: Regras de negócio nos setters
✅ **Documentação**: Explicação completa dos conceitos
✅ **Código**: Desenvolvido e disponível localmente e no repositório
✅ **Testes**: Arquivo `ApiEncapsulamento.http` com casos de teste

**Link do Repositório:** https://github.com/Luizx0/desenvolvimento-de-distemas

---

**Disciplina**: Desenvolvimento de Sistemas
**Atividade**: 60 - API - Encapsulamento em C#
**Data**: Abril 2026
**Status**: ✅ CONCLUÍDA - Código Desenvolvido e Testado
