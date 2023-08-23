using System;

namespace Neptuno2023.Entidades.Entidades
{
    public class Cliente:ICloneable
    {
        public int ClienteId { get; set; }
        public string NombreCliente { get; set; }
        public string Direccion { get; set; }
        public string CodPostal { get; set; }
        public int PaisId { get; set; }
        public int CiudadId { get; set; }
        public Pais Pais { get; set; }
        public Ciudad Ciudad { get; set; }
        public string TelFijo { get; set; }
        public string TelMovil { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        
    }
}
