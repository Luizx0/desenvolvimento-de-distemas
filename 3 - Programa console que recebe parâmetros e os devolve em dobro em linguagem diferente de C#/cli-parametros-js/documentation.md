# Aplicação CLI em JavaScript – Parâmetros em Dobro

## Disciplina
Desenvolvimento de Sistemas

## Objetivo

Desenvolver uma **aplicação console em JavaScript (CLI - Command Line Interface)** capaz de receber **parâmetros pela linha de comando**, calcular o **dobro da quantidade de parâmetros recebidos** e imprimir **cada parâmetro duas vezes no console**.

O objetivo da atividade é compreender como aplicações console podem **receber argumentos de execução** através da linha de comando em uma linguagem diferente de C#.

---

## Descrição da aplicação

A aplicação foi desenvolvida utilizando **Node.js e JavaScript**.

O programa utiliza `process.argv`, um array disponibilizado pelo Node.js que contém todos os parâmetros informados quando o programa é executado.

A lógica do programa realiza as seguintes operações:

1. Recebe os parâmetros enviados pela linha de comando via `process.argv.slice(2)`.
2. Calcula a quantidade de parâmetros recebidos usando `.length`.
3. Calcula o dobro dessa quantidade.
4. Imprime o resultado no console.
5. Imprime cada parâmetro recebido duas vezes usando um loop.

---

## Estrutura do projeto

```
3 - Programa console que recebe parâmetros e os devolve em dobro em linguagem diferente de C#/
│
└── cli-parametros-js/
    ├── index.js
    ├── package.json
    └── documentation.md
```

Descrição dos arquivos:

- **index.js** → contém a implementação do programa.
- **package.json** → arquivo de configuração do projeto Node.js.
- **documentation.md** → documentação do projeto.

---

## Código principal

Arquivo **index.js**

```javascript
#!/usr/bin/env node

// Obtém os parâmetros passados pela linha de comando
// process.argv começa com ["node", "arquivo.js", param1, param2, ...]
// Removemos os 2 primeiros elementos para pegar apenas os parâmetros do usuário
const parametros = process.argv.slice(2);

// Calcula a quantidade de parâmetros recebidos
const quantidade = parametros.length;

// Calcula o dobro da quantidade
const dobro = quantidade * 2;

// Imprime o resultado
console.log(`Quantidade de parâmetros recebidos: ${quantidade}`);
console.log(`Dobro da quantidade: ${dobro}`);
console.log();

// Imprime cada parâmetro duas vezes
console.log("Parâmetros duplicados:");

for (const parametro of parametros) {
    console.log(parametro);
    console.log(parametro);
}
```

---

## Como executar o projeto

### Pré-requisitos

- Node.js instalado (versão 12 ou superior)

### Executando o programa

#### Opção 1: Executar com `node`

```bash
cd cli-parametros-js
node index.js parametro1 parametro2 parametro3
```

#### Opção 2: Executar com `npm`

```bash
cd cli-parametros-js
npm start -- parametro1 parametro2 parametro3
```

---

## Exemplo de execução

### Entrada:

```bash
node index.js a b c
```

### Saída no console:

```
Quantidade de parâmetros recebidos: 3
Dobro da quantidade: 6

Parâmetros duplicados:
a
a
b
b
c
c
```

---

## Comparação com C#

| Aspecto | C# | JavaScript |
|--------|----|----|
| Classe de entrada | `Program` com método `Main` | Executado diretamente no escopo global |
| Array de parâmetros | `string[] args` | `process.argv` (após slice(2)) |
| Obter quantidade | `args.Length` | `parametros.length` |
| Loop | `foreach (var p in args)` | `for (const p of parametros)` |
| Imprimir no console | `Console.WriteLine()` | `console.log()` |
| Executar | `dotnet run param1 param2` | `node index.js param1 param2` |

---

## Conceitos aplicados

* Aplicações console em JavaScript/Node.js
* Parâmetros de linha de comando (CLI)
* Uso de `process.argv`
* Manipulação de arrays (`.slice()` e `.length`)
* Estruturas de repetição (`for...of`)
* Template literals (backticks para interpolação)
* Entrada e saída no console (`console.log()`)

---

## Autor

Luiz

Disciplina: Desenvolvimento de Sistemas
