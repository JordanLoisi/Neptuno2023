using Neptuno2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Entidades.Combos
{
    public class ClienteComboDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public Pais Pais { get; set; }
        public Ciudad Ciudad { get; set; }

        public string Direccion { get; set; }

        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
    }
}
