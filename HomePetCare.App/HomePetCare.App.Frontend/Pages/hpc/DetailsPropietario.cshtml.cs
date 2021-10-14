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
    public class DetailsPropietarioModel : PageModel
    {
        private static IRepositorioPropietario _repoPropietario = new RepositorioPropietario(new Persistencia.AppContext());

        // Atributos
        public Propietario Propietario { get; set; }
        public IActionResult OnGet(int idPropietario)
        {
            Propietario = _repoPropietario.GetPropietario(idPropietario);

            if (Propietario == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }
    }
}
