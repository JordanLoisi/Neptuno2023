using Neptuno2023.Entidades.Entidades;
using System.Collections.Generic;

namespace Neptuno2023.Servicios.Interfases
{
    public interface IServicioCategorias
    {
        void Guardar(Categoria categoria);
        void Borrar(int categoriaId);
        bool Existe(Categoria categoria);
        bool EstaRelacionada(Categoria categoria);
        int GetCantidad();
        List<Categoria> GetCategorias();
        List<Categoria> GetCategoriasPorPagina(int cantidad, int pagina);
        Categoria GetCategoriaPorId(int categoriaId);
    }
}
