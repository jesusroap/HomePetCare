using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomePetCare.App.Dominio;
using HomePetCare.App.Persistencia;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HomePetCare.App.Frontend.Pages
{
    [Authorize]
    public class EditModel : PageModel
    {
        private static IRepositorioMascota _repoMascota = new RepositorioMascota(new Persistencia.AppContext());

        [BindProperty]
        // Atributos
        public Mascota mascota { get; set; }

        public Propietario propietario { get; set; }

        // Metodos
        public IActionResult OnGet(int? idMascota)
        {
            if (idMascota.HasValue)
            {
                mascota = _repoMascota.GetMascota(idMascota.Value);                
            }
            else
            {
                mascota = new Mascota();
            }

            if (mascota == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                if (mascota.Id > 0)
                {
                    _repoMascota.UpdateMascota(mascota);
                }
                else
                {
                    _repoMascota.AddMascota(mascota);
                }
                return RedirectToPage("./Mascota");
            }
            else
            {
                return Page();
            }
        }
    }
}
