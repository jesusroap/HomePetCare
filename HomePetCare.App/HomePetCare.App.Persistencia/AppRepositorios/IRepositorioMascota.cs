using System.Collections.Generic;
using HomePetCare.App.Dominio;

namespace HomePetCare.App.Persistencia
{
    public interface IRepositorioMascota
    {
        IEnumerable<Mascota> GetAllMascotas();
        IEnumerable<Mascota> GetMascotaPorFiltro(string filtro);
        Mascota AddMascota(Mascota mascota);
        Mascota UpdateMascota(Mascota mascota);
        void DeleteMascota(int idMascota);
        Mascota GetMascota(int idMascota);

        // IEnumerable<Propietario> GetPropietario(int idMascota);
    }
}