using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomePetCare.App.Dominio;
using HomePetCare.App.Persistencia;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomePetCare.App.Frontend.Pages.Assign
{
    [Authorize]
    public class VetModel : PageModel
    {
        private static IRepositorioMascota _repoMascota = new RepositorioMascota(new Persistencia.AppContext());

        private static IRepositorioVeterinario _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());

        private static IRepositorioPropietario _repoPropietario = new RepositorioPropietario(new Persistencia.AppContext());

        [BindProperty]
        // Atributos
        public Mascota mascota { get; set; }
        public Propietario propietario {get; set;}
        public Veterinario veterinario {get; set;}

        public IEnumerable<Veterinario> veterinarios {get; set;}

        public IEnumerable<Propietario> propietarios {get; set;}

        // Metodos
        public IActionResult OnGet(int? idMascota)
        {
            veterinarios = _repoVeterinario.GetAllVeterinarios();
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

        public IActionResult OnPost(Mascota mascota, int veterinarioId, int propietarioId)
        {
            if (ModelState.IsValid)
            {
                veterinario = _repoVeterinario.GetVeterinario(veterinarioId);
                propietario = _repoPropietario.GetPropietario(propietarioId);

                if (mascota.Id > 0)
                {
                    mascota.Propietario = propietario;
                    mascota.Veterinario = veterinario;
                    _repoMascota.UpdateMascota(mascota);
                }

                return RedirectToPage("/Mascotas/List");
            }
            else
            {
                return Page();
            }
        }
    }
}
