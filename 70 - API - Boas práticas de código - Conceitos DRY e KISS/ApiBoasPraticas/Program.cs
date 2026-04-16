using ApiBoasPraticas.Data;
using ApiBoasPraticas.Services;
using ApiBoasPraticas.Models.Validacao;
using ApiBoasPraticas.DTOs;
using ApiBoasPraticas;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configuração do banco de dados PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Injeção de dependências - Serviços DRY
builder.Services.AddScoped<ICpfValidator, CpfValidator>();
builder.Services.AddScoped<IValidacaoService, ValidacaoService>();
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<IPessoaService, PessoaService>();

// Serviço de violação (apenas para demonstração)
builder.Services.AddScoped<PessoaServiceViolacao>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Inicializar dados do banco (apenas em desenvolvimento)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        SeedData.Initialize(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Erro ao inicializar dados do banco de dados.");
    }
}

app.Run();
