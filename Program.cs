using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fluent_API;

var builder = WebApplication.CreateBuilder(args);
/*Con este metodo creo la base de datos en memoria*/
//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));

/*Con este metodo creo la base de datos en SqlServer.
  Los strings de conexion se obtienen de appsettings.json.
*/
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("conexionTareas"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

/*EndPoint para mostrar un mensaje si la base de datos es creada con exito*/
app.MapGet("/dbconexion", ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();

    return Results.Ok("Base de datos montada en el server: " + dbContext.Database.IsInMemory());

});

app.Run();

