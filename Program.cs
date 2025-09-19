using Backend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Conexion de la base datos
var conexion = builder.Configuration.GetConnectionString("cn");
builder.Services.AddDbContext<RestauranteDbContext>(
    op => op.UseMySql(conexion, ServerVersion.Parse("5.7.24")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Agregar los Cors

builder.Services.AddCors(options =>
{
    options.AddPolicy("SistemaGR",

        credendicales =>
        {
            credendicales.WithOrigins("http://localhost:4200") // Especifica los orígenes permitidos
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("SistemaGR");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
