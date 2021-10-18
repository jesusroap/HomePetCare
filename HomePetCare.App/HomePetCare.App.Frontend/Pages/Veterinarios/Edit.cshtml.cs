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
    public class EditModel : PageModel
    {
        private static IRepositorioVeterinario _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());

        [BindProperty]
        // Atributos
        public Veterinario veterinario {get; set;}
        public IActionResult OnGet(int? idVeterinario)
        {

            if (idVeterinario.HasValue)
            {
                veterinario = _repoVeterinario.GetVeterinario(idVeterinario.Value);                
            }
            else
            {
                veterinario = new Veterinario();
            }

            if (veterinario == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(Veterinario veterinario)
        {
            if (ModelState.IsValid)
            {
                if (veterinario.VeterinarioId > 0)
                {
                    veterinario = _repoVeterinario.UpdateVeterinario(veterinario);
                }
                else
                {
                    _repoVeterinario.AddVeterinario(veterinario);
                }
                return RedirectToPage("./List");
            }
            else
            {
                return Page();
            }
        }
    }
}
