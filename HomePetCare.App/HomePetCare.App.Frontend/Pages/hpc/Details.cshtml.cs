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
    public class DetailsModel : PageModel
    {
        private static IRepositorioMascota _repoMascota = new RepositorioMascota(new Persistencia.AppContext());

        // Atributos
        public Mascota Mascota { get; set; }
        
        // Metodos
        public IActionResult OnGet(int idMascota)
        {
            Mascota = _repoMascota.GetMascota(idMascota);

            if (Mascota == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }
    }
}
