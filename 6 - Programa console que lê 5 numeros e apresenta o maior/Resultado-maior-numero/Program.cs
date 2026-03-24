using System;

class Program
{
    static void Main()
    {
        int[] numeros = new int[5];

        // Ler os 5 números
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Digite o {i + 1}º número:");
            numeros[i] = Convert.ToInt32(Console.ReadLine());
        }

        // Determinar o maior número
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