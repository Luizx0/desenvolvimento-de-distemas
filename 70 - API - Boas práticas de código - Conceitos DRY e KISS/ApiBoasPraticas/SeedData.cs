using ApiBoasPraticas.Data;
using ApiBoasPraticas.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiBoasPraticas
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            // Verifica se já existem dados
            if (context.Pessoas.Any())
            {
                return; // DB já foi populado
            }

            // Dados iniciais para demonstração
            var pessoas = new List<Pessoa>
            {
                new Pessoa
                {
                    Nome = "João Silva",
                    Cpf = "123.456.789-09",
                    DataNascimento = new DateTime(1985, 5, 15)
                },
                new Pessoa
                {
                    Nome = "Maria Santos",
                    Cpf = "987.654.321-00",
                    DataNascimento = new DateTime(1990, 8, 22)
                },
                new Pessoa
                {
                    Nome = "Pedro Oliveira",
                    Cpf = "111.222.333-44",
                    DataNascimento = new DateTime(1982, 12, 3)
                }
            };

            context.Pessoas.AddRange(pessoas);
            context.SaveChanges();
        }
    }
}