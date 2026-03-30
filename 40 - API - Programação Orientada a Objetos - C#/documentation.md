# API REST com C# e POO (Controllers, Models e Services)

## Disciplina
Desenvolvimento de Sistemas

## Objetivo
Criar uma API em C# com separacao por camadas (controllers, models e services) e demonstrar conceitos de Programacao Orientada a Objetos:

- Classe abstrata
- Heranca
- Polimorfismo

Tambem foi entregue um cliente de consumo via arquivo `.http` para uso no VS Code REST Client (ou outro cliente REST como Postman/Insomnia).

---

## Estrutura Entregue

```text
40 - API - Programacao Orientada a Objetos - C#/
├── ApiPooProdutos/
│   ├── Controllers/
│   │   └── ProdutosController.cs
│   ├── Models/
│   │   ├── ProdutoBase.cs
│   │   ├── ProdutoComum.cs
│   │   ├── ProdutoEletronico.cs
│   │   ├── ProdutoRequests.cs
│   │   └── ProdutoResponse.cs
│   ├── Services/
│   │   ├── IProdutoService.cs
│   │   └── ProdutoService.cs
│   ├── ApiPooProdutos.http
│   ├── ApiPooProdutos.csproj
│   └── Program.cs
└── documentation.md
```

---

## Implementacao de POO

### Classe abstrata
`ProdutoBase` e uma classe abstrata com metodo abstrato `CalcularPrecoFinal()`.

### Heranca
`ProdutoComum` e `ProdutoEletronico` herdam de `ProdutoBase`.

### Polimorfismo
Cada classe derivada implementa sua propria regra de preco no metodo `CalcularPrecoFinal()`:

- `ProdutoComum`: retorna `PrecoBase`
- `ProdutoEletronico`: aplica `TaxaGarantia` sobre `PrecoBase`

No service, a lista e do tipo `List<ProdutoBase>`, mas os objetos concretos sao tratados polimorficamente.

---

## Endpoints da API

Base URL local (HTTP):

```text
http://localhost:5136
```

1. Listar produtos

```http
GET /api/produtos
```

2. Buscar por id

```http
GET /api/produtos/{id}
```

3. Cadastrar produto comum

```http
POST /api/produtos/comum
Content-Type: application/json

{
  "nome": "Camiseta",
  "precoBase": 79.90
}
```

4. Cadastrar produto eletronico

```http
POST /api/produtos/eletronico
Content-Type: application/json

{
  "nome": "Headset",
  "precoBase": 249.90,
  "taxaGarantia": 12
}
```

---

## Como Executar

No terminal:

```powershell
cd "D:\Luizx\Program\CEUB\3SEMESTRE\desenvolvimento-de-distemas\40 - API - Programação Orientada a Objetos - C#\ApiPooProdutos"
dotnet run
```

Swagger (habilitado em ambiente Development):

```text
http://localhost:5136/swagger
```

---

## Comandos de Consumo da API

### 1. Via arquivo .http no VS Code
Arquivo entregue:

```text
ApiPooProdutos/ApiPooProdutos.http
```

Ele contem exemplos prontos de:

- GET listar
- GET por id
- POST comum
- POST eletronico

### 2. Via PowerShell (Invoke-WebRequest)

Listar produtos:

```powershell
Invoke-WebRequest -UseBasicParsing http://localhost:5136/api/produtos
```

Buscar por id:

```powershell
Invoke-WebRequest -UseBasicParsing http://localhost:5136/api/produtos/1
```

Cadastrar produto comum:

```powershell
$body = '{"nome":"Livro","precoBase":59.90}'
Invoke-WebRequest -UseBasicParsing http://localhost:5136/api/produtos/comum -Method POST -ContentType "application/json" -Body $body
```

---

## Evidencias de Entrega

1. Projeto criado com camadas separadas:
   - Controllers
   - Models
   - Services
2. API compilando com sucesso (`dotnet build`)
3. Swagger ativo (`/swagger`)
4. Arquivo `.http` com comandos de consumo
5. POO aplicada com classe abstrata, heranca e polimorfismo

---

## Autor
Luiz