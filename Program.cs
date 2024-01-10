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

/*EndPoint utilizado para el consumo de datos*/
app.MapGet("/api/tareas", ([FromServices] TareasContext dbContext) => {
  /*Con la funcion "Where" puedo establecer un filtro de resultados para cuando se le realice la peticion a la base de datos, en este caso se pretende mostrar solo las tareas que tengan prioridad baja*/
  //return Results.Ok(dbContext.Tareas.Where(p=> p.PrioridadTarea == Fluent_API.Models.Prioridad.Baja));
  
  /*Aqui se añade la funcion "Include" para que ademas se muestre los campos pertenecientes a la tarea contenidos en el modelo Categorias*/
  return Results.Ok(dbContext.Tareas.Include(p=> p.Categoria).Where(p=> p.PrioridadTarea == Fluent_API.Models.Prioridad.Baja));

});
app.Run();

