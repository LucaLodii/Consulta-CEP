// Everything hear was done automatically by Visual Studio (besides the lines 11-13)
using ConsultaCep.Domain.Interfaces;
using ConsultaCep.Infrastructure.Adapters;
using ConsultaCep.Application.UseCases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<ICepService, ViaCepAdapter>();
builder.Services.AddScoped<ConsultarCepUseCase>();
builder.Services.AddHttpClient<ViaCepAdapter>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

