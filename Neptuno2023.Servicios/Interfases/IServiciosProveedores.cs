using Neptuno2023.Entidades.Entidades;
using System.Collections.Generic;

namespace Neptuno2023.Servicios.Interfases
{
    public interface IServiciosProveedores
    {
        void Borrar(int proveedorId);
        bool Existe(Proveedor proveedor);
        bool EstaRelacionado(Proveedor proveedor);
        int GetCantidad();
        Proveedor GetProveedorPorId(int proveedorId);
        List<Proveedor> GetProveedores();
        List<Proveedor> GetProveedores(Pais paisFiltro, Ciudad ciudadFiltro);
        List<Proveedor> GetProveedoresPorPagina(int registrosPorPagina, int paginaActual);
        void Guardar(Proveedor proveedor);
    }
}
