```markdown
# 📌 Projeto Console em C# (.NET)

Este é um projeto simples de aplicação console desenvolvido em C# utilizando a plataforma .NET.

## 🎯 Objetivo

O programa tem como objetivo:

- Exibir o nome completo do usuário
- Exibir a data de nascimento no formato **dd/MM/aaaa**

---

## 🛠️ Tecnologias utilizadas

- .NET (CLI)
- C#
- Aplicação Console

---

## 📂 Estrutura do projeto

```

MeuPrograma/
├── Program.cs
├── MeuPrograma.csproj
└── README.md

````

---

## 💻 Código-fonte

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        string nomeCompleto = "Seu Nome Completo";
        DateTime dataNascimento = new DateTime(2000, 1, 1);

        Console.WriteLine(nomeCompleto);
        Console.WriteLine(dataNascimento.ToString("dd/MM/yyyy"));
    }
}
````

---

## ▶️ Como executar o projeto

### 1. Criar o projeto

```bash
dotnet new console -n MeuPrograma
cd MeuPrograma
```

### 2. Substituir o código

Edite o arquivo `Program.cs` com o código fornecido.

### 3. Executar

```bash
dotnet run
```

---

## 🖥️ Saída esperada

```
Seu Nome Completo
01/01/2000
```

---

## 📝 Observações

* Altere o valor da variável `nomeCompleto` para o seu nome real.
* Ajuste a data de nascimento conforme necessário.
* A formatação da data é feita utilizando `ToString("dd/MM/yyyy")`.

---

## ✅ Conclusão

Este projeto demonstra a criação e execução de um programa console simples em C#, utilizando conceitos básicos como variáveis, tipos de dados e saída no console.

---

## 👨‍💻 Autor

* Luizx0

```