using Microsoft.EntityFrameworkCore;
using ApiBoasPraticas.Models;

namespace ApiBoasPraticas.Data
{
    /// <summary>
    /// Contexto do Entity Framework - Demonstra boas práticas
    /// Configuração centralizada do banco de dados
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }

        /// <summary>
        /// Configuração do modelo
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da entidade Pessoa
            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Nome)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(p => p.Cpf)
                    .IsRequired()
                    .HasMaxLength(14);

                entity.Property(p => p.DataNascimento)
                    .IsRequired();

                entity.Property(p => p.CriadoEm)
                    .IsRequired()
                    .HasDefaultValueSql("NOW()");

                // Índice único no CPF para evitar duplicatas
                entity.HasIndex(p => p.Cpf)
                    .IsUnique();
            });

            // Dados iniciais para demonstração
            modelBuilder.Entity<Pessoa>().HasData(
                new Pessoa
                {
                    Id = 1,
                    Nome = "João Silva",
                    Cpf = "123.456.789-09",
                    DataNascimento = new DateTime(1990, 5, 15),
                    CriadoEm = new DateTime(2024, 1, 1)
                },
                new Pessoa
                {
                    Id = 2,
                    Nome = "Maria Santos",
                    Cpf = "987.654.321-00",
                    DataNascimento = new DateTime(1985, 8, 22),
                    CriadoEm = new DateTime(2024, 1, 1)
                },
                new Pessoa
                {
                    Id = 3,
                    Nome = "Pedro Oliveira",
                    Cpf = "111.222.333-44",
                    DataNascimento = new DateTime(1995, 12, 10),
                    CriadoEm = new DateTime(2024, 1, 1)
                }
            );
        }
    }
}