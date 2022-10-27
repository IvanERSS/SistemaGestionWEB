using SistemaGestionWEB.Models;
using SistemaGestionWEB.Repository;
using System;
using System.Collections.Immutable;

//PRUEBAS

//Producto x = ProductoRepository.Get(11);
//x.Usuario.ID = 4;
//x.Usuario = UsuarioRepository.Get(1);
//Console.WriteLine(ProductoRepository.Modificar(x));


/* TEST
Dictionary<Producto,int> list = new Dictionary<Producto, int>();
Random random = new Random();
List<Producto> products = new List<Producto>();
products = ProductoRepository.Get();

for (int i=0; i<6;i++)
{
    list.Add(products[i],random.Next(1,5));
}
list.Add(ProductoRepository.Get(11), random.Next(1, 5));

foreach (var x in list)
{
    Console.WriteLine(x.Key.ToString()+" "+x.Value+"\n");
}
Console.WriteLine("\n\nSALTO DE LINEA\n\n");

var order = from data in list orderby data.Key.Usuario.ID ascending select data;

foreach (var x in order)
{
    Console.WriteLine(x.Key.ToString() + " " + x.Value + "\n");
}
*/
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

