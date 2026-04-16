# 🚀 API de Produtos com POO em JavaScript

## ⚡ Quick Start

### Instalação e Execução

```bash
# 1. Instale as dependências
npm install

# 2. Inicie o servidor
npm start

# 3. Acesse http://localhost:3000
```

### Testar os Endpoints

**Opção 1: REST Client (VSCode)**
- Abra `ApiProdutosJs.http`
- Clique em "Send Request" para testar

**Opção 2: Postman / Insomnia**
- Importe as requisições do arquivo `.http`
- Ou crie requisições manualmente

**Opção 3: cURL**
```bash
# Obter todos os produtos
curl http://localhost:3000/api/produtos

# Obter um produto específico
curl http://localhost:3000/api/produtos/1
```

---

## 📚 Conceitos POO Implementados

### ✅ Classes
- `Produto` - Classe base
- `Eletronico` - Subclasse de Produto
- `Roupa` - Subclasse de Produto

### ✅ Herança
```javascript
class Eletronico extends Produto { }
class Roupa extends Produto { }
```

### ✅ Polimorfismo
Método `obterDescricao()` implementado diferentemente em cada classe:
- Produto: Descrição simples
- Eletronico: Inclui voltagem, marca e garantia
- Roupa: Inclui tamanho, cor e material

---

## 📡 Principais Endpoints

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/produtos` | Listar todos |
| GET | `/api/produtos/:id` | Obter por ID |
| GET | `/api/produtos/tipo/:tipo` | Filtrar por tipo |
| GET | `/api/produtos/info/eletronico/:id` | Info de eletrônico |
| GET | `/api/produtos/info/roupa/:id` | Info de roupa |
| POST | `/api/produtos` | Criar novo |
| PUT | `/api/produtos/:id` | Atualizar |
| DELETE | `/api/produtos/:id` | Deletar |

---

## 📂 Estrutura de Arquivos

```
ApiProdutosJs/
├── models/
│   ├── Produto.js
│   ├── Eletronico.js
│   └── Roupa.js
├── controllers/
│   └── ProdutoController.js
├── routes/
│   └── produtos.js
├── server.js
├── package.json
└── ApiProdutosJs.http
```

---

## 📖 Ver Documentação Completa

Abra o arquivo `documentation.md` para documentação detalhada com:
- Explicação completa de POO
- Exemplos de código
- Fluxo de requisições
- Todos os endpoints
- Testes e exemplos

---

## 🎓 Objetivo da Atividade

Demonstrar implementação de Programação Orientada a Objetos em JavaScript com:
- Classes, herança e polimorfismo
- Arquitetura cliente-servidor
- API REST com Express
- CRUD completo
- Dados estruturados

---

**Status**: ✅ Completo e funcional
