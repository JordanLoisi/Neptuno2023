using Neptuno2023.Comun.Interfases;
using Neptuno2023.Datos.Repositorios;
using Neptuno2023.Entidades.Entidades;
using Neptuno2023.Servicios.Interfases;
using System;
using System.Collections.Generic;

namespace Neptuno2023.Servicios.Servicios
{
    public class ServiciosClientes : IServiciosClientes
    {
        private readonly IRepositorioClientes _repositorio;
        public ServiciosClientes()
        {
            _repositorio = new RepositorioClientes();
        }

        public void Borrar(int clienteId)
        {
            try
            {
                _repositorio.Borrar(clienteId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EstaRelacionado(Cliente cliente)
        {
            try
            {
                return _repositorio.EstaRelacionado(cliente);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Cliente cliente)
        {
            try
            {
                return _repositorio.Existe(cliente);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Cliente> Filtrar(Pais pais)
        {
            throw new NotImplementedException();
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

        public Cliente GetClientePorId(int clienteId)
        {
            try
            {
                return _repositorio.GetClientePorId(clienteId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Cliente> GetClientes()
        {
            try
            {
                return _repositorio.GetClientes();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<Cliente> GetClientesPorPagina(int cantidad, int pagina)
        {
            try
            {
                return _repositorio.GetClientesPorPagina(cantidad, pagina);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Cliente> GetLista()
        {
            throw new NotImplementedException();
        }

        public void Guardar(Cliente cliente)
        {
            try
            {
                if (cliente.ClienteId == 0)
                {
                    _repositorio.Agregar(cliente);
                }
                else
                {
                    _repositorio.Editar(cliente);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
