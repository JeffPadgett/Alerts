using Alerts.Api.Services;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Alerts.Test")]//All this does is help us get the dependencies in our test project. 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IKeyVaultService, KeyVaultService>();
builder.Services.AddSingleton<AppSecrets>();
builder.Services.AddHostedService<KeyVaultLoaderService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }