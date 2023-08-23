using Neptuno2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Entidades.Dto
{
    public class CiudadDto
    {
        public string NombreCiudad { get; set; }
        
        public Pais Pais { get; set; }
    }
}
