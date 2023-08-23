using Neptuno2023.Comun.Interfases;
using Neptuno2023.Datos.Repositorios;
using Neptuno2023.Entidades.Entidades;
using Neptuno2023.Servicios.Interfases;
using System;
using System.Collections.Generic;
using System.IO;

namespace Neptuno2023.Servicios.Servicios
{
    public class ServiciosProductos : IServiciosProductos
    {
        private readonly IRepositorioProductos _repositorio;
        public ServiciosProductos()
        {
            _repositorio = new RepositorioProductos();
        }
        public void Borrar(int productoId)
        {
            try
            {
                _repositorio.Borrar(productoId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Producto> GetProductos()
        {
            try
            {
                return _repositorio.GetProductos();
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

        public bool Existe(Producto producto)
        {
            try
            {
                return _repositorio.Existe(producto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Producto producto)
        {
            try
            {
                string nuevoNombreArchivo = null;
                if (producto.Imagen != null && !TryStrToGuid(producto.Imagen))
                {
                    nuevoNombreArchivo = ObtenerNombreArchivo(Path.GetFileName(producto.Imagen));
                    File.Copy(producto.Imagen, Environment.CurrentDirectory + $@"\Imagenes\{nuevoNombreArchivo}");
                    producto.Imagen = nuevoNombreArchivo;
                }

                if (producto.ProductoId == 0)
                {

                    _repositorio.Agregar(producto);

                }
                else
                {
                    _repositorio.Editar(producto);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private string ObtenerNombreArchivo(string imagen)
        {
            var array = imagen.Split('.');
            var extension = array[1];
            var nombre = Guid.NewGuid().ToString();
            return $"{nombre}.{extension}";
        }
        public bool TryStrToGuid(string s)
        {
            try
            {
                Guid value = new Guid(s);
                return true;
            }
            catch (FormatException)
            {
                Guid value = Guid.Empty;
                return false;
            }
        }


        public List<Producto> GetProductosPorPagina(int registrosPorPagina, int paginaActual)
        {
            try
            {
                return _repositorio.GetProductosPorPagina(registrosPorPagina, paginaActual);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Producto GetProductoPorId(int productoId)
        {
            try
            {
                return _repositorio.GetProductoPorId(productoId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Producto> GetLista()
        {
            try
            {
                return _repositorio.GetProductos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionado(Producto producto)
        {
            try
            {
                return _repositorio.EstaRelacionado(producto);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
