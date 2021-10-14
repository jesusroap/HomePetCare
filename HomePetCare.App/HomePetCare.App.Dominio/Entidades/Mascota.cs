using System;

namespace HomePetCare.App.Dominio
{
    public class Mascota
    {
        // Atributos
        public int Id {get; set;}
        public string Nombre {get; set;}
        public int Temperatura {get; set;}
        public int Peso {get; set;}
        public string FrecuenciaRespiratoria {get; set;}
        public string FrecuenciaCardiaca {get; set;}
        public string EstadoAnimo {get; set;}
        public Veterinario Veterinario {get; set;}
        public Visita Visita {get; set;}
        public Propietario Propietario {get; set;}
    }
}