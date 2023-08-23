using Neptuno2023.Entidades.Entidades;
using System.Collections.Generic;

namespace Neptuno2023.Comun.Interfases
{
    public interface IRepositorioCategorias
    {
        void Agregar(Categoria categoria);
        void Borrar(int categoriaId);
        void Editar(Categoria categoria);
        bool Existe(Categoria categoria);
        bool EstaRelacionada(Categoria categoria);
        int GetCantidad();
        List<Categoria> GetCategorias();
        List<Categoria> GetCategoriasPorPagina(int cantidad, int pagina);
        Categoria GetCategoriaPorId(int categoriaId);

    }
}
