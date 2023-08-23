using Neptuno2023.Entidades.Entidades;
using System.Collections.Generic;

namespace Neptuno2023.Servicios.Interfases
{
    public interface IServiciosPaises
    {
        void Borrar(int paisId);
        bool Existe(Pais pais);
        bool EstaRelacionado(Pais pais);
        int GetCantidad(string textoFiltro);
        List<Pais> GetPaises();
        List<Pais> GetPaisesPorPagina(int cantidad, int paginaActual, string textoFiltro);

        void Guardar(Pais pais);
        Pais GetPaisPorId(int paisId);

    }
}
