
---

# Documentação – Localizador de Maior Número em C#

## Disciplina
Desenvolvimento de Sistemas

## Objetivo

Compreender a aplicação de **estruturas de repetição e condicionais**, além da manipulação de **arrays** na linguagem C#, por meio da implementação de um algoritmo que identifica o maior valor entre uma série de entradas fornecidas pelo usuário via console.

---

# Descrição da atividade

Nesta atividade foi desenvolvida uma **aplicação de console utilizando .NET** que interage com o usuário para a coleta de dados numéricos.

O foco da implementação foi o uso eficiente de coleções (arrays) e a lógica de comparação para processamento de dados em tempo de execução.

O programa segue o fluxo padrão de entrada, processamento e saída:
- **Entrada:** Captura de 5 números inteiros.
- **Processamento:** Iteração sobre o array para comparação de valores.
- **Saída:** Exibição do maior número identificado.

---

# Lógica do Algoritmo

A aplicação utiliza uma estrutura lógica fundamental para a busca de valores máximos em conjuntos de dados.

## Captura de Dados

O programa utiliza um laço `for` para preencher um array de tamanho fixo:
- O método `Console.ReadLine()` captura a entrada.
- O método `Convert.ToInt32()` realiza o parsing para o tipo inteiro.

## Processamento (Busca do Maior)

A estratégia adotada consiste em:
1. Definir o primeiro elemento como a referência inicial (`maior`).
2. Percorrer os demais elementos comparando-os com a referência.
3. Atualizar a referência sempre que um número superior for encontrado.

---

# Estrutura do projeto

```text
projeto-maior-numero
│
├── Program.cs          # Código fonte principal com a lógica do sistema
├── MaiorNumero.csproj  # Arquivo de configuração do projeto .NET
└── README.md           # Documentação do projeto
```

Descrição:
- **Program.cs** → Contém a implementação do laço de leitura e o algoritmo de comparação.
- **MaiorNumero.csproj** → Manifesto do projeto que define a versão do framework (ex: .NET 6.0 ou 8.0).

---

# Funcionamento do Programa

O programa interage com o usuário solicitando entradas sequenciais.

## Exemplo de Execução

Ao rodar a aplicação, o usuário deverá inserir os valores conforme solicitado:

```text
Digite o 1º número: 10
Digite o 2º número: 25
Digite o 3º número: 7
Digite o 4º número: 18
Digite o 5º número: 3
```

## Resultado Esperado

Após a última entrada, o sistema processa o array e retorna:

```text
O maior número é: 25
```

---

# Implementação do Código

O trecho abaixo destaca a implementação da lógica central no arquivo `Program.cs`:

```csharp
using System;

class Program
{
    static void Main()
    {
        int[] numeros = new int[5];

        // Coleta de dados
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Digite o {i + 1}º número:");
            numeros[i] = Convert.ToInt32(Console.ReadLine());
        }

        // Algoritmo de busca do maior valor
        int maior = numeros[0];
        for (int i = 1; i < 5; i++)
        {
            if (numeros[i] > maior)
            {
                maior = numeros[i];
            }
        }

        Console.WriteLine($"O maior número é: {maior}");
    }
}
```

---

# Como executar o projeto

## 1. Abrir o terminal
Navegue até a pasta onde o arquivo `Program.cs` está localizado.

## 2. Compilar e Executar
Utilize o comando do CLI do .NET:

```bash
dotnet run
```

## 3. Interação
Insira os 5 números solicitados e pressione **Enter** após cada um para visualizar o resultado final.

---

# Conceitos aplicados

Durante o desenvolvimento desta atividade foram aplicados os seguintes conceitos:

* Declaração e manipulação de Arrays (`int[]`)
* Estruturas de Repetição (`for`)
* Estruturas Condicionais (`if`)
* Entrada e Saída de dados (`Console.ReadLine` / `Console.WriteLine`)
* Conversão de tipos de dados (Casting/Conversion)
* Lógica de programação e algoritmos de busca

---

# Conclusão

A atividade permitiu consolidar o conhecimento sobre o tratamento de coleções de dados em C#. 

Através da implementação, foi possível compreender como algoritmos de ordenação e busca simples funcionam na prática, reforçando a importância da lógica estruturada para a resolução de problemas computacionais comuns no desenvolvimento de sistemas.

---

# Autor

Luiz  
Disciplina: Desenvolvimento de Sistemas

---

