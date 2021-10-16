using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomePetCare.App.Dominio;
using HomePetCare.App.Persistencia;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomePetCare.App.Frontend.Pages
{
    [Authorize]
    public class PropietarioModel : PageModel
    {
        private static IRepositorioPropietario _repoPropietario = new RepositorioPropietario(new Persistencia.AppContext());

        // Atributos
        [BindProperty(SupportsGet = true)]
        public string FiltroBusqueda { get; set; }

        public IEnumerable<Propietario> Propietarios {get; set;}

        public Propietario Propietario { get; set; }

        public void OnGet(int idPropietario, string filtroBusqueda)
        {
            FiltroBusqueda = filtroBusqueda;

            Propietarios = _repoPropietario.GetPropietariosPorFiltro(filtroBusqueda); 

            Propietario = _repoPropietario.GetPropietario(idPropietario);
            if (Propietario == null)
            {
                RedirectToPage("./NotFound");
            }
            else
            {
                _repoPropietario.DeletePropietario(Propietario.Id);
                Page();
            } 
        }
    }
}
