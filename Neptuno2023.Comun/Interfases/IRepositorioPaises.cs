using Neptuno2023.Entidades.Entidades;
using System.Collections.Generic;

namespace Neptuno2023.Comun.Interfases
{
    public interface IRepositorioPaises
    {
        void Agregar(Pais pais);
        void Borrar(int paisId);
        void Editar(Pais pais);
        bool Existe(Pais pais);
        bool EstaRelacionado(Pais pais);
        //int GetCantidad();
        int GetCantidad(string textoFiltro);
        List<Pais> GetPaises();
        List<Pais> GetPaises(string textoFiltro);
        List<Pais> GetPaisesPorPagina(int cantidad, int paginaActual, string textoFiltro);
        Pais GetPaisPorId(int paisId);

    }
}
