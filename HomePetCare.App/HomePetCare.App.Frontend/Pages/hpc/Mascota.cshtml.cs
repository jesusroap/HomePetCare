using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomePetCare.App.Dominio;
using HomePetCare.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomePetCare.App.Frontend.Pages
{
    public class MascotaModel : PageModel
    {
        private static IRepositorioMascota _repoMascota = new RepositorioMascota(new Persistencia.AppContext());

        // Atributos
        [BindProperty(SupportsGet = true)]
        public string FiltroBusqueda { get; set; }

        public IEnumerable<Mascota> Mascotas {get; set;}

        public Mascota Mascota { get; set; }

        // Metodos
        public void OnGet(int idMascota, string filtroBusqueda)
        {
            // Filtro de mascotas
            FiltroBusqueda = filtroBusqueda;
            Mascotas = _repoMascota.GetMascotaPorFiltro(filtroBusqueda); 

            // Eliminacion de mascotas
            Mascota = _repoMascota.GetMascota(idMascota);
            if (Mascota == null)
            {
                RedirectToPage("./NotFound");
            }
            else
            {
                _repoMascota.DeleteMascota(Mascota.Id);
                Page();
            }           
        }
    }
}
