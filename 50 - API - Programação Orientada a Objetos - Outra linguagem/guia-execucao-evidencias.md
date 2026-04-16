# 📋 GUIA DE EXECUÇÃO E EVIDÊNCIAS

## 🎯 Objetivo

Demonstrar a criação de uma **API REST em JavaScript (Node.js)** com **Programação Orientada a Objetos**, incluindo os conceitos de:
- Classes
- Herança  
- Polimorfismo

---

## ✅ Arquivos Entregues

### 📁 Estrutura do Projeto

```
50 - API - Programação Orientada a Objetos - Outra linguagem/
│
├── 📄 README.md                          # Instruções rápidas
├── 📄 documentation.md                   # Documentação completa
├── 📄 guia-execucao-evidencias.md       # Este arquivo
│
└── 📂 ApiProdutosJs/
    ├── 📂 models/
    │   ├── Produto.js                  # Classe base (genérico)
    │   ├── Eletronico.js               # Subclasse (herança do Produto)
    │   └── Roupa.js                    # Subclasse (herança do Produto)
    │
    ├── 📂 controllers/
    │   └── ProdutoController.js        # Controlador com lógica CRUD
    │
    ├── 📂 routes/
    │   └── produtos.js                 # Rotas HTTP da API
    │
    ├── 📄 server.js                    # Servidor Express principal
    ├── 📄 cliente.js                   # Cliente exemplo
    ├── 📄 package.json                 # Dependências do projeto
    ├── 📄 ApiProdutosJs.http           # Arquivo para testear no VSCode
    └── 📄 .gitignore                   # Arquivos ignorados pelo Git
```

---

## 🚀 PASSO A PASSO DA EXECUÇÃO

### Passo 1: Instalar Node.js (Se não tiver)

1. Acesse https://nodejs.org/
2. Baixe a versão LTS (Long Term Support)
3. Instale normalmente

**Verificar instalação:**
```bash
node --version
npm --version
```

---

### Passo 2: Abrir Terminal na Pasta do Projeto

```bash
# No Windows (PowerShell ou CMD)
cd "d:\LUIZ\!Program\CEUB\ds de sis\desenvolvimento-de-distemas\50 - API - Programação Orientada a Objetos - Outra linguagem\ApiProdutosJs"
```

---

### Passo 3: Instalar Dependências

```bash
npm install
```

**O que acontece:**
- Lê o arquivo `package.json`
- Baixa o Express (framework web) e suas dependências
- Cria pasta `node_modules/`

**Tempo estimado:** 30-60 segundos

---

### Passo 4: Iniciar o Servidor

```bash
npm start
```

**Saída esperada:**
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

**O que significa:**
- ✅ Servidor iniciado com sucesso
- ✅ Escutando na porta 3000
- ✅ Pronto para receber requisições

---

### Passo 5: Testar a API (Mantenha o servidor rodando)

**Abra OUTRO terminal** e execute os testes:

#### Opção A: Usar REST Client (RECOMENDADO)

1. Instale a extensão "REST Client" no VSCode
2. Abra o arquivo `ApiProdutosJs.http`
3. Clique em **"Send Request"** sobre qualquer requisição
4. Veja a resposta no painel lateral

**Exemplo de requisição:**
```http
### Obter todos os produtos
GET http://localhost:3000/api/produtos
```

**Resposta esperada:**
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

#### Opção B: Usar cURL

```bash
# Obter todos os produtos
curl http://localhost:3000/api/produtos

# Obter um produto específico (ID=1)
curl http://localhost:3000/api/produtos/1

# Criar um novo eletrônico
curl -X POST http://localhost:3000/api/produtos ^
  -H "Content-Type: application/json" ^
  -d "{\"tipo\":\"Eletronico\",\"nome\":\"Tablet\",\"preco\":800,\"estoque\":5,\"voltagem\":110,\"marca\":\"Apple\",\"garantiaEmMeses\":12}"
```

#### Opção C: Usar Postman

1. Abra o Postman
2. Crie uma nova request
3. Cole a URL: `http://localhost:3000/api/produtos`
4. Clique em "Send"

#### Opção D: Cliente JavaScript

Em OUTRO terminal:
```bash
# Executar o cliente de teste
node client.js
```

---

## 🧪 TESTES RECOMENDADOS

### Teste 1: Listar todos os produtos
```
GET http://localhost:3000/api/produtos
```

### Teste 2: Obter um eletrônico específico
```
GET http://localhost:3000/api/produtos/1
```

### Teste 3: Obter informações detalhadas (com seguro)
```
GET http://localhost:3000/api/produtos/info/eletronico/1
```

**Resposta incluirá:**
```json
{
  "seguro": 125,              // 5% do preço
  "emGarantia": true,         // Propriedade calculada
  // ... outras informações
}
```

### Teste 4: Obter informações de roupa (com recomendações)
```
GET http://localhost:3000/api/produtos/info/roupa/4
```

**Resposta incluirá:**
```json
{
  "desconto": 4.99,           // Desconto da coleção
  "cuidados": [               // Recomendações por material
    "Lavar em água morna",
    "Não usar alvejante",
    "Secar ao ar livre"
  ],
  "disponibilidade": "Em estoque abundante"
}
```

### Teste 5: Criar novo eletrônico
```
POST http://localhost:3000/api/produtos
Content-Type: application/json

{
  "tipo": "Eletronico",
  "nome": "Monitor Gamer",
  "preco": 1200.00,
  "estoque": 5,
  "voltagem": 110,
  "marca": "ASUS",
  "garantiaEmMeses": 24
}
```

**Resposta:**
```json
{
  "sucesso": true,
  "mensagem": "Produto criado com sucesso",
  "dados": {
    "id": 7,  // Novo ID atribuído automaticamente
    "nome": "Monitor Gamer",
    "preco": 1200,
    // ... restante dos dados
  }
}
```

### Teste 6: Filtrar por tipo
```
GET http://localhost:3000/api/produtos/tipo/Eletronico
GET http://localhost:3000/api/produtos/tipo/Roupa
```

### Teste 7: Atualizar um produto
```
PUT http://localhost:3000/api/produtos/1
Content-Type: application/json

{
  "preco": 2800.00,
  "estoque": 10
}
```

### Teste 8: Deletar um produto
```
DELETE http://localhost:3000/api/produtos/7
```

---

## 📊 DEMONSTRAÇÃO DOS CONCEITOS POO

### 1. Classes

Arquivos que implementam:
- `models/Produto.js` - Classe base com atributos comuns
- `models/Eletronico.js` - Classe especializada
- `models/Roupa.js` - Classe especializada

**Exemplo de classe:**
```javascript
export class Produto {
  constructor(id, nome, preco, estoque) {
    this.id = id;
    this.nome = nome;
    this.preco = preco;
    this.estoque = estoque;
  }
  
  obterDescricao() {
    return `${this.nome} - R$ ${this.preco.toFixed(2)}`;
  }
}
```

### 2. Herança

Demonstrada em `Eletronico.js` e `Roupa.js`:

```javascript
// Eletronico HERDA de Produto
export class Eletronico extends Produto {
  constructor(id, nome, preco, estoque, voltagem, marca, garantiaEmMeses) {
    super(id, nome, preco, estoque);  // Chama construtor da superclasse
    
    // Propriedades específicas
    this.voltagem = voltagem;
    this.marca = marca;
    this.garantiaEmMeses = garantiaEmMeses;
  }
}
```

**Benefício:**
- Reutiliza código de Produto
- Adiciona propriedades específicas
- Evita duplicação

### 3. Polimorfismo

Método `obterDescricao()` implementado diferentemente:

**Em Produto.js:**
```javascript
obterDescricao() {
  return `${this.nome} - R$ ${this.preco.toFixed(2)}`;
}
// Resultado: "Notebook Dell - R$ 2500.00"
```

**Em Eletronico.js (sobrescrita):**
```javascript
obterDescricao() {
  return `${this.nome} (${this.marca}) - ${this.voltagem}V - R$ ${this.preco.toFixed(2)} - Garantia: ${this.garantiaEmMeses} meses`;
}
// Resultado: "Notebook Dell (Dell) - 110V - R$ 2500.00 - Garantia: 24 meses"
```

**Em Roupa.js (sobrescrita):**
```javascript
obterDescricao() {
  return `${this.nome} - Tamanho ${this.tamanho}, Cor ${this.cor} (${this.material}) - R$ ${this.preco.toFixed(2)}`;
}
// Resultado: "Camiseta Básica - Tamanho M, Cor Branco (Algodão) - R$ 49.90"
```

**No Controller (polimorfismo em ação):**
```javascript
// Cada tipo retorna sua própria descrição
const descricao = produto.obterDescricao();
```

---

## 📡 ENDPOINTS DA API

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/produtos` | Listar todos |
| GET | `/api/produtos/:id` | Obter por ID |
| GET | `/api/produtos/tipo/:tipo` | Filtrar por tipo |
| GET | `/api/produtos/info/eletronico/:id` | Info eletronico |
| GET | `/api/produtos/info/roupa/:id` | Info roupa |
| POST | `/api/produtos` | Criar novo |
| PUT | `/api/produtos/:id` | Atualizar |
| DELETE | `/api/produtos/:id` | Deletar |

---

## 🎬 FLUXO DE UMA REQUISIÇÃO

### Exemplo: GET /api/produtos/1

```
1. Cliente envia para http://localhost:3000/api/produtos/1
   ↓
2. Express roteia para GET /api/produtos/:id em routes/produtos.js
   ↓
3. Handler extrai id=1 da URL
   ↓
4. Chama produtoController.obterPorId(1)
   ↓
5. Controller procura this.produtos.find(p => p.id === 1)
   ↓
6. Encontra objeto Eletronico com id=1
   ↓
7. Chama produto.obterInfo() (POLIMORFISMO!)
   ↓
8. Eletronico.obterInfo() retorna suas informações específicas
   ↓
9. Controller retorna os dados
   ↓
10. Express envia JSON como resposta para o cliente
    ↓
11. Cliente recebe e processa
```

---

## 🔍 VERIFICAÇÃO DE FUNCIONAMENTO

### Checklist de Sucesso

- ✅ Servidor inicia sem erros
- ✅ Consegue acessar http://localhost:3000
- ✅ GET /api/produtos retorna lista de 6 produtos
- ✅ GET /api/produtos/1 retorna Notebook Dell
- ✅ GET /api/produtos/info/eletronico/1 mostra seguro e garantia
- ✅ GET /api/produtos/info/roupa/4 mostra cuidados
- ✅ POST cria novo produto com novo ID
- ✅ PUT atualiza preço e estoque
- ✅ DELETE remove produto
- ✅ Polimorfismo funciona (cada tipo tem descrição diferente)

---

## 🛑 SOLUÇÃO DE PROBLEMAS

### Servidor não inicia
```bash
# Verificar se port 3000 está livrea
netstat -ano | find "3000"

# Se tiver algo, matar processo ou usar porta diferente
```

### Erro "Cannot find module 'express'"
```bash
# Reinstalar dependências
npm install
```

### Erro de conexão recusada
```bash
# Verificar se servidor está rodando
# Testar com: curl http://localhost:3000
```

---

## 💾 SALVANDO A EVIDÊNCIA

### Capturas de Tela Recomendadas

1. **Terminal com servidor rodando**
   - Mostra inicialização com sucesso

2. **VSCode com REST Client**
   - Mostra requisição GET /api/produtos
   - Resposta em JSON

3. **Resposta de GET /api/produtos/info/eletronico/1**
   - Mostra polimorfismo (que calcula seguro)

4. **Resposta de GET /api/produtos/info/roupa/4**
   - Mostra polimorfismo (que calcula recomendações)

5. **POST criando novo produto**
   - Mostra ID novo atribuído

6. **PUT atualizando preço**
   - Mostra produto modificado

---

## 📝 CONCLUSÃO

A API demonstra com sucesso:

✅ **Classes**: Produto, Eletronico, Roupa
✅ **Herança**: Eletronico e Roupa extendem Produto
✅ **Polimorfismo**: obterDescricao() diferente em cada classe
✅ **POO**: Organização clara em models, controllers, routes
✅ **REST**: Endpoints HTTP corretos
✅ **CRUD**: Create, Read, Update, Delete funcionando
✅ **JSON**: Dados estruturados em JSON
✅ **Documentação**: Código comentado e bem documentado

---

**Atividade Concluída**: ✅
**Data**: Abril 2026
**Linguagem**: JavaScript (Node.js)
**Framework**: Express
