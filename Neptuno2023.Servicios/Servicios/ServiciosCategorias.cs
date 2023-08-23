using Neptuno2023.Comun.Interfases;
using Neptuno2023.Datos.Repositorios;
using Neptuno2023.Entidades.Entidades;
using Neptuno2023.Servicios.Interfases;
using System;
using System.Collections.Generic;

namespace Neptuno2023.Servicios.Servicios
{
    public class ServiciosCategorias : IServicioCategorias
    {
        private readonly IRepositorioCategorias _repositorio;
        public ServiciosCategorias()
        {
            _repositorio = new RepositorioCategorias();
        }
        public void Borrar(int categoriaId)
        {
            try
            {
                _repositorio.Borrar(categoriaId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Categoria> GetCategorias()
        {
            try
            {
                return _repositorio.GetCategorias();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int GetCantidad()
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

        public bool Existe(Categoria categoria)
        {
            try
            {
                return _repositorio.Existe(categoria);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Categoria categoria)
        {
            try
            {
                if (categoria.CategoriaId == 0)
                {
                    _repositorio.Agregar(categoria);

                }
                else
                {
                    _repositorio.Editar(categoria);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<Categoria> GetCategoriasPorPagina(int cantidad, int pagina)
        {
            try
            {
                return _repositorio.GetCategoriasPorPagina(cantidad, pagina);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Categoria GetCategoriaPorId(int id)
        {
            try
            {
                return _repositorio.GetCategoriaPorId(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionada(Categoria categoria)
        {
            try
            {
                return _repositorio.EstaRelacionada(categoria);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
