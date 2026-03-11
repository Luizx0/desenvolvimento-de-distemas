# Atividade – API REST e Arquitetura Cliente-Servidor

## Disciplina
Desenvolvimento de Sistemas

## Objetivo

Compreender o funcionamento da **arquitetura cliente-servidor** e o uso do **protocolo HTTP**, através da implementação de uma **API REST** que retorna dados fictícios e de um cliente que consome esses dados.

---

# Descrição da atividade

Nesta atividade foi desenvolvida uma **API REST utilizando JavaScript com Node.js e Express**.

A API disponibiliza endpoints para:

- Listar usuários
- Buscar usuário por ID
- Criar novos usuários

Também foi criado um **cliente console** que consome os endpoints da API utilizando requisições HTTP.

Além do cliente console, a API pode ser testada manualmente utilizando ferramentas como:

- REST Client (VS Code)
- Postman
- Insomnia
- Navegador (para requisições GET)

---

# Arquitetura Cliente-Servidor

A aplicação segue o modelo **cliente-servidor**, onde:

### Servidor
Responsável por disponibilizar os endpoints da API e responder às requisições HTTP.

Tecnologias utilizadas:

- Node.js
- Express

### Cliente
Responsável por realizar requisições HTTP para a API e consumir os dados retornados.

Exemplos de clientes utilizados:

- Aplicação console em JavaScript
- REST Client (VS Code)
- Postman
- Insomnia

---

# Estrutura do projeto

```

atividade01-api-http
│
├── api
│   ├── server.js
│   └── package.json
│
├── cliente
│   └── cliente.js
│
└── requests.http

```

Descrição das pastas:

- **api/** → contém o código da API REST
- **cliente/** → aplicação console que consome a API
- **requests.http** → arquivo para testes utilizando REST Client

---

# Endpoints da API

## Listar usuários

```

GET /usuarios

````

Retorna uma lista de usuários fictícios.

Exemplo de resposta:

```json
[
  { "id": 1, "nome": "Ana", "idade": 22 },
  { "id": 2, "nome": "Carlos", "idade": 30 },
  { "id": 3, "nome": "Maria", "idade": 25 }
]
````

---

## Buscar usuário por ID

```
GET /usuarios/{id}
```

Exemplo:

```
GET /usuarios/1
```

---

## Criar usuário

```
POST /usuarios
```

Body da requisição:

```json
{
  "nome": "João",
  "idade": 28
}
```

Resposta esperada:

```json
{
  "id": 4,
  "nome": "João",
  "idade": 28
}
```

---

# Como executar o projeto

## 1. Instalar dependências

Dentro da pasta da API executar:

```
npm install
```

---

## 2. Iniciar o servidor

```
node server.js
```

Servidor disponível em:

```
http://localhost:3000
```

---

## 3. Consumir a API

A API pode ser consumida de diferentes formas.

### Navegador

```
http://localhost:3000/usuarios
```

---

### Cliente console

Executar o cliente:

```
node cliente.js
```

---

### REST Client / Postman / Insomnia

Exemplo de requisição:

```
GET http://localhost:3000/usuarios
```

---

# Conceitos aplicados

* Arquitetura cliente-servidor
* Protocolo HTTP
* API REST
* Requisições HTTP (GET e POST)
* Manipulação de dados em JSON
* Consumo de API

---

# Autor

Luiz
Disciplina: Desenvolvimento de Sistemas

