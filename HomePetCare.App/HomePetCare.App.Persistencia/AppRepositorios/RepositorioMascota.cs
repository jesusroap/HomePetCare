using System;
using System.Collections.Generic;
using System.Linq;
using HomePetCare.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace HomePetCare.App.Persistencia
{
    public class RepositorioMascota : IRepositorioMascota
    {
        private readonly AppContext _appContext;

        /// <summary>
        
        /// </summary>
        /// <param name="_appContext"></param>

        public RepositorioMascota(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Mascota AddMascota(Mascota mascota)
        {
            var mascotaAdicionada = _appContext.Mascotas.Add(mascota);
            _appContext.SaveChanges();
            return mascotaAdicionada.Entity;
        }

        public void DeleteMascota(int idMascota)
        {
            var mascotaEncontrada = _appContext.Mascotas.FirstOrDefault(p => p.Id == idMascota);

            if (mascotaEncontrada == null)
                return;
            _appContext.Mascotas.Remove(mascotaEncontrada);
            _appContext.SaveChanges();
        }

        public IEnumerable<Mascota> GetAllMascotas()
        {
            return _appContext.Mascotas.Include("Propietario");
        }

        public Mascota GetMascota(int idMascota)
        {
            return _appContext.Mascotas.Include("Propietario").FirstOrDefault(p => p.Id == idMascota);
        }

        public Mascota UpdateMascota(Mascota mascota)
        {
            var mascotaEncontrada = _appContext.Mascotas.FirstOrDefault(p => p.Id == mascota.Id);

            if (mascotaEncontrada != null)
            {
                mascotaEncontrada.Nombre = mascota.Nombre;
                mascotaEncontrada.Temperatura = mascota.Temperatura;
                mascotaEncontrada.Peso = mascota.Peso;
                mascotaEncontrada.FrecuenciaRespiratoria = mascota.FrecuenciaRespiratoria;
                mascotaEncontrada.EstadoAnimo = mascota.EstadoAnimo;
                mascotaEncontrada.Veterinario = mascota.Veterinario;
                mascotaEncontrada.Visita = mascota.Visita;
                mascotaEncontrada.Propietario = mascota.Propietario;

                _appContext.SaveChanges();
            }

            return mascotaEncontrada;
        }

        public IEnumerable<Mascota> GetMascotaPorFiltro(string filtro = null) // el parámetro es opcional 
        {
            var mascotas = GetAllMascotas(); // Obtiene todos las mascotas

            if (mascotas != null)  //Si se tienen mascotas
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    mascotas = mascotas.Where(s => s.Nombre.Contains(filtro)); 
                    /// <summary>
                    /// Filtra los mensajes que contienen el filtro
                    /// </summary>
                }
            }
            return mascotas;
        }
    }
}