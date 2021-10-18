using System.Collections.Generic;
using HomePetCare.App.Dominio;

namespace HomePetCare.App.Persistencia
{
    public interface IRepositorioVeterinario
    {
        IEnumerable<Veterinario> GetAllVeterinarios();
        IEnumerable<Veterinario> GetVeterinarioPorFiltro(string filtro);
        Veterinario AddVeterinario(Veterinario veterinario);
        Veterinario UpdateVeterinario(Veterinario veterinario);
        void DeleteVeterinario(int idVeterinario);
        Veterinario GetVeterinario(int idVeterinario);
    }
}