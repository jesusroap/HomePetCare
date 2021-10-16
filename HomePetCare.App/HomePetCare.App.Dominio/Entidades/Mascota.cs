using System;
using System.ComponentModel.DataAnnotations;

namespace HomePetCare.App.Dominio
{
    public class Mascota
    {
        // Atributos
        public int Id {get; set;}

        [Required(ErrorMessage = "El campo {0} es requerido"), StringLength(50)]
        public string Nombre {get; set;}

        [Range(1, int.MaxValue, ErrorMessage = "El valor de la {0} es requerido")]
        public int Temperatura {get; set;}

        [Range(1, int.MaxValue, ErrorMessage = "El valor del {0} es requerido")]
        public int Peso {get; set;}

        [Required(ErrorMessage = "El campo {0} es requerido"), StringLength(50)]
        public string FrecuenciaRespiratoria {get; set;}

        [Required(ErrorMessage = "El campo {0} es requerido"), StringLength(50)]
        public string FrecuenciaCardiaca {get; set;}

        [Required(ErrorMessage = "El campo {0} es requerido"), StringLength(50)]
        public string EstadoAnimo {get; set;}
        public Veterinario Veterinario {get; set;}
        public Visita Visita {get; set;}
        public Propietario Propietario {get; set;}
    }
}