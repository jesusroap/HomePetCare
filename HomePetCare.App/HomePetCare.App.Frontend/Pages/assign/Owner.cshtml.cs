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
    public class OwnerModel : PageModel
    {
        private static IRepositorioMascota _repoMascota = new RepositorioMascota(new Persistencia.AppContext());

        private static IRepositorioPropietario _repoPropietario = new RepositorioPropietario(new Persistencia.AppContext());

        [BindProperty]
        // Atributos
        public Mascota mascota { get; set; }

        public Propietario propietario { get; set; }

        public IEnumerable<Propietario> propietarios {get; set;}

        // Metodos
        public IActionResult OnGet(int? idMascota)
        {
            propietarios = _repoPropietario.GetAllPropietarios();

            if (idMascota.HasValue)
            {
                mascota = _repoMascota.GetMascota(idMascota.Value);                
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

        public IActionResult OnPost(Mascota mascota, int propietarioId)
        {
            if (ModelState.IsValid)
            {
                propietario = _repoPropietario.GetPropietario(propietarioId);

                if (mascota.Id > 0)
                {
                    if (propietario != null)
                    {
                        mascota.Propietario = propietario;
                        _repoMascota.UpdateMascota(mascota);
                    }
                }

                return RedirectToPage("/hpc/Mascota");
            }
            else
            {
                return Page();
            }
        }
    }
}
