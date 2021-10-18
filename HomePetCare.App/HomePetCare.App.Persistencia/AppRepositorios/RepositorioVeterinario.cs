using System;
using System.Collections.Generic;
using System.Linq;
using HomePetCare.App.Dominio;

namespace HomePetCare.App.Persistencia
{
    public class RepositorioVeterinario : IRepositorioVeterinario
    {
        private readonly AppContext _appContext;

        /// <summary>
        /// <param name="appContext"></param>
        /// </summary>

        public RepositorioVeterinario(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Veterinario AddVeterinario(Veterinario veterinario)
        {
            var veterinarioAdicionado = _appContext.Veterinarios.Add(veterinario);
            _appContext.SaveChanges();
            return veterinarioAdicionado.Entity;
        }

        public void DeleteVeterinario(int idVeterinario)
        {
            var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(p => p.VeterinarioId == idVeterinario);

            if (veterinarioEncontrado == null)
                return;
            _appContext.Veterinarios.Remove(veterinarioEncontrado);
            _appContext.SaveChanges();
        }

        public IEnumerable<Veterinario> GetAllVeterinarios()
        {
            return _appContext.Veterinarios;
        }

        public Veterinario GetVeterinario(int idVeterinario)
        {
            return _appContext.Veterinarios.FirstOrDefault(p => p.VeterinarioId == idVeterinario);
        }

        public IEnumerable<Veterinario> GetVeterinarioPorFiltro(string filtro = null)
        {
            var veterinarios = GetAllVeterinarios();

            if (veterinarios != null)
            {
                if (!String.IsNullOrEmpty(filtro))
                {
                    veterinarios = veterinarios.Where(s => s.Nombre.Contains(filtro)); 
                    /// <summary>
                    /// Filtra los mensajes que contienen el filtro
                    /// </summary>
                }
            }
            return veterinarios;
        }

        public Veterinario UpdateVeterinario(Veterinario veterinario)
        {
            var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(p => p.VeterinarioId == veterinario.VeterinarioId);

            if (veterinarioEncontrado != null)
            {
                veterinarioEncontrado.Nombre = veterinario.Nombre;
                veterinarioEncontrado.Apellido = veterinario.Apellido;
                veterinarioEncontrado.Telefono = veterinario.Telefono;
                veterinarioEncontrado.TarjetaProfesional = veterinario.TarjetaProfesional;

                _appContext.SaveChanges();
            }

            return veterinarioEncontrado;
        }
    }
}