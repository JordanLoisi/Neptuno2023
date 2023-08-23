using Neptuno2023.Comun.Interfases;
using Neptuno2023.Datos.Repositorios;
using Neptuno2023.Entidades.Entidades;
using Neptuno2023.Servicios.Interfases;
using System;
using System.Collections.Generic;

namespace Neptuno2023.Servicios.Servicios
{
    public class ServiciosCiudades : IServiciosCiudades
    {
        private readonly IRepositorioCiudades _repositorio;
        private readonly IRepositorioPaises _repoPaises;
        public ServiciosCiudades()
        {
            _repositorio = new RepositorioCiudades();
            _repoPaises = new RepositorioPaises();
        }
        public void Borrar(int ciudadId)
        {
            try
            {
                _repositorio.Borrar(ciudadId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionada(Ciudad ciudad)
        {
            try
            {
                return _repositorio.Existe(ciudad);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Ciudad ciudad)
        {
            try
            {
                return _repositorio.Existe(ciudad);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public int GetCantidad(int? paisId)
        {
            try
            {
                return _repositorio.GetCantidad();
            }
            catch (Exception)
            {

                throw;
            }
        }


        //public List<Ciudad> GetCiudades()
        //{
        //    try
        //    {
        //        var lista= _repositorio.GetCiudades();
        //        foreach (var item in lista)
        //        {
        //            item.Pais = _repoPaises.GetPaisPorId(item.PaisId);
        //        }
        //        return lista;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public List<Ciudad> GetCiudades(int? paisId)
        {
            try
            {
                var lista = _repositorio.GetCiudades();
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Ciudad> GetCiudadesPorPagina(int registrosPorPagina, int paginaActual)
        {
            try
            {
                var lista = _repositorio.GetCiudadesPorPagina(registrosPorPagina, paginaActual);
                foreach (var item in lista)
                {
                    item.Pais = _repoPaises.GetPaisPorId(item.PaisId);
                }
                return lista;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Ciudad GetCiudadPorId(int id)
        {
            try
            {
                return _repositorio.GetCiudadPorId(id);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void Guardar(Ciudad ciudad)
        {
            try
            {
                if (ciudad.CiudadId == 0)
                {
                    _repositorio.Agregar(ciudad);
                }
                else
                {
                    _repositorio.Editar(ciudad);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
