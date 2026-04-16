# 📚 Desenvolvimento de Sistemas - Projetos Educacionais

Repositório com projetos educacionais em C# e JavaScript demonstrando conceitos fundamentais de desenvolvimento de software, desde aplicações console até APIs REST completas.

---

## 🎯 O Que Contém Este Repositório

Como um portfolio de aprendizado, este repositório apresenta projetos progressivos cobrindo:
- ✅ Aplicações console em C#
- ✅ APIs REST com ASP.NET Core
- ✅ Banco de dados com Entity Framework Core
- ✅ Containerização com Docker
- ✅ Padrões de arquitetura (Repository, Service Layer, Clean Architecture)
- ✅ Princípios SOLID e boas práticas de código
- ✅ Validação e tratamento de erros
- ✅ JavaScript/Node.js

---

## 📁 Principais Atividades

### 🚀 Atividades Iniciais (Console)
| Pasta | Descrição |
|-------|-----------|
| `1 - Como criar um aplicativo console com C#` | Primeira aplicação console |
| `2 - Programa console que recebe parametros...` | Console com passagem de parâmetros |
| `3 - Programa console em ... linguagem diferente` | Console em JavaScript |
| `4 - Programa console em C# imprime 2 saídas` | Múltiplas saídas |
| `5 - Programa console em C# recebe 2 numeros` | Operações matemáticas |
| `6 - Programa console que lê 5 numeros` | Manipulação de arrays |

### 🌐 APIs Cliente-Servidor
| Pasta | Descrição |
|-------|-----------|
| `10 - Criando uma Aplicação Cliente-Servidor Simples - C#` | API REST em C# com frontend |
| `20 - Criando uma Aplicação Cliente-Servidor Simples - Outras linguagens` | API em Node.js com JavaScript |

### 🏗️ Arquitetura e Padrões (APIs Avançadas)
| Pasta | Nível | Foco |
|-------|-------|------|
| `40 - API - Programação Orientada a Objetos - C#` | Intermediário | OOP, Controllers |
| `50 - API - Programação Orientada a Objetos - Outra linguagem` | Intermediário | OOP em outro idioma |
| `60 - API - Encapsulamento em C#` | Avançado | Encapsulamento, Validações |
| `70 - API - Boas práticas de código - Conceitos DRY e KISS` | Avançado | **← Última Atividade** |

---

## 📌 Atividade Destaque: 70 - Boas Práticas (DRY e KISS)

A atividade mais recente implementa os princípios fundamentais de boas práticas:

```
📂 70 - API - Boas práticas de código - Conceitos DRY e KISS/
├── 📘 Documentação (7 arquivos)
│   ├── INICIO_RAPIDO.md          ← Comece aqui!
│   ├── README.md                 (Guia técnico)
│   ├── documentation.md          (Conceitos DRY/KISS)
│   └── ... (3 outros)
└── 💻 ApiBoasPraticas/          (Projeto .NET 8.0)
    ├── Controllers/             (Boas práticas + exemplos ruins)
    ├── Services/                (DRY + KISS)
    ├── Models/                  (Validação centralizada)
    ├── docker-compose.yml       (PostgreSQL)
    └── ...
```

**O que aprender**: DRY (Don't Repeat Yourself) e KISS (Keep It Simple, Stupid) aplicados em uma API real.

---

## 🚀 Como Começar

### Para Executar a Atividade 70 (Recomendado)
```bash
cd "70 - API - Boas práticas de código - Conceitos DRY e KISS/ApiBoasPraticas"
docker-compose up -d          # Iniciar banco
dotnet build && dotnet run    # Compilar e executar
# Acesse: https://localhost:5001
```

### Para Explorar Outras Atividades
Abra qualquer pasta e leia seu `README.md` ou `documentation.md` para entender:
- O que a atividade demonstra
- Como executá-la
- Quais conceitos aprenderá

---

## 🛠️ Stack Técnico

**C# / .NET**
- .NET 8.0
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- Docker

**JavaScript / Node.js**
- Express.js
- Requisições HTTP

**Ferramentas**
- Visual Studio Code
- Git/GitHub
- Docker Desktop

---

## 📚 Aprendizado Progressivo

As atividades seguem uma progressão de complexidade:

```
1. Console Simples
   ↓
2. Console com Parâmetros
   ↓
3. Múltiplas Linguagens
   ↓
4. Cliente-Servidor Básico
   ↓
5. APIs REST Simples
   ↓
6. OOP e Controllers
   ↓
7. Encapsulamento e Validações
   ↓
8. Boas Práticas (DRY/KISS) ← Você está aqui
```

---

## 📖 Documentação por Atividade

Cada atividade contém:
- 📄 `documentation.md` - Conceitos teóricos
- 📄 `README.md` - Guia técnico
- 📝 Exemplos práticos
- ✅ Checklist de requisitos

---

## ⭐ Destaque Técnico

### Atividade 70 Implementa
- ✅ **DRY**: Validação centralizada em serviços reutilizáveis
- ✅ **KISS**: Código simples sem complexidade desnecessária
- ✅ **Repository Pattern**: Acesso a dados abstrato
- ✅ **Dependency Injection**: Configuração em Program.cs
- ✅ **DTOs + AutoMapper**: Transferência de dados tipo-segura
- ✅ **Docker**: PostgreSQL containerizado
- ✅ **Exemplos Educacionais**: Código bom vs ruim lado a lado

---

## 🎓 De Qual Começar?

| Seu Nível | Recomendação |
|-----------|--------------|
| Iniciante | Comece pela atividade 1 (console simples) |
| Intermediário | Vá para atividade 40 (OOP) |
| Avançado | Vá direto para atividade 70 (DRY/KISS) |

---

## 💡 Estrutura de Pastas

```
desenvolvimento-de-distemas/
├── 1 - Como criar... (Console simples)
├── 2 - Programa console... (Com parâmetros)
├── ... (atividades 3-9)
├── 10 - Criando uma Aplicação Cliente-Servidor... (Cliente-Servidor)
├── 20 - Criando uma Aplicação... Outras linguagens (Node.js)
├── ... (atividades 30-50)
├── 60 - API - Encapsulamento (Encapsulamento)
├── 70 - API - Boas práticas... (DRY/KISS) ← Última
└── README.md (este arquivo)
```

---

## ✨ Próximos Passos

1. **Escolha uma atividade** que interesse você
2. **Leia o README** da pasta para entender o contexto
3. **Siga as instruções** para executar o projeto
4. **Estude o código** para entender os conceitos
5. **Experimente modificar** e aprender

---

## 🔗 Links Rápidos

- 📂 [Atividade 70 (Atual)](./70%20-%20API%20-%20Boas%20práticas%20de%20código%20-%20Conceitos%20DRY%20e%20KISS/)
- 📂 [Atividade 60 (Encapsulamento)](./60%20-%20API%20-%20Encapsulamento%20em%20C%23/)
- 📂 [Atividade 40 (OOP)](./40%20-%20API%20-%20Programação%20Orientada%20a%20Objetos%20-%20C%23/)
- 📂 [Atividade 10 (Cliente-Servidor)](./10%20-%20Criando%20uma%20Aplicação%20Cliente-Servidor%20Simples%20-%20C%23/)

---

## 📞 Informações

- **Propósito**: Projetos educacionais para aprendizado de desenvolvimento de sistemas
- **Público**: Estudantes de sistemas, desenvolvedores iniciantes
- **Progressão**: Das aplicações console até arquitetura de APIs profissionais
- **Foco**: Solidificar conceitos através de exemplos práticos

---

**Status**: ✅ Atividades 1-70 Completas e Funcionais

Para detalhes técnicos de uma atividade específica, veja seu README individual.
