using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomePetCare.App.Dominio;
using HomePetCare.App.Persistencia;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomePetCare.App.Frontend.Pages.Assigns
{
    [Authorize]
    public class Assign2Model : PageModel
    {
        private readonly IRepositorioMascota _repoMascota;

        private static IRepositorioPropietario _repoPropietario = new RepositorioPropietario(new Persistencia.AppContext());

        private static IRepositorioVeterinario _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());

        [BindProperty]
        // Atributos
        public Mascota mascota { get; set; }

        public Propietario propietario { get; set; }

        public Veterinario veterinario { get; set; }

        public IEnumerable<Propietario> propietarios {get; set;}

        public IEnumerable<Veterinario> veterinarios {get; set;}

        public Assign2Model()
        {
            this._repoMascota = new RepositorioMascota(new HomePetCare.App.Persistencia.AppContext());
        }

        // Metodos
        public void OnGet(int? idMascota)
        {
            propietarios = _repoPropietario.GetAllPropietarios();
            veterinarios = _repoVeterinario.GetAllVeterinarios();

            if (idMascota.HasValue)
            {
                mascota = _repoMascota.GetMascota(idMascota.Value);                
            }

            if (mascota == null)
            {
                RedirectToPage("./NotFound");
            }
            else
            {
                // propietarios = _repoMascota.GetPropietario(idMascota.Value);
            }

        }

        public IActionResult OnPost(Mascota mascota, int propietarioId, int veterinarioId)
        {
            if (ModelState.IsValid)
            {
                propietario = _repoPropietario.GetPropietario(propietarioId);
                veterinario = _repoVeterinario.GetVeterinario(veterinarioId);

                if (mascota.Id > 0)
                {
                    mascota.Veterinario = veterinario;
                    mascota.Propietario = propietario;
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
