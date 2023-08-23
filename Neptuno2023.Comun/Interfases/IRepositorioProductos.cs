using Neptuno2023.Entidades.Entidades;
using System.Collections.Generic;

namespace Neptuno2023.Comun.Interfases
{
    public interface IRepositorioProductos
    {
        void Agregar(Producto producto);
        void Borrar(int productoId);
        void Editar(Producto producto);
        bool Existe(Producto producto);
        int GetCantidad();
        Producto GetProductoPorId(int productoId);
        List<Producto> GetProductos();
        List<Producto> GetProductosPorPagina(int cantidad, int pagina);
        bool EstaRelacionado(Producto producto);

    }
}
