using CDatos.Contexts;
using CDatos.Repositories.Contracts;
using CDatos.Repositories.Implementations;
using CLogica.Contracts;
using CLogica.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<IAnimalLogic, AnimalLogic>();
builder.Services.AddScoped<IAtencionRepository, AtencionRepository>();
builder.Services.AddScoped<IAtencionLogic, AtencionLogic>();
builder.Services.AddScoped<IDuenioRepository, DuenioRepository>();
builder.Services.AddScoped<IDuenioLogic, DuenioLogic>(); 
builder.Services.AddScoped<ITipoRepository, TipoRepository>();
builder.Services.AddScoped<ITipoLogic, TipoLogic>();

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

app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();