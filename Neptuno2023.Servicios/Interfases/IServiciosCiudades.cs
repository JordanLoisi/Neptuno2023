using Neptuno2023.Entidades.Entidades;
using System.Collections.Generic;

namespace Neptuno2023.Servicios.Interfases
{
    public interface IServiciosCiudades
    {
        void Guardar(Ciudad ciudad);
        void Borrar(int ciudadId);
        bool Existe(Ciudad ciudad);
        bool EstaRelacionada(Ciudad ciudad);

        
        List<Ciudad> GetCiudadesPorPagina(int registrosPorPagina, int paginaActual);
        List<Ciudad> GetCiudades(int? paisId);
        int GetCantidad(int? paisId);
    }
}
