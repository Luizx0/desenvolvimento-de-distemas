# 📑 ÍNDICE DO PROJETO - API de Produtos com POO em JavaScript

## 📚 Documentação Disponível

### 🎯 Comece Aqui!

1. **[README.md](./README.md)** - Instruções rápidas de instalação e execução (2-3 min)

2. **[guia-execucao-evidencias.md](./guia-execucao-evidencias.md)** - Guia passo a passo com prints e testes (10 min)

3. **[documentation.md](./documentation.md)** - Documentação completa e detalhada (20 min)

---

## 📂 Estrutura de Arquivos

```
50 - API - Programação Orientada a Objetos - Outra linguagem/
│
├── 📄 README.md                         ← LEIA PRIMEIRO (rápido)
├── 📄 INDEX.md                          ← Este arquivo
├── 📄 guia-execucao-evidencias.md       ← PASSO A PASSO (com testes)
├── 📄 documentation.md                  ← REFERÊNCIA COMPLETA
│
└── 📂 ApiProdutosJs/                    ← CÓDIGO DA API
    │
    ├── 📄 server.js                     ← Servidor Express
    ├── 📄 package.json                  ← Dependências
    ├── 📄 cliente.js                    ← Cliente exemplo
    ├── 📄 ApiProdutosJs.http            ← Testes no VSCode
    ├── 📄 .gitignore                    ← Git ignore
    │
    ├── 📂 models/                       ← Classes POO
    │   ├── Produto.js                  # Classe base
    │   ├── Eletronico.js               # Herança do Produto
    │   └── Roupa.js                    # Herança do Produto
    │
    ├── 📂 controllers/                  ← Lógica de negócio
    │   └── ProdutoController.js        # CRUD de produtos
    │
    └── 📂 routes/                       ← Endpoints HTTP
        └── produtos.js                 # Rotas da API
```

---

## 🎓 O que Você vai Aprender

### 1️⃣ Classes em JavaScript

📄 **Arquivo**: `models/Produto.js`

```javascript
export class Produto {
  constructor(id, nome, preco, estoque) { }
  obterInfo() { }
  obterDescricao() { }
}
```

- Criação de classes
- Construtores
- Propriedades e métodos

---

### 2️⃣ Herança em JavaScript

📄 **Arquivos**: `models/Eletronico.js` e `models/Roupa.js`

```javascript
export class Eletronico extends Produto {
  constructor(...) {
    super(...);  // Chamando superclasse
    // Propriedades específicas
  }
}
```

- Extensão de classes com `extends`
- Chamada de superclasse com `super()`
- Reutilização de código

---

### 3️⃣ Polimorfismo em JavaScript

📄 **Arquivos**: Todos os models

```javascript
// Mesma assinatura, comportamentos diferentes
// Produto
obterDescricao() { return `${nome} - R$ ${preco}`; }

// Eletronico (sobrescrita)
obterDescricao() { return `${nome} (${marca}) - ${voltagem}V - R$ ${preco}`; }

// Roupa (sobrescrita)
obterDescricao() { return `${nome} - Tamanho ${tamanho}, Cor ${cor}`; }
```

---

### 4️⃣ API REST com Express

📄 **Arquivo**: `server.js` e `routes/produtos.js`

- Endpoints HTTP (GET, POST, PUT, DELETE)
- Middleware Express
- Tratamento de erros
- Resposta JSON

---

### 5️⃣ Arquitetura Cliente-Servidor

📄 **Arquivo**: `cliente.js`

- Fazer requisições HTTP
- Consumir API
- Processar respostas JSON

---

## 🔥 Funcionalidades da API

### CRUD Completo
- ✅ CREATE - POST /api/produtos
- ✅ READ - GET /api/produtos e GET /api/produtos/:id
- ✅ UPDATE - PUT /api/produtos/:id
- ✅ DELETE - DELETE /api/produtos/:id

### Filtros
- ✅ Por tipo (Eletronico, Roupa)
- ✅ Por estoque (baixo, alto)
- ✅ Informações específicas por tipo

### POO
- ✅ Classes com herança
- ✅ Polimorfismo em métodos
- ✅ Encapsulamento de dados

---

## 🚀 Como Começar (Rápido)

```bash
# 1. Abra o terminal na pasta ApiProdutosJs
cd "...\ApiProdutosJs"

# 2. Instale as dependências
npm install

# 3. Inicie o servidor
npm start

# 4. Em outro terminal, teste
curl http://localhost:3000/api/produtos
```

---

## 📋 Tabela de Conteúdos por Arquivo

### 📄 server.js
- Criar app Express
- Configurar middleware
- Definir rotas
- Iniciar servidor na porta 3000

### 📄 models/Produto.js
- **Linha 1-10**: Classe Produto
- **Linha 20-30**: Método obterInfo()
- **Linha 40-50**: Método obterDescricao()
- **Linha 60-70**: Método calcularValorTotal()

### 📄 models/Eletronico.js
- **Linha 1-10**: Classe Eletronico extends Produto
- **Linha 20-30**: Sobrescrita de obterInfo()
- **Linha 40-50**: Sobrescrita de obterDescricao()
- **Linha 60-70**: Método específico calcularSeguro()

### 📄 models/Roupa.js
- **Linha 1-10**: Classe Roupa extends Produto
- **Linha 20-30**: Sobrescrita de obterInfo()
- **Linha 40-50**: Sobrescrita de obterDescricao()
- **Linha 60-70**: Métodos específicos

### 📄 controllers/ProdutoController.js
- **Linha 1-50**: Inicialização e produtos de exemplo
- **Linha 60-100**: Métodos CRUD (obterTodos, obterPorId, criar)
- **Linha 150-200**: Filtros (filtrarPorTipo, obterEstoqueBaixo)
- **Linha 250-300**: Métodos polimórficos (obterInfoEletronico, obterInfoRoupa)

### 📄 routes/produtos.js
- **GET /api/produtos**: Listar todos
- **GET /api/produtos/:id**: Obter por ID
- **POST /api/produtos**: Criar novo
- **PUT /api/produtos/:id**: Atualizar
- **DELETE /api/produtos/:id**: Deletar

### 📄 ApiProdutosJs.http
- 21 exemplos de requisições
- Testes para cada endpoint
- Exemplos de criação e atualização

---

## 🧪 Testes Disponíveis

### ✅ Teste 1: Listar Todos
```http
GET http://localhost:3000/api/produtos
```

### ✅ Teste 2: Obter Um
```http
GET http://localhost:3000/api/produtos/1
```

### ✅ Teste 3: Criar
```http
POST http://localhost:3000/api/produtos
{ "tipo": "Eletronico", "nome": "...", "preco": 999 }
```

### ✅ Teste 4: Atualizar
```http
PUT http://localhost:3000/api/produtos/1
{ "preco": 999 }
```

### ✅ Teste 5: Deletar
```http
DELETE http://localhost:3000/api/produtos/1
```

---

## 🛠️ Tecnologias

- **Node.js** - Runtime JavaScript
- **Express.js** - Web framework
- **ES6+ Modules** - import/export
- **JSON** - Formato de dados

---

## 📊 Estatísticas do Código

- **Linhas de código**: ~1000+
- **Arquivos**: 8 arquivos principais
- **Classes**: 3 classes (Produto, Eletronico, Roupa)
- **Endpoints**: 12 endpoints REST
- **Métodos**: 30+ métodos
- **Comentários**: 100+ linhas (bem documentado)

---

## 🎯 Objetivos Atingidos

✅ Criar API em linguagem diferente de C# (JavaScript)
✅ Implementar POO (classes, herança, polimorfismo)
✅ Demonstrar CRUD completo
✅ Fornecer cliente HTTP para consumo
✅ Criar arquivo .http para testes no VSCode
✅ Documentar passo a passo
✅ Fornecer guide de execução
✅ Incluir exemplos de uso

---

## 📞 Próximos Passos

1. Leia o **README.md** (5 min)
2. Siga o **guia-execucao-evidencias.md** (15 min)
3. Execute o código e teste os endpoints
4. Estude o código em **documentation.md**
5. Experimente criar seus próprios tipos de produtos!

---

## 📌 Atalhos Úteis

| Ação | Comando |
|------|---------|
| Instalar deps | `npm install` |
| Iniciar | `npm start` |
| Testar GET | `curl http://localhost:3000/api/produtos` |
| Ver docs | Abra `documentation.md` |
| Testar API | Abra `ApiProdutosJs.http` no VSCode |

---

## 🎓 Disciplina

**Desenvolvimento de Sistemas**
**Atividade**: API com Programação Orientada a Objetos
**Linguagem**: JavaScript (Node.js)
**Data**: Abril 2026

---

**Status**: ✅ COMPLETO E FUNCIONAL
