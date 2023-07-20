using WiflyBetApi;
using WiflyBetApi.Interfaces;
using WiflyBetApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IBanco, Banco>();
builder.Services.AddSingleton<IDiretorDeBanca, DiretorDeBanca>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
