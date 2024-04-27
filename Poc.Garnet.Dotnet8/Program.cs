using Poc.Garnet.Dotnet8.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIoc();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerSettings();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
