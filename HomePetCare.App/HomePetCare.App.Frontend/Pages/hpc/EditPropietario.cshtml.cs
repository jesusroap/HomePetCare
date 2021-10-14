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
    public class EditPropietarioModel : PageModel
    {
        private static IRepositorioMascota _repoMascota = new RepositorioMascota(new Persistencia.AppContext());

        private static IRepositorioPropietario _repoPropietario = new RepositorioPropietario(new Persistencia.AppContext());

        [BindProperty]
        // Atributos
        public Mascota mascota { get; set; }
        public Propietario propietario {get; set;}
        public IActionResult OnGet(int? idPropietario)
        {

            if (idPropietario.HasValue)
            {
                propietario = _repoPropietario.GetPropietario(idPropietario.Value);                
            }
            else
            {
                propietario = new Propietario();
            }

            if (propietario == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(Propietario propietario)
        {
            if (ModelState.IsValid)
            {
                if (propietario.Id > 0)
                {
                    propietario = _repoPropietario.UpdatePropietario(propietario);
                }
                else
                {
                    _repoPropietario.AddPropietario(propietario);
                }
                return RedirectToPage("./Propietario");
            }
            else
            {
                return Page();
            }
        }
    }
}
