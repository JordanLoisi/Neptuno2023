using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Entidades.Entidades
{
    public class Compras
    {
        public int ComprasId { get; set; }

        public int ProveedorId { get; set; }

        public DateTime FechaCompra { get; set; }

        public decimal Total { get; set; }

        //public TimeSpan RowVersion { get; set; }


    }
}
