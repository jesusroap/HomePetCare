using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomePetCare.App.Dominio;
using HomePetCare.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomePetCare.App.Frontend.Pages.Veterinarios
{
    public class DetailsModel : PageModel
    {
        private static IRepositorioVeterinario _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());

        // Atributos
        public Veterinario Veterinario { get; set; }
        public IActionResult OnGet(int idVeterinario)
        {
            Veterinario = _repoVeterinario.GetVeterinario(idVeterinario);

            if (Veterinario == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }
    }
}
