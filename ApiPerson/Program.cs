using ApiPerson.Data;
using Microsoft.EntityFrameworkCore;

// Crio a aplicação
var builder = WebApplication.CreateBuilder(args);

// Configurações básicas
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSwaggerGen();

// Construo a aplicação
var app = builder.Build();

// Configuração do Swagger (para testar a API)
app.UseSwagger();
app.UseSwaggerUI();

// Configurações da API
app.UseHttpsRedirection();
app.MapControllers();

// Roda!
app.Run();