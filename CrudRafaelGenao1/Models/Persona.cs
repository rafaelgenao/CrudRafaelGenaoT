using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudRafaelGenao1.Models
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos  {2} y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name ="Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El cargo es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos  {2} y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Cargo")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatorio")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime FechaDeNacimiento { get; set; }

        [Required(ErrorMessage = "La empresa es obligatorio")]
        public string Empresa { get; set; }

        [Required(ErrorMessage = "El Sueldo es obligatorio")]
        public int Sueldo { get; set; }
    }
}
