using System;

class Program
{
    static void Main(string[] args)
    {
        string nomeCompleto = "Luiz Felipe Cerqueira de Araujo";
        DateTime dataNascimento = new DateTime(2007, 03, 16);

        Console.WriteLine(nomeCompleto);
        Console.WriteLine(dataNascimento.ToString("dd/MM/yyyy"));
    }
}