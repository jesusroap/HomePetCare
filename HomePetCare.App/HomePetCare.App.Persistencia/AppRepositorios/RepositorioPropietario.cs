using System;
using System.Collections.Generic;
using System.Linq;
using HomePetCare.App.Dominio;

namespace HomePetCare.App.Persistencia
{
    public class RepositorioPropietario : IRepositorioPropietario
    {
        /// <summary>

        /// </summary>
        private readonly AppContext _appContext;

        /// <summary>

        /// </summary>
        /// <param name="appContext"></param>

        public RepositorioPropietario(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Propietario AddPropietario(Propietario propietario)
        {
            var propietarioAdicionado = _appContext.Propietarios.Add(propietario);
            _appContext.SaveChanges();
            return propietarioAdicionado.Entity;
        }

        public void DeletePropietario(int idPropietario)
        {
            var proietarioEncontrado = _appContext.Propietarios.FirstOrDefault(p => p.Id == idPropietario);

            if (proietarioEncontrado == null)
                return;
            _appContext.Propietarios.Remove(proietarioEncontrado);
            _appContext.SaveChanges();
        }

        public IEnumerable<Propietario> GetAllPropietarios()
        {
            return _appContext.Propietarios;
        }

        public Propietario GetPropietario(int idPropietario)
        {
            return _appContext.Propietarios.FirstOrDefault(p => p.Id == idPropietario);
        }

        public IEnumerable<Propietario> GetPropietariosPorFiltro(string filtro = null)
        {
            var propietarios = GetAllPropietarios();

            if (propietarios != null)
            {
                if (!String.IsNullOrEmpty(filtro))
                {
                    propietarios = propietarios.Where(s => s.Nombre.Contains(filtro)); 
                    /// <summary>
                    /// Filtra los mensajes que contienen el filtro
                    /// </summary>
                }
            }
            return propietarios;
        }

        public Propietario UpdatePropietario(Propietario propietario)
        {
            var propietarioEncontrado = _appContext.Propietarios.FirstOrDefault(p => p.Id == propietario.Id);

            if (propietarioEncontrado != null)
            {
                propietarioEncontrado.Identificacion = propietario.Identificacion;
                propietarioEncontrado.Nombre = propietario.Nombre;
                propietarioEncontrado.Apellido = propietario.Apellido;
                propietarioEncontrado.Direccion = propietario.Direccion;
                propietarioEncontrado.Telefono = propietario.Telefono;

                _appContext.SaveChanges();
            }

            return propietarioEncontrado;
        }
    }
}