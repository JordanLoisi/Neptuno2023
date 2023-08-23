using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Entidades.Dto
{
    public class ComprasDto
    {
        public int ComprasId { get; set; }

        public string NombreProveedor { get; set; }

        public DateTime FechaCompra { get; set; }

        public decimal Total { get; set; }
    }
}
