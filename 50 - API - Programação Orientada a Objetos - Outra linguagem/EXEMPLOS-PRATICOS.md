# 💡 EXEMPLOS PRÁTICOS - Como Usar a API

Este arquivo mostra exemplos do mundo real de como usar a API.

---

## 🌍 Cenário 1: E-commerce de Produtos

### Caso de Uso: Gerenciar Estoque de Loja Online

#### Problema
Você tem uma loja online com eletrônicos e roupas. Precisa de um sistema para:
- Listar produtos disponíveis
- Obter detalhes de um produto
- Criar novos produtos
- Atualizar preços
- Alertar sobre estoque baixo

#### Solução com a API

##### 1️⃣ **Listar Todos os Produtos da Loja**

```bash
curl http://localhost:3000/api/produtos
```

**Resposta:**
```json
{
  "sucesso": true,
  "total": 6,
  "dados": [
    {"id": 1, "nome": "Notebook Dell", "preco": 2500, "estoque": 5},
    {"id": 2, "nome": "Smartphone Samsung", "preco": 1200, "estoque": 15},
    // ... mais produtos
  ]
}
```

**Uso Real:** Mostrar na homepage da loja

---

##### 2️⃣ **Obter Detalhes de Um Produto (com Polimorfismo!)**

```bash
# Cliente vê um Notebook e clica para ver detalhes
curl http://localhost:3000/api/produtos/1
```

**Resposta:**
```json
{
  "sucesso": true,
  "dados": {
    "id": 1,
    "nome": "Notebook Dell",
    "preco": 2500,
    "estoque": 5,
    "voltagem": 110,
    "marca": "Dell",
    "garantiaEmMeses": 24,
    "tipo": "Eletrônico"  // ← Tipo específico
  }
}
```

```bash
# Cliente vê uma Camiseta e clica para ver detalhes
curl http://localhost:3000/api/produtos/4
```

**Resposta:**
```json
{
  "sucesso": true,
  "dados": {
    "id": 4,
    "nome": "Camiseta Básica",
    "preco": 49.90,
    "estoque": 100,
    "tamanho": "M",
    "cor": "Branco",
    "material": "Algodão",
    "colecao": "Básica",
    "tipo": "Roupa"  // ← Tipo específico (POLIMORFISMO!)
  }
}
```

**Uso Real:** Página de detalhe do produto com informações específicas

---

##### 3️⃣ **Obter Info Completa de Eletrônico (com Cálculos)**

```bash
curl http://localhost:3000/api/produtos/info/eletronico/1
```

**Resposta:**
```json
{
  "sucesso": true,
  "dados": {
    "id": 1,
    "nome": "Notebook Dell",
    "preco": 2500,
    "estoque": 5,
    "voltagem": 110,
    "marca": "Dell",
    "garantiaEmMeses": 24,
    "tipo": "Eletrônico",
    "seguro": 125,            // ← Calculado: 5% do preço
    "emGarantia": true        // ← Verificado: 30 dias de uso
  }
}
```

**Uso Real:** Oferecer seguro na compra (R$ 125 = 5% de R$ 2.500)

---

##### 4️⃣ **Obter Info Completa de Roupa (com Recomendações)**

```bash
curl http://localhost:3000/api/produtos/info/roupa/4
```

**Resposta:**
```json
{
  "sucesso": true,
  "dados": {
    "id": 4,
    "nome": "Camiseta Básica",
    "preco": 49.90,
    "estoque": 100,
    "tamanho": "M",
    "cor": "Branco",
    "material": "Algodão",
    "colecao": "Básica",
    "tipo": "Roupa",
    "desconto": 4.99,         // ← Calculado: 10% de desconto
    "cuidados": [             // ← Recomendações por material
      "Lavar em água morna",
      "Não usar alvejante",
      "Secar ao ar livre"
    ],
    "disponibilidade": "Em estoque abundante"
  }
}
```

**Uso Real:** Mostrar recomendações de lavagem e oferecer desconto

---

##### 5️⃣ **Novo Produto Chega na Loja**

Gerente adiciona novo eletrônico:

```bash
curl -X POST http://localhost:3000/api/produtos \
  -H "Content-Type: application/json" \
  -d '{
    "tipo": "Eletronico",
    "nome": "Smart TV 55 polegadas",
    "preco": 1800.00,
    "estoque": 3,
    "voltagem": 110,
    "marca": "LG",
    "garantiaEmMeses": 24
  }'
```

**Resposta:**
```json
{
  "sucesso": true,
  "mensagem": "Produto criado com sucesso",
  "dados": {
    "id": 7,  // ← ID novo atribuído automaticamente
    "nome": "Smart TV 55 polegadas",
    "preco": 1800,
    "estoque": 3,
    "voltagem": 110,
    "marca": "LG",
    "garantiaEmMeses": 24,
    "tipo": "Eletrônico"
  }
}
```

---

##### 6️⃣ **Promoção: Atualizar Preço**

Black Friday chegou! Abaixar preço do Notebook:

```bash
curl -X PUT http://localhost:3000/api/produtos/1 \
  -H "Content-Type: application/json" \
  -d '{
    "preco": 1999.00
  }'
```

**Resposta:**
```json
{
  "sucesso": true,
  "mensagem": "Produto atualizado com sucesso",
  "dados": {
    "id": 1,
    "nome": "Notebook Dell",
    "preco": 1999.00,  // ← Novo preço
    "estoque": 5,
    "voltagem": 110,
    "marca": "Dell",
    "garantiaEmMeses": 24,
    "tipo": "Eletrônico"
  }
}
```

---

##### 7️⃣ **Estoque Baixo - Alerta**

Gerente quer saber quais produtos estão com estoque baixo:

```bash
curl http://localhost:3000/api/produtos/estoque/baixo/10
```

**Resposta:**
```json
{
  "sucesso": true,
  "total": 2,
  "dados": [
    {
      "id": 1,
      "nome": "Notebook Dell",
      "preco": 1999,
      "estoque": 5,        // ← Abaixo de 10
      "statusEstoque": "BAIXO"
    },
    {
      "id": 3,
      "nome": "Cabo USB-C",
      "preco": 45,
      "estoque": 8,        // ← Abaixo de 10
      "statusEstoque": "BAIXO"
    }
  ]
}
```

**Uso Real:** Sistema envia alertas para reabastecer estoque

---

---

## 🎯 Cenário 2: Cliente Consulta Produtos

### Caso de Uso: Cliente Procura por Eletrônicos

#### 1️⃣ **Filtrar por Tipo**

Cliente quer ver apenas eletrônicos:

```bash
curl http://localhost:3000/api/produtos/tipo/Eletronico
```

**Resposta:**
```json
{
  "sucesso": true,
  "total": 3,
  "dados": [
    {"id": 1, "nome": "Notebook Dell", ...},
    {"id": 2, "nome": "Smartphone Samsung", ...},
    {"id": 3, "nome": "Cabo USB-C", ...}
  ]
}
```

---

#### 2️⃣ **Clicar em Um Eletrônico**

Cliente clica no Smartphone para ver detalhes completos:

```bash
curl http://localhost:3000/api/produtos/info/eletronico/2
```

**Resposta Completa:**
```json
{
  "sucesso": true,
  "dados": {
    "id": 2,
    "nome": "Smartphone Samsung",
    "preco": 1200,
    "estoque": 15,
    "voltagem": 110,
    "marca": "Samsung",
    "garantiaEmMeses": 12,
    "tipo": "Eletrônico",
    "seguro": 60,            // ← 5% de seguros
    "emGarantia": true       // ← Dentro da garantia
  }
}
```

**Mostra na tela:**
- Preço: R$ 1.200,00
- Seguro Oferecido: R$ 60,00
- Garantia: 12 meses
- Status: Garantia válida ✅

---

---

## 👨‍💼 Cenário 3: Desenvolvedor Consomindo a API

### Usando o Cliente JavaScript

#### Criar Cliente

```javascript
import { ClienteProdutosApi } from './cliente.js';

const cliente = new ClienteProdutosApi();
```

#### Exemplo 1: Listar e Processar

```javascript
// Obter todos os produtos
const resposta = await cliente.obterTodosProdutos();

if (resposta.sucesso) {
  console.log(`Total de produtos: ${resposta.total}`);
  
  resposta.dados.forEach(produto => {
    console.log(`${produto.nome} - R$ ${produto.preco}`);
  });
}
```

**Output:**
```
Total de produtos: 6
Notebook Dell - R$ 2500
Smartphone Samsung - R$ 1200
Cabo USB-C - R$ 45
Camiseta Básica - R$ 49.9
Calça Jeans - R$ 120
Jaqueta de Couro - R$ 350
```

---

#### Exemplo 2: Filtrar Eletrônicos

```javascript
// Obter apenas eletrônicos
const eletronicos = await cliente.obterProdutosPorTipo("Eletronico");

console.log(`Eletrônicos disponíveis: ${eletronicos.total}`);

// Calcular valor total em estoque de eletrônicos
const valorTotal = eletronicos.dados.reduce((total, produto) => {
  return total + (produto.preco * produto.estoque);
}, 0);

console.log(`Valor total de eletrônicos em estoque: R$ ${valorTotal}`);
```

**Output:**
```
Eletrônicos disponíveis: 3
Valor total de eletrônicos em estoque: R$ 68725
```

---

#### Exemplo 3: Criar e Atualizar

```javascript
// Criar novo eletrônico
const novoEletronico = await cliente.criarEletronico({
  nome: "Monitor 4K",
  preco: 2500.00,
  estoque: 5,
  voltagem: 110,
  marca: "Dell",
  garantiaEmMeses": 36
});

console.log(`Novo produto ID: ${novoEletronico.dados.id}`);

// Atualizar preço (promoção)
const produtoAtualizado = await cliente.atualizarProduto(
  novoEletronico.dados.id,
  { preco: 1999.00 }
);

console.log(`Novo preço: R$ ${produtoAtualizado.dados.preco}`);
```

---

#### Exemplo 4: Análise de Estoque

```javascript
// Obter produtos com estoque baixo
const estoqueBaixo = await cliente.obterEstoqueBaixo(20);

console.log(`Produtos com estoque baixo:`);

estoqueBaixo.dados.forEach(produto => {
  console.log(`- ${produto.nome}: ${produto.estoque} unidades`);
  
  if (produto.estoque < 5) {
    console.log("  ⚠️ URGENTE: Reabastecer!");
  }
});
```

---

---

## 🔄 Fluxo Completo: Compra de Um Eletrônico

### Passo a Passo

```
1. CLIENTE ACESSA LOJA
   ↓
   GET /api/produtos
   ← Recebe lista de 6 produtos
   
2. CLIENTE CLICA EM PRODUTO
   "Notebook Dell"
   ↓
   GET /api/produtos/1
   ← Recebe detalhes do notebook
   
3. CLIENTE VÊ OPÇÃO DE SEGURO
   ↓
   GET /api/produtos/info/eletronico/1
   ← Recebe seguro calculado (R$ 125)
   
4. CLIENTE ADICIONA AO CARRINHO
   ↓
   [Carrinho não é gerenciado pela API neste exemplo]
   
5. CLIENTE FAZ COMPRA
   ↓
   PUT /api/produtos/1
   ← Reduz estoque de 5 para 4
   {
     "estoque": 4
   }
   
6. COMPRA CONCLUÍDA
   ↓
   Novo estoque do Notebook: 4 unidades
```

---

---

## 📊 Exemplo Real: Relatório de Vendas

### Gerar Relatório Usando a API

```javascript
async function gerarRelatorioDiario() {
  const todos = await cliente.obterTodosProdutos();
  
  console.log("╔═══════════════════════════════════════╗");
  console.log("║     RELATÓRIO DE ESTOQUE DIÁRIO      ║");
  console.log("╚═══════════════════════════════════════╝\n");
  
  // Separar por tipo
  const eletronicos = todos.dados.filter(p => p.tipo === "Eletrônico");
  const roupas = todos.dados.filter(p => p.tipo === "Roupa");
  
  console.log("ELETRÔNICOS:");
  eletronicos.forEach(p => {
    const valor = p.preco * p.estoque;
    console.log(`  ${p.nome}: ${p.estoque} unid. = R$ ${valor}`);
  });
  
  console.log("\nROUPAS:");
  roupas.forEach(p => {
    const valor = p.preco * p.estoque;
    console.log(`  ${p.nome}: ${p.estoque} unid. = R$ ${valor}`);
  });
  
  // Total geral
  const total = todos.dados.reduce((sum, p) => 
    sum + (p.preco * p.estoque), 0
  );
  
  console.log(`\nVALOR TOTAL EM ESTOQUE: R$ ${total.toFixed(2)}`);
  
  // Alertas
  const baixoEstoque = await cliente.obterEstoqueBaixo(10);
  if (baixoEstoque.total > 0) {
    console.log(`\n⚠️  ${baixoEstoque.total} produtos com estoque baixo!`);
  }
}
```

**Output:**
```
╔═══════════════════════════════════════╗
║     RELATÓRIO DE ESTOQUE DIÁRIO      ║
╚═══════════════════════════════════════╝

ELETRÔNICOS:
  Notebook Dell: 5 unid. = R$ 12500
  Smartphone Samsung: 15 unid. = R$ 18000
  Cabo USB-C: 50 unid. = R$ 2250

ROUPAS:
  Camiseta Básica: 100 unid. = R$ 4990
  Calça Jeans: 80 unid. = R$ 9600
  Jaqueta de Couro: 20 unid. = R$ 7000

VALOR TOTAL EM ESTOQUE: R$ 54340.00

⚠️  2 produtos com estoque baixo!
```

---

## 🎓 Conclusão

Estes exemplos mostram como usar a API em situações reais:

✅ E-commerce gerenciando estoque
✅ Clientes consultando produtos
✅ Desenvolvedores consumindo a API
✅ Análise de dados
✅ Relatórios

A API demonstra **Programação Orientada a Objetos** e **REST** funcionando juntos em um caso real!
