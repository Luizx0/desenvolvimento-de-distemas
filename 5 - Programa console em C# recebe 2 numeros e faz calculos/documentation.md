```markdown id="k3s9dx"
# 📌 Calculadora Console em C# (.NET)

Este projeto é uma aplicação console desenvolvida em C# utilizando a plataforma .NET.

---

## 🎯 Objetivo

O programa tem como objetivo:

- Solicitar ao usuário dois números
- Perguntar qual operação matemática deseja realizar
- Exibir o resultado da operação

---

## 🛠️ Tecnologias utilizadas

- .NET (CLI)
- C#
- Aplicação Console

---

## 📂 Estrutura do projeto

```

CalculadoraConsole/
├── Program.cs
├── CalculadoraConsole.csproj
└── README.md

````id="t5b0h8"

---

## 💻 Código-fonte

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Digite o primeiro número:");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Digite o segundo número:");
        double num2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Escolha a operação (+, -, *, /):");
        string operacao = Console.ReadLine();

        double resultado = 0;

        switch (operacao)
        {
            case "+":
                resultado = num1 + num2;
                break;
            case "-":
                resultado = num1 - num2;
                break;
            case "*":
                resultado = num1 * num2;
                break;
            case "/":
                if (num2 != 0)
                    resultado = num1 / num2;
                else
                {
                    Console.WriteLine("Erro: divisão por zero!");
                    return;
                }
                break;
            default:
                Console.WriteLine("Operação inválida!");
                return;
        }

        Console.WriteLine($"Resultado: {resultado}");
    }
}
````

---

## ▶️ Como executar o projeto

### 1. Criar o projeto

```bash id="wkl6pj"
dotnet new console -n CalculadoraConsole
cd CalculadoraConsole
```

### 2. Substituir o código

Edite o arquivo `Program.cs` com o código fornecido acima.

### 3. Executar

```bash id="nrc2fa"
dotnet run
```

---

## 🖥️ Exemplo de uso

````
Digite o primeiro número:
10
Digite o segundo número:
5
Escolha a operação (+, -, *, /):
*
Resultado: 50
``` id="62pq3v"

---

## ⚠️ Validações implementadas

- Verificação de divisão por zero
- Tratamento de operação inválida

---

## 📝 Observações

- O programa interage com o usuário em Português do Brasil
- Os valores são convertidos utilizando `Convert.ToDouble`
- A operação é definida por meio de uma estrutura `switch`

---

## ✅ Conclusão

O projeto atende aos requisitos propostos, permitindo a interação com o usuário e realizando operações matemáticas básicas de forma simples e eficiente.

---

## 👨‍💻 Autor

- Luizx0
````
