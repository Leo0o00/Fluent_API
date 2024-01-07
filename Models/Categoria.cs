﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fluent_API.Models
{
    public class Categoria
    {
        /*[Key]*/    //Estos atributos son reemplazados por las funciones de la clase OnModelCreating
        public Guid CategoriaId { get; set;}
        
        /*[Required]*/  //Hace que este campo sea requerido obligatoriamente
        /*[MaxLength(150)]*/  //Establece un maximo de caracteres para este campo
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        
        //Aqui puedo ver que tareas tiene asignada cada categoria
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
