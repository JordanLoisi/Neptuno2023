using Neptuno2023.Entidades.Entidades;
using System.Collections.Generic;

namespace Neptuno2023.Servicios.Interfases
{
    public interface IServiciosClientes
    {
        void Borrar(int clienteId);
        bool Existe(Cliente cliente);
        bool EstaRelacionado(Cliente cliente);
        List<Cliente> Filtrar(Pais pais);
        int GetCantidad();
        Cliente GetClientePorId(int clienteId);
        List<Cliente> GetClientes();
        List<Cliente> GetClientesPorPagina(int registrosPorPagina, int paginaActual);
        void Guardar(Cliente cliente);
    }
}
