using Neptuno2023.Entidades.Dto;
using Neptuno2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Comun.Interfases
{
    public interface IRepositorioCompras
    {
        int GetCantidad();
        List<ComprasDto> GetComprasDto();
        List<ComprasDto> GetComprasPorPagina(int cantidad, int pagina);

        ComprasDto GetComprasPorId(int VentaId);
    }
}
