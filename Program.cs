using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fluent_API;
using Fluent_API.Models;
using System.ComponentModel.DataAnnotations.Schema;

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

/*EndPoint utilizado para el consumo de datos (Obtener datos de la base de datos)*/
app.MapGet("/api/tareas_obtener", ([FromServices] TareasContext dbContext) => {
  /*Con la funcion "Where" puedo establecer un filtro de resultados para cuando se le realice la peticion a la base de datos, en este caso se pretende mostrar solo las tareas que tengan prioridad baja*/
  //return Results.Ok(dbContext.Tareas.Where(p=> p.PrioridadTarea == Fluent_API.Models.Prioridad.Baja));
  
  /*Aqui se añade la funcion "Include" para que ademas se muestre los campos pertenecientes a la tarea contenidos en el modelo Categorias*/
  //return Results.Ok(dbContext.Tareas.Include(p=> p.Categoria).Where(p=> p.PrioridadTarea == Fluent_API.Models.Prioridad.Baja));
  
  return Results.Ok(dbContext.Tareas.Include(p=> p.Categoria));
  //return Results.Ok(dbContext.Tareas);

});
/*EndPoint utilizado para el consumo de datos (Guardar nuevos datos de la base de datos)*/
app.MapPost("/api/tareas_guardar", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) => {
  
  tarea.TareaId = Guid.NewGuid();
  tarea.FechaCreacion = DateTime.Now;
  await dbContext.AddAsync(tarea);
  //await dbContext.Tareas.AddAsync(tarea);  //Otra via
  await dbContext.SaveChangesAsync();
  
  return Results.Ok();

});

/*EndPoint utilizado para el consumo de datos (Actualizar los datos de la base de datos)
  Recibira el ID desde la ruta de acceso(enlace) y los datos a actualizar se recibiran desde el body*/
app.MapPut("/api/tareas_actualizar/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id) => {
  
  var tareaActual = dbContext.Tareas.Find(id); //Para hacer la busqueda de los elementos basandose en los campos marcados por el atributo [Key]
  
  /*En caso de que el ID exista se ejecutaran los metodos contenidos dentro deL IF
    en caso contrario se mostrara un mensaje de Error HTTP 404*/
  if(tareaActual!=null){
    tareaActual.CategoriaId = tarea.CategoriaId;
    tareaActual.Titulo = tarea.Titulo;
    tareaActual.PrioridadTarea = tarea.PrioridadTarea;
    tareaActual.Descripcion = tarea.Descripcion;
  
    await dbContext.SaveChangesAsync();
    return Results.Ok();
  }
  return Results.NotFound();

});

app.MapDelete("/api/tareas_eliminar/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid id) => {
  
  var tareaActual = dbContext.Tareas.Find(id); //Para hacer la busqueda de los elementos basandose en los campos marcados por el atributo [Key]
  
  if(tareaActual!=null){
  
    dbContext.Remove(tareaActual);
    await dbContext.SaveChangesAsync();
    return Results.Ok();
  }
  return Results.NotFound();

});

app.Run();