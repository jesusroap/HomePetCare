using System.Collections.Generic;
using HomePetCare.App.Dominio;

namespace HomePetCare.App.Persistencia
{
    public interface IRepositorioPropietario
    {
        IEnumerable<Propietario> GetAllPropietarios();
        IEnumerable<Propietario> GetPropietariosPorFiltro(string filtro);
        Propietario AddPropietario(Propietario propietario);
        Propietario UpdatePropietario(Propietario propietario);
        void DeletePropietario(int idPropietario);
        Propietario GetPropietario(int idPropietario);
    }
}