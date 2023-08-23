using Neptuno2023.Entidades.Entidades;
using System.Collections.Generic;

namespace Neptuno2023.Comun.Interfases
{
    public interface IRepositorioClientes
    {
        void Borrar(int clienteId);
        void Editar(Cliente cliente);
        bool Existe(Cliente cliente);
        bool EstaRelacionado(Cliente cliente);
        int GetCantidad();
        List<Cliente> GetClientes();
        List<Cliente> GetClientesPorPagina(int registrosPorPagina, int paginaActual);
        void Agregar(Cliente cliente);
        Cliente GetClientePorId(int clienteId);
    }
}
