using WiflyBetApi.Interfaces;
using WiflyBetApi.Models;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(o => { o.SwaggerDoc("v1", new OpenApiInfo { Title = "API de estudo WiflyBet", Version = "v1" }); });
builder.Services.AddSingleton<IBanco, Banco>();
builder.Services.AddSingleton<IDiretorDeBanca, DiretorDeBanca>();


var app = builder.Build();

//Swagger configuração
app.UseSwagger();
app.UseSwaggerUI(o => o.SwaggerEndpoint("/swagger/v1/swagger.json", "API Wiflybet"));

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
