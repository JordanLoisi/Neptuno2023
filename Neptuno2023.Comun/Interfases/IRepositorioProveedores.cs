using Neptuno2023.Entidades.Entidades;
using System.Collections.Generic;

namespace Neptuno2023.Comun.Interfases
{
    public interface IRepositorioProveedores
    {
        void Borrar(int proveedorId);
        void Editar(Proveedor proveedor);
        bool Existe(Proveedor proveedor);
        int GetCantidad();
        List<Proveedor> GetProveedores();
        List<Proveedor> GetProveedoresPorPagina(int registrosPorPagina, int paginaActual);
        void Agregar(Proveedor Proveedor);
        Proveedor GetProveedorPorId(int proveedorId);
        bool EstaRelacionado(Proveedor proveedor);
    }
}
