```markdown
# Documentação – API REST em C# com Cliente Console

## Disciplina
Desenvolvimento de Sistemas

## Objetivo

Compreender o funcionamento da **arquitetura cliente-servidor** e o uso do **protocolo HTTP**, por meio da implementação de uma **API REST utilizando C# e .NET**, que retorna dados fictícios e pode ser consumida por um **cliente console utilizando HttpClient**.

---

# Descrição da atividade

Nesta atividade foi desenvolvida uma **API REST utilizando ASP.NET Core** que disponibiliza endpoints para consulta de dados fictícios.

Também foi criado um **cliente console em C#** responsável por realizar requisições HTTP para consumir os dados disponibilizados pela API.

Além do cliente console, a API também pode ser testada utilizando ferramentas de consumo de API como:

- Swagger
- REST Client (VS Code)
- Postman
- Insomnia

---

# Arquitetura Cliente-Servidor

A aplicação segue o modelo **cliente-servidor**, no qual existe uma separação clara entre quem fornece os dados e quem os consome.

## Servidor

O servidor é responsável por:

- Receber requisições HTTP
- Processar as requisições
- Retornar respostas em formato JSON

Tecnologias utilizadas:

- C#
- .NET
- ASP.NET Core Web API

A API expõe endpoints REST que podem ser acessados por qualquer cliente HTTP.

---

## Cliente

O cliente é responsável por:

- Enviar requisições HTTP para a API
- Receber e processar as respostas

Tecnologias utilizadas:

- C#
- Aplicação Console
- HttpClient

---

# Estrutura do projeto

```

api-cliente-servidor
│
├── ApiUsuarios
│   ├── Controllers
│   │   └── UsuariosController.cs
│   ├── Program.cs
│   └── ApiUsuarios.csproj
│
├── ClienteConsole
│   ├── Program.cs
│   └── ClienteConsole.csproj
│
└── README.md

```

Descrição:

- **ApiUsuarios/** → projeto da API REST
- **ClienteConsole/** → aplicação console que consome a API
- **README.md** → documentação do projeto

---

# Funcionamento da API

A API disponibiliza endpoints para consulta de usuários fictícios.

## Listar usuários

Endpoint:

```

GET /usuarios

````

Descrição:

Retorna uma lista de usuários fictícios.

Exemplo de resposta:

```json
[
  {
    "id": 1,
    "nome": "Ana",
    "idade": 22
  },
  {
    "id": 2,
    "nome": "Carlos",
    "idade": 30
  },
  {
    "id": 3,
    "nome": "Maria",
    "idade": 25
  }
]
````

---

## Buscar usuário por ID

Endpoint:

```
GET /usuarios/{id}
```

Exemplo:

```
GET /usuarios/1
```

Resposta esperada:

```json
{
  "id": 1,
  "nome": "Ana",
  "idade": 22
}
```

---

# Cliente Console

O cliente console foi desenvolvido para consumir os endpoints da API utilizando a classe **HttpClient**.

Fluxo de funcionamento:

1. O cliente envia uma requisição HTTP para a API.
2. A API processa a requisição.
3. A API retorna os dados em formato JSON.
4. O cliente recebe os dados e exibe no console.

Exemplo de consumo da API:

```csharp
using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        HttpClient client = new HttpClient();

        var response = await client.GetAsync("http://localhost:5000/usuarios");

        var data = await response.Content.ReadAsStringAsync();

        Console.WriteLine(data);
    }
}
```

---

# Como executar o projeto

## 1. Executar a API

Entrar na pasta da API:

```
cd ApiUsuarios
```

Executar:

```
dotnet run
```

A API será iniciada e ficará disponível em um endereço local, por exemplo:

```
http://localhost:5000
```

---

## 2. Testar a API com Swagger

O Swagger permite testar os endpoints diretamente pelo navegador.

Acessar:

```
http://localhost:5000/swagger
```

---

## 3. Executar o cliente console

Entrar na pasta do cliente:

```
cd ClienteConsole
```

Executar:

```
dotnet run
```

O cliente realizará a requisição para a API e exibirá os dados retornados no console.

---

# Teste manual da API

Além do cliente console, a API pode ser testada utilizando ferramentas externas.

## REST Client (VS Code)

Exemplo de requisição:

```
GET http://localhost:5000/usuarios
```

---

## Postman / Insomnia

Criar uma requisição:

```
GET http://localhost:5000/usuarios
```

Enviar a requisição e visualizar a resposta JSON.

---

# Conceitos aplicados

Durante o desenvolvimento desta atividade foram aplicados os seguintes conceitos:

* Arquitetura cliente-servidor
* Protocolo HTTP
* API REST
* Requisições HTTP
* Serialização e retorno de dados em JSON
* Consumo de APIs utilizando HttpClient
* Aplicações console em C#

---

# Conclusão

A atividade permitiu compreender o funcionamento da comunicação entre cliente e servidor utilizando o protocolo HTTP.

Foi possível observar como uma **API REST pode disponibilizar dados** e como um **cliente pode consumir esses dados utilizando requisições HTTP**, reforçando conceitos fundamentais para o desenvolvimento de sistemas distribuídos.

---

# Autor

Luiz
Disciplina: Desenvolvimento de Sistemas