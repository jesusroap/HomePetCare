using System;
using System.ComponentModel.DataAnnotations;

namespace HomePetCare.App.Dominio
{
    public class Propietario
    {
        // Atributos
        public int Id {get; set;}

        [Required(ErrorMessage = "El campo {0} es requerido"), StringLength(50)]
        public string Identificacion {get; set;}

        [Required(ErrorMessage = "El campo {0} es requerido"), StringLength(50)]
        public string Nombre {get; set;}

        [Required(ErrorMessage = "El campo {0} es requerido"), StringLength(50)]
        public string Apellido {get; set;}

        [Required(ErrorMessage = "El campo {0} es requerido"), StringLength(50)]
        public string Direccion {get; set;}

        [Required(ErrorMessage = "El campo {0} es requerido"), StringLength(50)]
        public string Telefono {get; set;}
    }
}