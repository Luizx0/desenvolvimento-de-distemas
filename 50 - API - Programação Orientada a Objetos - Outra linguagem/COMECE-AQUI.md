# 👋 COMECE AQUI! 

Bem-vindo ao projeto de **API de Produtos com Programação Orientada a Objetos em JavaScript**!

Este arquivo o guiará para começar rapidamente. ⏱️ **Tempo: 2 minutos**

---

## 🎯 O Que Você Vai Encontrar Aqui

Uma **API REST completa** em JavaScript que demonstra:
- ✅ Classes e Objetos
- ✅ Herança
- ✅ Polimorfismo
- ✅ CRUD (Create, Read, Update, Delete)
- ✅ Arquitetura Cliente-Servidor

---

## 📚 Arquivos de Documentação

### 📄 **Escolha Seu Nível**

#### ⚡ **Começar AGORA** (3 minutos)
👉 Leia: **[README.md](./README.md)**
- Instruções rápidas
- Instalação e execução
- Endpoints principais

#### 📖 **Aprender Passo a Passo** (15 minutos)
👉 Leia: **[guia-execucao-evidencias.md](./guia-execucao-evidencias.md)**
- Tutorial completo
- Como testar
- Exemplos de requisições
- Solução de problemas

#### 📚 **Aprofundar** (30 minutos)
👉 Leia: **[documentation.md](./documentation.md)**
- Documentação completa
- Conceitos POO explicados
- Todos os endpoints
- Fluxo de dados

#### 💡 **Ver Exemplos Práticos** (10 minutos)
👉 Leia: **[EXEMPLOS-PRATICOS.md](./EXEMPLOS-PRATICOS.md)**
- Cenários reais
- E-commerce
- Cliente consumindo API
- Casos de uso

#### 📋 **Referência Rápida**
👉 Leia: **[INDEX.md](./INDEX.md)** - Índice completo

👉 Leia: **[ESTRUTURA.txt](./ESTRUTURA.txt)** - Mapa visual

👉 Leia: **[RESUMO-ENTREGA.md](./RESUMO-ENTREGA.md)** - O que foi entregue

---

## 🚀 Executar em 3 Minutos

### Passo 1: Terminal

Abra um terminal e navegue para a pasta:

```bash
cd ApiProdutosJs
```

### Passo 2: Instalar

```bash
npm install
```

*Aguarde ~30 segundos*

### Passo 3: Atualizar

```bash
npm start
```

Você verá:
```
🚀 API de Produtos com POO em JavaScript
Servidor rodando em http://localhost:3000
```

---

## 🧪 Testar em 2 Minutos

### Opção 1: VSCode (RECOMENDADO)

1. Abra o arquivo: `ApiProdutosJs.http`
2. Clique em "Send Request" (abaixo de qualquer requisição)
3. Veja a resposta no painel lateral

**Você precisa:**
- Extensão "REST Client" instalada no VSCode
- [Instale aqui](https://marketplace.visualstudio.com/items?itemName=humao.rest-client)

### Opção 2: Terminal

```bash
curl http://localhost:3000/api/produtos
```

### Opção 3: Navegador

Abra: `http://localhost:3000`

---

## 🎓 Conceitos POO

### Classes
```javascript
class Produto { }
```
Define a estrutura básica

### Herança
```javascript
class Eletronico extends Produto { }
```
Estende a classe Produto com propriedades específicas

### Polimorfismo
```javascript
// Mesmo método, comportamentos diferentes
produto.obterDescricao()
eletronico.obterDescricao()  // ← Resultado diferente!
roupa.obterDescricao()       // ← Resultado diferente!
```

---

## 📂 Estrutura Simplificada

```
ApiProdutosJs/
├── models/          ← Classes (Produto, Eletronico, Roupa)
├── controllers/     ← Lógica CRUD
├── routes/          ← Endpoints HTTP
├── server.js        ← Servidor
└── cliente.js       ← Cliente exemplo
```

**Mais detalhes:** Leia [ESTRUTURA.txt](./ESTRUTURA.txt)

---

## 🔥 Endpoints Principais

```
GET    /api/produtos              Listar todos
GET    /api/produtos/:id          Obter um
POST   /api/produtos              Criar novo
PUT    /api/produtos/:id          Atualizar
DELETE /api/produtos/:id          Deletar
```

**Todos os endpoints:** Veja [documentation.md](./documentation.md#-endpoints-da-api)

---

## ✅ Verificação Rápida

Após iniciar o servidor, teste:

```bash
# 1. Servidor está rodando?
curl http://localhost:3000

# 2. API funcionando?
curl http://localhost:3000/api/produtos

# 3. Pode criar?
curl -X POST http://localhost:3000/api/produtos \
  -H "Content-Type: application/json" \
  -d '{"tipo":"Produto","nome":"Teste","preco":99,"estoque":5}'
```

---

## 🎬 Próximos Passos

### Para Iniciantes
1. ✅ Execute `npm start`
2. ✅ Teste 3 requisições no `ApiProdutosJs.http`
3. 📖 Leia [README.md](./README.md)
4. 📚 Leia [EXEMPLOS-PRATICOS.md](./EXEMPLOS-PRATICOS.md)

### Para Aprender POO
1. 📚 Leia [documentation.md](./documentation.md)
2. 💻 Abra `models/Produto.js`
3. 💻 Abra `models/Eletronico.js`
4. 💻 Abra `models/Roupa.js`
5. 🔍 Estude a herança e polimorfismo

### Para Integrar em Projeto
1. ✅ Copie a pasta `ApiProdutosJs` para seu projeto
2. ✅ Execute `npm install`
3. ✅ Estude [controllers/ProdutoController.js](./ApiProdutosJs/controllers/ProdutoController.js)
4. ✅ Expanda para seus próprios tipos de produtos

---

## ❓ Dúvidas Comuns

### P: Qual porta a API usa?
**R:** Porta `3000` - `http://localhost:3000`

### P: Preciso de Node.js instalado?
**R:** Sim! [Baixe aqui](https://nodejs.org/) versão LTS

### P: Posso rodar no Postman?
**R:** Sim! Você pode usar Postman, Insomnia ou cURL

### P: Os dados são salvos?
**R:** Não, são em memória. Reinicia ao restartar o servidor

### P: Como adicionar novo tipo de produto?
**R:** Crie novo arquivo em `models/`, estenda `Produto`, sobrescreva os métodos

---

## 🆘 Problemas?

### Erro: "Cannot find module 'express'"
```bash
npm install
```

### Erro: "EADDRINUSE: address already in use :::3000"
```bash
# Porta 3000 está ocupada
# Opção 1: Use outra porta
# Opção 2: Mate o processo usando a porta
```

**Mais problemas?** Veja [guia-execucao-evidencias.md](./guia-execucao-evidencias.md#-solução-de-problemas)

---

## 📞 Navegação Rápida

| Se você quer... | Leia... | Tempo |
|-----------------|---------|-------|
| Começar já | README.md | 3 min |
| Executar passo-a-passo | guia-execucao-evidencias.md | 15 min |
| Aprender tudo | documentation.md | 30 min |
| Ver exemplos | EXEMPLOS-PRATICOS.md | 10 min |
| Entender estrutura | ESTRUTURA.txt | 5 min |
| Ver índice | INDEX.md | 5 min |
| Ver resumo | RESUMO-ENTREGA.md | 5 min |

---

## 🎯 Seu Primeiro Teste

### Teste 1: Listar Produtos

**No VSCode:**
1. Abra `ApiProdutosJs.http`
2. Encontre "GET http://localhost:3000/api/produtos"
3. Clique em "Send Request"
4. Veja 6 produtos na resposta ✅

**No Terminal:**
```bash
curl http://localhost:3000/api/produtos
```

### Teste 2: Obter Eletrônico com Info Específica

**No VSCode:**
1. Encontre "GET http://localhost:3000/api/produtos/info/eletronico/1"
2. Clique em "Send Request"
3. Note o campo "seguro" (calculado!) ✅

Isso é **POLIMORFISMO** em ação!

---

## ✨ O Que Torna Este Projeto Especial

✅ **POO Real** - Classes, herança, polimorfismo
✅ **Bem Organizado** - Estrutura profissional
✅ **Bem Documentado** - 2500+ linhas de docs
✅ **Exemplos Práticos** - 21 testes prontos
✅ **Fácil de Usar** - 3 passos para rodar
✅ **Pronto para Aprender** - Código comentado
✅ **Extensível** - Fácil adicionar novos tipos

---

## 🏁 Resumo

| Item | Descrição |
|------|-----------|
| **Linguagem** | JavaScript (Node.js) |
| **Framework** | Express.js |
| **Conceitos** | POO (Classes, Herança, Polimorfismo) |
| **Endpoints** | 12 endpoints REST |
| **CRUD** | Completo (Create, Read, Update, Delete) |
| **Documentação** | 2500+ linhas |
| **Exemplos** | 21 testes prontos |
| **Tempo Execução** | 3 minutos |

---

## 🚀 Pronto para Começar?

### Opção 1: Rápido (3 min)
```bash
cd ApiProdutosJs
npm install
npm start
```
Depois abra `ApiProdutosJs.http` no VSCode

### Opção 2: Aprender (30 min)
Leia `documentation.md` primeiro

### Opção 3: Exemplos (15 min)
Leia `EXEMPLOS-PRATICOS.md` primeiro

---

## 💬 Bem-vindo!

Você está prestes a aprender:
- ✅ Programação Orientada a Objetos
- ✅ Desenvolvimento de APIs REST
- ✅ Arquitetura Cliente-Servidor
- ✅ Boas práticas de código

**Divirta-se explorando! 🎉**

---

<div align="center">

**Escolha um caminho abaixo:**

[⚡ RÁPIDO](./README.md) | [📖 TUTORIAL](./guia-execucao-evidencias.md) | [📚 COMPLETO](./documentation.md) | [💡 EXEMPLOS](./EXEMPLOS-PRATICOS.md)

---

**Disciplina**: Desenvolvimento de Sistemas
**Data**: Abril 2026
**Status**: ✅ Pronto para usar

</div>
