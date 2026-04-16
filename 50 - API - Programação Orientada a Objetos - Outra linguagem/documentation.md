# 📚 Documentação – API de Produtos com POO em JavaScript

## 👤 Disciplina
Desenvolvimento de Sistemas

## 🎯 Objetivo

Compreender e aplicar os conceitos fundamentais de **Programação Orientada a Objetos (POO)** implementando uma **API REST em JavaScript (Node.js)** que demonstra:

- ✅ **Classes** - Estruturas para criar tipos de dados personalizados
- ✅ **Herança** - Extensão de funcionalidades através de superclasses
- ✅ **Polimorfismo** - Mesmo método, comportamentos diferentes em subclasses
- ✅ **Arquitetura Cliente-Servidor** - Separação entre fornecedor e consumidor de dados
- ✅ **API REST** - Endpoints HTTP para CRUD (Create, Read, Update, Delete)

---

## 📋 Descrição da Atividade

Nesta atividade foi desenvolvida uma **API REST em Node.js com Express** que demonstra os conceitos de Programação Orientada a Objetos através da implementação de um sistema de gerenciamento de produtos.

A API permite:

- Consultar produtos
- Criar novos produtos
- Atualizar informações de produtos
- Deletar produtos
- Filtrar por tipo de produto
- Obter informações específicas de eletrônicos e roupas

A API pode ser testada utilizando:

- **REST Client** (Extensão do VSCode) - Arquivo `.http`
- **Postman**
- **Insomnia**
- **cURL**
- **Navegador** (apenas para GET)

---

## 🏗️ Estrutura do Projeto

```
ApiProdutosJs/
│
├── models/
│   ├── Produto.js          # Classe base (superclasse)
│   ├── Eletronico.js       # Classe que herda de Produto
│   └── Roupa.js            # Classe que herda de Produto
│
├── controllers/
│   └── ProdutoController.js # Controller para gerenciar modelos
│
├── routes/
│   └── produtos.js         # Rotas da API
│
├── server.js               # Arquivo principal do servidor
│
├── package.json            # Dependências do projeto
│
├── ApiProdutosJs.http      # Arquivo para testar no VSCode
│
└── documentation.md        # Esta documentação
```

### Estrutura de Pastas Explicada

#### `/models` - **Modelos de Dados**
Contém as classes que representam os dados:

- **Produto.js**: Superclasse base com propriedades e métodos comuns
- **Eletronico.js**: Subclasse que estende Produto com propriedades específicas
- **Roupa.js**: Subclasse que estende Produto com propriedades específicas

#### `/controllers` - **Lógica de Negócio**
Arquivo que gerencia os dados:

- **ProdutoController.js**: Implementa CRUD e manipula objetos de produtos

#### `/routes` - **Endpoints da API**
Define as rotas HTTP:

- **produtos.js**: Define todos os endpoints REST

---

## 📚 Conceitos de POO Aplicados

### 1. **Classes (Classe Base - Herança)**

#### Classe Base: `Produto`

```javascript
export class Produto {
  constructor(id, nome, preco, estoque) {
    this.id = id;
    this.nome = nome;
    this.preco = preco;
    this.estoque = estoque;
  }

  obterInfo() {
    return {
      id: this.id,
      nome: this.nome,
      preco: this.preco,
      estoque: this.estoque,
      tipo: "Produto Genérico"
    };
  }

  obterDescricao() {
    return `${this.nome} - R$ ${this.preco.toFixed(2)}`;
  }
}
```

**O que é:**
- Define a estrutura base para todos os produtos
- Contém propriedades comuns (id, nome, preço, estoque)
- Define métodos que podem ser herdados pelas subclasses

### 2. **Herança**

#### Classe Filha: `Eletronico extends Produto`

```javascript
export class Eletronico extends Produto {
  constructor(id, nome, preco, estoque, voltagem, marca, garantiaEmMeses) {
    super(id, nome, preco, estoque); // Chamando construtor da superclasse
    
    // Propriedades específicas de eletrônicos
    this.voltagem = voltagem;
    this.marca = marca;
    this.garantiaEmMeses = garantiaEmMeses;
  }

  obterInfo() {
    return {
      ...super.obterInfo(),  // Herda dados da superclasse
      voltagem: this.voltagem,
      marca: this.marca,
      garantiaEmMeses: this.garantiaEmMeses,
      tipo: "Eletrônico"
    };
  }

  // Método específico de Eletrônico
  calcularSeguro(percentual = 5) {
    return (this.preco * percentual) / 100;
  }
}
```

**O que é:**
- A classe `Eletronico` **herda** de `Produto`
- Reutiliza todas as propriedades e métodos de `Produto`
- Adiciona suas próprias propriedades e métodos
- Usa `super()` para chamar o construtor da superclasse

**Benefícios:**
- Reutilização de código
- Organização hierárquica
- Especialização de tipos

### 3. **Polimorfismo**

O polimorfismo é demonstrado através da **sobrescrita de métodos**:

#### Mesmo Método, Comportamentos Diferentes

```javascript
// Na classe Produto (base)
obterDescricao() {
  return `${this.nome} - R$ ${this.preco.toFixed(2)}`;
}

// Sobrescrita em Eletronico
obterDescricao() {
  return `${this.nome} (${this.marca}) - ${this.voltagem}V - R$ ${this.preco.toFixed(2)} - Garantia: ${this.garantiaEmMeses} meses`;
}

// Sobrescrita em Roupa
obterDescricao() {
  return `${this.nome} - Tamanho ${this.tamanho}, Cor ${this.cor} (${this.material}) - R$ ${this.preco.toFixed(2)}`;
}
```

**O que é:**
- Todas as classes (Produto, Eletronico, Roupa) têm o método `obterDescricao()`
- Cada classe implementa de forma diferente
- O método correto é chamado automaticamente baseado no tipo do objeto

**Exemplo de Polimorfismo em Ação:**

```javascript
// No Controller
obterTodos() {
  return this.produtos.map(produto => produto.obterInfo());
}

// Cada produto retorna suas próprias informações
// Polimorfismo garante que o método correto seja chamado
```

---

## 🔧 Funcionamento da API

### Arquitetura Cliente-Servidor

```
┌─────────────────┐
│   Cliente HTTP  │
│  (REST Client,  │
│   Postman, etc) │
└────────┬────────┘
         │ HTTP Request
         │ (GET, POST, PUT, DELETE)
         ↓
┌─────────────────────────────────┐
│     Servidor Express (Node.js)  │
│  ┌───────────────────────────┐  │
│  │   Routes (produtos.js)    │  │
│  │  ┌─────────────────────┐  │  │
│  │  │  Controllers        │  │  │
│  │  │ (ProdutoController) │  │  │
│  │  │  ┌───────────────┐  │  │  │
│  │  │  │ Models        │  │  │  │
│  │  │  │ - Produto     │  │  │  │
│  │  │  │ - Eletronico  │  │  │  │
│  │  │  │ - Roupa       │  │  │  │
│  │  │  └───────────────┘  │  │  │
│  │  └─────────────────────┘  │  │
│  └───────────────────────────┘  │
└────────┬────────────────────────┘
         │ HTTP Response
         │ (JSON)
         ↓
┌─────────────────┐
│   Cliente HTTP  │
│  Dispõe dados   │
└─────────────────┘
```

### Fluxo de uma Requisição

#### Exemplo: GET /api/produtos/1

```
1. Cliente envia: GET http://localhost:3000/api/produtos/1

2. Express roteia para: routes/produtos.js

3. Route handler executa:
   - Extrai ID da URL
   - Chama produtoController.obterPorId(1)

4. Controller executa:
   - Procura produto com ID 1
   - Chama produto.obterInfo() (polimorfismo!)
   - Retorna objeto com informações

5. Route handler envia JSON para cliente

6. Cliente recebe:
   {
     "sucesso": true,
     "mensagem": "Produto obtido com sucesso",
     "dados": { ... }
   }
```

---

## 🚀 Como Executar

### Pré-requisitos

- **Node.js** (versão 14 ou superior)
- **npm** (incluso com Node.js)
- **VSCode** com extensão REST Client (opcional, para usar arquivo .http)

### Passo 1: Instalar Dependências

```bash
# Navegue até a pasta do projeto
cd ApiProdutosJs

# Instale as dependências
npm install
```

### Passo 2: Iniciar o Servidor

```bash
# Inicie o servidor
npm start
```

**Resultado esperado:**
```
╔═══════════════════════════════════════════════════════════╗
║                                                           ║
║   🚀 API de Produtos com POO em JavaScript               ║
║                                                           ║
║   Servidor rodando em http://localhost:3000              ║
║                                                           ║
║   Documentação: http://localhost:3000                    ║
║   Health Check: http://localhost:3000/health             ║
║                                                           ║
╚═══════════════════════════════════════════════════════════╝
```

### Passo 3: Testar a API

#### Opção 1: Usar REST Client (VSCode)

1. Instale a extensão "REST Client" no VSCode
2. Abra o arquivo `ApiProdutosJs.http`
3. Clique em "Send Request" sobre qualquer requisição
4. Veja o resultado no painel de resposta

#### Opção 2: Usar Postman

1. Abra o Postman
2. Importe os dados do arquivo `.http` ou crie requisições manualmente
3. Defina a URL e método HTTP
4. Envie a requisição

#### Opção 3: Usar cURL

```bash
# Exemplo: Obter todos os produtos
curl http://localhost:3000/api/produtos

# Exemplo: Obter um produto específico
curl http://localhost:3000/api/produtos/1

# Exemplo: Criar um novo eletrônico
curl -X POST http://localhost:3000/api/produtos \
  -H "Content-Type: application/json" \
  -d '{
    "tipo": "Eletronico",
    "nome": "Tablet Samsung",
    "preco": 1500.00,
    "estoque": 8,
    "voltagem": 110,
    "marca": "Samsung",
    "garantiaEmMeses": 12
  }'
```

---

## 📡 Endpoints da API

### 🔵 GET - Obter Dados

#### 1. Obter todos os produtos
```
GET /api/produtos
```

**Resposta:**
```json
{
  "sucesso": true,
  "mensagem": "Produtos obtidos com sucesso",
  "dados": [
    {
      "id": 1,
      "nome": "Notebook Dell",
      "preco": 2500,
      "estoque": 5,
      "voltagem": 110,
      "marca": "Dell",
      "garantiaEmMeses": 24,
      "tipo": "Eletrônico"
    },
    // ... mais produtos
  ],
  "total": 6
}
```

#### 2. Obter produto por ID
```
GET /api/produtos/:id

Exemplo: GET /api/produtos/1
```

#### 3. Obter descrição de um produto
```
GET /api/produtos/:id/descricao

Exemplo: GET /api/produtos/1/descricao
```

**Resposta:**
```json
{
  "sucesso": true,
  "mensagem": "Descrição obtida com sucesso",
  "dados": {
    "descricao": "Notebook Dell (Dell) - 110V - R$ 2500.00 - Garantia: 24 meses"
  }
}
```

#### 4. Filtrar produtos por tipo
```
GET /api/produtos/tipo/:tipo

Exemplos:
- GET /api/produtos/tipo/Eletronico
- GET /api/produtos/tipo/Roupa
```

#### 5. Obter produtos com estoque baixo
```
GET /api/produtos/estoque/baixo/:limite

Exemplo: GET /api/produtos/estoque/baixo/10
```

#### 6. Obter informações específicas de eletrônico
```
GET /api/produtos/info/eletronico/:id

Exemplo: GET /api/produtos/info/eletronico/1
```

**Resposta (com cálculo de seguro):**
```json
{
  "sucesso": true,
  "mensagem": "Informações de eletrônico obtidas com sucesso",
  "dados": {
    "id": 1,
    "nome": "Notebook Dell",
    "preco": 2500,
    "estoque": 5,
    "voltagem": 110,
    "marca": "Dell",
    "garantiaEmMeses": 24,
    "tipo": "Eletrônico",
    "seguro": 125,
    "emGarantia": true
  }
}
```

#### 7. Obter informações específicas de roupa
```
GET /api/produtos/info/roupa/:id

Exemplo: GET /api/produtos/info/roupa/4
```

**Resposta (com cuidados e desconto):**
```json
{
  "sucesso": true,
  "mensagem": "Informações de roupa obtidas com sucesso",
  "dados": {
    "id": 4,
    "nome": "Camiseta Básica",
    "preco": 49.9,
    "estoque": 100,
    "tamanho": "M",
    "cor": "Branco",
    "material": "Algodão",
    "colecao": "Básica",
    "tipo": "Roupa",
    "desconto": 4.99,
    "cuidados": [
      "Lavar em água morna",
      "Não usar alvejante",
      "Secar ao ar livre"
    ],
    "disponibilidade": "Em estoque abundante"
  }
}
```

### 🟢 POST - Criar Dados

#### Criar novo eletrônico
```
POST /api/produtos
Content-Type: application/json

{
  "tipo": "Eletronico",
  "nome": "Fone Bluetooth",
  "preco": 320.00,
  "estoque": 25,
  "voltagem": 110,
  "marca": "JBL",
  "garantiaEmMeses": 12
}
```

#### Criar nova roupa
```
POST /api/produtos
Content-Type: application/json

{
  "tipo": "Roupa",
  "nome": "Calça Social",
  "preco": 180.00,
  "estoque": 40,
  "tamanho": "M",
  "cor": "Cinza",
  "material": "Poliéster",
  "colecao": "Social"
}
```

### 🟡 PUT - Atualizar Dados

#### Atualizar produto
```
PUT /api/produtos/:id
Content-Type: application/json

{
  "preco": 2750.00,
  "estoque": 7
}
```

### 🔴 DELETE - Deletar Dados

#### Deletar produto
```
DELETE /api/produtos/:id

Exemplo: DELETE /api/produtos/1
```

---

## 📊 Dados Iniciais

A API vem com 6 produtos pré-carregados:

### Eletrônicos
1. **Notebook Dell** - R$ 2.500,00 (5 em estoque)
2. **Smartphone Samsung** - R$ 1.200,00 (15 em estoque)
3. **Cabo USB-C** - R$ 45,00 (50 em estoque)

### Roupas
4. **Camiseta Básica** - R$ 49,90 (100 em estoque)
5. **Calça Jeans** - R$ 120,00 (80 em estoque)
6. **Jaqueta de Couro** - R$ 350,00 (20 em estoque)

---

## 💻 Exemplo Completo de Uso

### Cenário: Sistema de Loja Online

```javascript
// 1. Buscar todos os eletrônicos
GET /api/produtos/tipo/Eletronico

// 2. Criar um novo eletrônico
POST /api/produtos
{
  "tipo": "Eletronico",
  "nome": "Smart TV 55\"",
  "preco": 1800,
  "estoque": 3,
  "voltagem": 110,
  "marca": "LG",
  "garantiaEmMeses": 24
}

// 3. Obter informações do novo produto (ID 7)
GET /api/produtos/7

// 4. Obter informações específicas (com seguro)
GET /api/produtos/info/eletronico/7

// 5. Atualizar estoque após venda
PUT /api/produtos/7
{
  "estoque": 2
}

// 6. Obter produtos com estoque baixo
GET /api/produtos/estoque/baixo/5
```

---

## 🧪 Testes com REST Client

O arquivo `ApiProdutosJs.http` contém 21 requisições de teste cobrindo:

- ✅ Informações da API
- ✅ Health check
- ✅ CRUD completo
- ✅ Filtros por tipo
- ✅ Informações específicas
- ✅ Operações de estoque

### Como usar:

1. Instale a extensão "REST Client" no VSCode
2. Abra `ApiProdutosJs.http`
3. Clique em "Send Request" para qualquer requisição
4. Visualize a resposta no painel abaixo

---

## 🔍 Conceitos-Chave Implementados

| Conceito | Arquivo | Descrição |
|----------|---------|-----------|
| **Classe Base** | Produto.js | Define estrutura comum para todos os produtos |
| **Herança** | Eletronico.js, Roupa.js | Estendem Produto com atributos específicos |
| **Polimorfismo** | controllers/ | Sobrescrita de métodos `obterInfo()` e `obterDescricao()` |
| **Encapsulamento** | models/ | Propriedades e métodos privados/públicos |
| **Abstração** | ProdutoController.js | Interface simplificada para operações CRUD |
| **Padrão Singleton** | ProdutoController.js | Uma única instância do controller |
| **REST API** | server.js, routes/ | Endpoints HTTP para operações |
| **Middleware** | server.js | Logger de requisições |

---

## 📈 Estrutura de Resposta Padrão

Todas as respostas seguem um padrão consistente:

```json
{
  "sucesso": true/false,
  "mensagem": "Descrição do resultado",
  "dados": { /* dados específicos */ },
  "total": /* número de itens */,
  "erro": /* mensagem de erro, se houver */
}
```

---

## 🛠️ Tecnologias Utilizadas

- **Node.js** - Runtime JavaScript
- **Express.js** - Framework web minimalist
- **JavaScript ES6+** - Linguagem com classes e módulos
- **JSON** - Formato de dados

---

## 📝 Conclusão

Esta API demonstra práticas profissionais de desenvolvimento:

✅ **Organização**: Estrutura clara em models, controllers, routes
✅ **POO**: Classes, herança, polimorfismo bem aplicados
✅ **REST**: Padrões HTTP corretos (GET, POST, PUT, DELETE)
✅ **Escalabilidade**: Fácil adicionar novos tipos de produtos
✅ **Manutenibilidade**: Código limpo e bem documentado
✅ **Testabilidade**: Arquivo .http com exemplos completos

---

**Desenvolvido como atividade de Desenvolvimento de Sistemas**
**Data**: Abril 2026
**Linguagem**: JavaScript (Node.js)
