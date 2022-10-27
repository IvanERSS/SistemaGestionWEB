using SistemaGestionWEB.Models;
using SistemaGestionWEB.Repository;

//PRUEBAS

//Producto x = ProductoRepository.Get(11);
//x.Usuario.ID = 4;
//x.Usuario = UsuarioRepository.Get(1);
//Console.WriteLine(ProductoRepository.Modificar(x));

//FIN DE PRUEBAS


var builder = WebApplication.CreateBuilder(args);

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

