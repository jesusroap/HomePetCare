using System;
using HomePetCare.App.Dominio;
using HomePetCare.App.Persistencia;

namespace HomePetCare.App.Consola
{
    class Program
    {
        private static IRepositorioMascota _repoMascota = new RepositorioMascota(new Persistencia.AppContext());

        private static IRepositorioPropietario _repoPropietario = new RepositorioPropietario(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // AddMascota();
            // BuscarMascota(3);
            // ListaMascotas();
            AddPropietario();
            // AsignarPropietarioMascota(3, 2);
        }

        private static void AddMascota()
        {

            var mascota = new Mascota
            {
                Nombre = "Rufo",
                Temperatura = 36
            };
            _repoMascota.AddMascota(mascota);
        }

        private static void BuscarMascota(int idMascota)
        {
            var mascota = _repoMascota.GetMascota(idMascota);
            Console.WriteLine(mascota.Nombre);
            Console.WriteLine(mascota.Temperatura);

            Console.WriteLine(mascota.Propietario.Nombre);
        }
        
        private static void ListaMascotas()
        {
            var mascotas = _repoMascota.GetAllMascotas();
            
            foreach (var mascota in mascotas)
            {
                Console.WriteLine(mascota.Nombre);
                Console.WriteLine(mascota.Temperatura);
            }     
        }

        // private static void AsignarVeterinario()
        // {
        //     var veterinario = _repoMascota.AsignarVeterinario(1, 2);
        //     Console.WriteLine(veterinario.Nombre + " " + veterinario.Apellidos);
        // }

        private static void AddMascotaConMedico()
        {
            var propietario = new Propietario
            {
                Nombre = "Jesus"
            };

            var mascota = new Mascota
            {
                Nombre = "Rufo",
                Temperatura = 36,
                Propietario = propietario
            };
            _repoMascota.AddMascota(mascota);
        }

        private static void AddPropietario()
        {

            var propietario = new Propietario
            {
                Identificacion = "111111",
                Nombre = "Maria",
                Apellido = "Gutierrez",
                Direccion = "Calle 12",
                Telefono = "3124563214"
            };
            _repoPropietario.AddPropietario(propietario);
        }

        private static void AsignarPropietarioMascota(int idMascota, int idPropietario)
        {
            var mascota = _repoMascota.GetMascota(idMascota);
            var propietario = _repoPropietario.GetPropietario(idPropietario);

            if (mascota != null)
            {
                if (propietario != null)
                {
                    mascota.Propietario = propietario;
                }
                _repoMascota.UpdateMascota(mascota);
            }
        }
    }
}
