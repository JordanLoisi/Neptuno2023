using Neptuno2023.Entidades.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Servicios.Interfases
{
    public interface IServiciosCompras
    {
        int GetCantidad();
        List<ComprasDto> GetComprasDTO();

        List<ComprasDto> GetComprasPorPagina(int cantidad, int pagina);

    }
}
