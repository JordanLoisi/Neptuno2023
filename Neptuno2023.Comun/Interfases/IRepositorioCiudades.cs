using Neptuno2023.Entidades.Dto;
using Neptuno2023.Entidades.Entidades;
using System.Collections.Generic;

namespace Neptuno2023.Comun.Interfases
{
    public interface IRepositorioCiudades
    {
        void Agregar(Ciudad ciudad);
        void Borrar(int ciudadId);
        void Editar(Ciudad ciudad);
        bool Existe(Ciudad ciudad);
        bool EstaRelacionada(Ciudad ciudad);

        int GetCantidad();
        List<Ciudad> GetCiudades();
        List<Ciudad> GetCiudadesPorPagina(int registrosPorPagina, int paginaActual);
        Ciudad GetCiudadPorId(int ciudadId);

        List<CiudadDto> GetComprasDto();

    }
}
