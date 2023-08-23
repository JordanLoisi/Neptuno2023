using Neptuno2023.Entidades.Entidades;
using System.Collections.Generic;

namespace Neptuno2023.Servicios.Interfases
{
    public interface IServiciosProductos
    {
        void Guardar(Producto producto);
        void Borrar(int productoId);
        bool Existe(Producto producto);
        bool EstaRelacionado(Producto producto);
        int GetCantidad();
        List<Producto> GetProductos();
        List<Producto> GetProductosPorPagina(int cantidad, int pagina);
        Producto GetProductoPorId(int productoId);

    }
}
