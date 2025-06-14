using Microsoft.EntityFrameworkCore;
using Uplopper.Automapper;
using Uplopper.Data;
using Uplopper.Repositorio.IRepositorio;
using Uplopper.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<AppDbContext>(options=>
              options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSql")));

builder.Services.AddScoped<IRepository, Repository>();
//Añadimos el automapper
builder.Services.AddAutoMapper(typeof(AutoMapperUp));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Protocolo cors
builder.Services.AddCors(p => p.AddPolicy("Politica Cors", build =>
{

    build.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseCors("Politica Cors");
app.UseAuthorization();

app.MapControllers();

app.Run();
