using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Fluent_API.Models
{
    public class Tarea
    {
        /*[Key]*/ //Estos atributos son reemplazados por las funciones de la clase OnModelCreating
        public Guid TareaId { get; set; }
        
        /*[ForeignKey("CategoriaId")]*/ //Esta es una llave foranea ya que pertenece a otra clase
        public Guid CategoriaId { get; set; }
        
        /*[Required]*/  //Hace que este campo sea requerido obligatoriamente
        /*[MaxLength(200)]*/  //Establece un maximo de caracteres para este campo
        public String Titulo { get; set; }

        public Prioridad PrioridadTarea { get; set; }

        public DateTime FechaCreacion { get; set; }

        //Con esta linea le asigno a cada tarea una categoria y a su vez puedo solicitar una tarea por su categoria asignada 
        public virtual Categoria  Categoria { get; set; }  


        //Utilizando Fluent API se puede eliminar este atributo ya que bastaria con no agregarlo al objeto TareasContext.OnModelCreating() para que esta propiedad no sea agregada a la base de datos
        /*[NotMapped]*/   //Anotacion para evitar que este campo sea almacenado en la base de datos
        [JsonIgnore]
        public string Resumen {get; set;}
    }

    public enum Prioridad
    {
        Baja,

        Media,

        Alta,
    }
}

