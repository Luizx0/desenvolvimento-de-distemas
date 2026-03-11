```markdown
# Aplicação CLI em C# – Parâmetros em Dobro

## Disciplina
Desenvolvimento de Sistemas

## Objetivo

Desenvolver uma **aplicação console em C# (CLI - Command Line Interface)** capaz de receber **parâmetros pela linha de comando**, calcular o **dobro da quantidade de parâmetros recebidos** e imprimir **cada parâmetro duas vezes no console**.

O objetivo da atividade é compreender como aplicações console podem **receber argumentos de execução** através da linha de comando.

---

# Descrição da aplicação

A aplicação foi desenvolvida utilizando **.NET e C#**.

O programa utiliza o array `args`, que é disponibilizado automaticamente no método `Main`, contendo todos os parâmetros informados quando o programa é executado.

A lógica do programa realiza as seguintes operações:

1. Recebe os parâmetros enviados pela linha de comando.
2. Calcula a quantidade de parâmetros recebidos.
3. Calcula o dobro dessa quantidade.
4. Imprime o resultado no console.
5. Imprime cada parâmetro recebido duas vezes.

---

# Estrutura do projeto

```

cli-parametros
│
├── Program.cs
├── cli-parametros.csproj
└── README.md

````

Descrição dos arquivos:

- **Program.cs** → contém a implementação do programa.
- **cli-parametros.csproj** → arquivo de configuração do projeto .NET.
- **README.md** → documentação do projeto.

---

# Código principal

Arquivo **Program.cs**

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        int quantidade = args.Length;
        int dobro = quantidade * 2;

        Console.WriteLine($"Quantidade de parâmetros recebidos: {quantidade}");
        Console.WriteLine($"Dobro da quantidade: {dobro}");
        Console.WriteLine();

        Console.WriteLine("Parâmetros duplicados:");

        foreach (var parametro in args)
        {
            Console.WriteLine(parametro);
            Console.WriteLine(parametro);
        }
    }
}
````

---

# Como executar o projeto

## 1. Criar o projeto

```bash
dotnet new console -n cli-parametros
```

---

## 2. Entrar na pasta do projeto

```bash
cd cli-parametros
```

---

## 3. Executar o programa com parâmetros

Exemplo:

```bash
dotnet run a b c
```

---

# Exemplo de execução

Entrada:

```
dotnet run a b c
```

Saída no console:

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

# Conceitos aplicados

* Aplicações console em C#
* Parâmetros de linha de comando (CLI)
* Uso do array `args`
* Estruturas de repetição (`foreach`)
* Manipulação de entrada e saída no console

---

# Autor

Luiz
Disciplina: Desenvolvimento de Sistemas

```
```
