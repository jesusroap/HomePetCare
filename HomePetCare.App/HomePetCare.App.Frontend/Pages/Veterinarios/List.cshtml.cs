using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomePetCare.App.Dominio;
using HomePetCare.App.Persistencia;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomePetCare.App.Frontend.Pages.Veterinarios
{
    [Authorize]
    public class ListModel : PageModel
    {
        private static IRepositorioVeterinario _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());

        // Atributos
        [BindProperty(SupportsGet = true)]
        public string FiltroBusqueda { get; set; }

        public IEnumerable<Veterinario> Veterinarios {get; set;}

        public Veterinario Veterinario { get; set; }

        public void OnGet(int idVeterinario, string filtroBusqueda)
        {
            FiltroBusqueda = filtroBusqueda;

            Veterinarios = _repoVeterinario.GetVeterinarioPorFiltro(filtroBusqueda); 

            Veterinario = _repoVeterinario.GetVeterinario(idVeterinario);
            if (Veterinario == null)
            {
                RedirectToPage("./NotFound");
            }
            else
            {
                _repoVeterinario.DeleteVeterinario(Veterinario.VeterinarioId);
                Page();
            } 
        }
    }
}
