using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluent_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Fluent_API
{
    public class TareasContext: DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        public TareasContext(DbContextOptions<TareasContext> options) :base(options) {}


        //Con este objeto se sobreescriben los atributos de los campos de sus respectivas tablas en la carpeta Models 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Categoria> categoriasIniciales = new List<Categoria>(); //Lista creada para enunciar los Datos Semilla y los campos que los rquieran 
            /*En el primer dato semilla CategoriaID:
              -Con esta funcion se le asigna un id a la propiedad CategoriaID
              -No se deberia usar el metodo Guid.NewGuid() por si solo, ya que generaria un ID nuevo cada vez que EntityFramework ejecute este objeto y haga la comparacion entre el modelo actual y el que ha recivido cambios,por lo tanto,
              se generaran los codigos Guid utilizando alguna de las paginas que existen para generar estos codigos
              */
            categoriasIniciales.Add(new Categoria() { CategoriaId = Guid.Parse("907f7cf7-7d85-4c28-9ad0-7c6eb70235eb"), Nombre = "Actividades Pendientes", Peso = 20, Descripcion = "Esta es una descripcion"});
            categoriasIniciales.Add(new Categoria() { CategoriaId = Guid.Parse("907f7cf7-7d85-4c28-9ad0-7c6eb70236eb"), Nombre = "Actividades Personales", Peso = 50, Descripcion = "Esta es una descripcion"});

            modelBuilder.Entity<Categoria>(categoria=>{
                categoria.ToTable("Categoria");
                categoria.HasKey(p=> p.CategoriaId);
                categoria.Property(p=> p.Nombre).IsRequired().HasMaxLength(150);
                categoria.Property(p=> p.Descripcion).IsRequired(false); //Permite que el campo contenga valores nulos en la base de datos
                categoria.Property(p=> p.Peso);
                categoria.HasData(categoriasIniciales); //Indica que los campos contenidos en la lista categoriasIniciales poseen Datos Semilla
                
            });

            List<Tarea> tareasIniciales = new List<Tarea>(); //Lista creada para enunciar los Datos Semilla y los campos que los rquieran 
            tareasIniciales.Add(new Tarea() { TareaId = Guid.Parse("907f7cf7-7d85-4d28-9ad0-7c6eb71235eb"), CategoriaId = Guid.Parse("907f7cf7-7d85-4c28-9ad0-7c6eb70235eb"), Titulo = "Tareas Pendientes", PrioridadTarea = Prioridad.Alta, FechaCreacion = DateTime.Now});
            tareasIniciales.Add(new Tarea() { TareaId = Guid.Parse("907f7cf7-8d85-4c29-9ad0-7c6eb70236eb"), CategoriaId = Guid.Parse("907f7cf7-7d85-4c28-9ad0-7c6eb70236eb"), Titulo = "Tareas Personales", PrioridadTarea = Prioridad.Baja, FechaCreacion = DateTime.Now});

            modelBuilder.Entity<Tarea>(tarea=>{
                tarea.ToTable("Tarea");
                tarea.HasKey(p=> p.TareaId);
                tarea.HasOne(P=> P.Categoria).WithMany(p=> p.Tareas).HasForeignKey(p=> p.CategoriaId); //Equivale al atributo ForeingKey
                tarea.Property(p=> p.Titulo).IsRequired().HasMaxLength(200);
                tarea.Property(p=> p.PrioridadTarea);
                tarea.Property(p=> p.FechaCreacion);
                tarea.Ignore(p=> p.Resumen);  //Con esta funcion se fuerza a Entity Framework a no crear este campo en la tabla
                tarea.HasData(tareasIniciales); //Indica que los campos contenidos en la lista tareasIniciales poseen Datos Semilla



            });
        }
    
    }


}


