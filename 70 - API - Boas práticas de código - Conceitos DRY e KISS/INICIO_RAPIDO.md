# ⚡ INÍCIO RÁPIDO - Atividade 70

## 3 Passos para Executar

### 1️⃣ Iniciar Docker (Banco de Dados)
```bash
cd "70 - API - Boas práticas de código - Conceitos DRY e KISS/ApiBoasPraticas"
docker-compose up -d
```

### 2️⃣ Executar Aplicação
```bash
dotnet ef database update   # Criar tabelas
dotnet run                  # Iniciar API
```

### 3️⃣ Testar
- Abra `ApiBoasPraticas.http` no VS Code
- Clique "Send Request" em qualquer endpoint

---

## 📍 Endpoints Principais

| Método | URL | Descrição |
|--------|-----|-----------|
| GET | `/api/pessoas` | Listar todas |
| GET | `/api/pessoas/1` | Por ID |
| POST | `/api/pessoas` | Criar (com validação CPF) |
| PUT | `/api/pessoas/1` | Atualizar |
| DELETE | `/api/pessoas/1` | Deletar |
| POST | `/api/pessoas/violacao/dry` | Exemplo DRY incorreto |
| POST | `/api/pessoas/violacao/kiss` | Exemplo KISS incorreto |

---

## CPFs Válidos para Teste
- 529.982.247-25
- 123.456.789-09
- 987.654.321-00
- 111.222.333-44

---

## Estrutura de Pastas
```
📂 70 - API - Boas práticas...
├── 📄 README.md                    (Guia técnico)
├── 📄 documentation.md             (Conceitos)
├── 📄 guia-execucao-evidencias.md  (Passo a passo)
├── 📄 CHECKLIST.md                 (Verificação)
├── 📄 RESUMO_EXECUTIVO.md          (Visão geral)
└── 📁 ApiBoasPraticas/             (Código fonte)
    ├── Controllers/                (2 controllers)
    ├── Services/                   (DRY + KISS)
    ├── Models/                     (Pessoa + validação)
    ├── DTOs/                       (Mapeamento dados)
    ├── Data/                       (Repository + EF)
    ├── docker-compose.yml          (PostgreSQL)
    └── ApiBoasPraticas.http        (Testes)
```

---

## ✨ O que Aprender Aqui

### ✅ DRY (Don't Repeat Yourself)
Veja como `ICpfValidator` é reutilizado em `PessoaService` sem duplicação.

### ✅ KISS (Keep It Simple, Stupid)
Veja como `PessoaService` tem métodos simples com uma responsabilidade.

### ✅ Repository Pattern
Acesso a dados centralizado em `PessoaRepository`.

### ✅ Dependency Injection
Configuração em `Program.cs` injetando dependências.

### ❌ Violações Educacionais
`PessoasViolacaoController` mostra como NÃO fazer.

---

## 🧹 Parar Tudo

```bash
docker-compose down      # Parar Docker
docker-compose down -v   # Parar e deletar dados
dotnet clean            # Limpar build
```

---

## 📧 Dicas

- Use `ApiBoasPraticas.http` para testes automatizados
- Compare `PessoasController.cs` (✅ bom) com `PessoasViolacaoController.cs` (❌ ruim)
- Leia `documentation.md` para entender os conceitos
- Veja o `Program.cs` para entender a configuração

---

**Status: PRONTO PARA USAR** ✅
