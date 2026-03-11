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