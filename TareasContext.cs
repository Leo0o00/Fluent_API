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
            modelBuilder.Entity<Categoria>(categoria=>{
                categoria.ToTable("Categoria");
                categoria.HasKey(p=> p.CategoriaId);
                categoria.Property(p=> p.Nombre).IsRequired().HasMaxLength(150);
                categoria.Property(p=> p.Descripcion);
                
            });
            modelBuilder.Entity<Tarea>(tarea=>{
                tarea.ToTable("Tarea");
                tarea.HasKey(p=> p.TareaId);
                tarea.HasOne(P=> P.Categoria).WithMany(p=> p.Tareas).HasForeignKey(p=> p.CategoriaId); //Equivale al atributo ForeingKey
                tarea.Property(p=> p.Titulo).IsRequired().HasMaxLength(200);
                tarea.Property(p=> p.PrioridadTarea);
                tarea.Property(p=> p.FechaCreacion);
                tarea.Ignore(p=> p.Resumen);  //Con esta funcion se fuerza a Entity Framework a no crear este campo en la tabla



            });
        }
    
    }


}