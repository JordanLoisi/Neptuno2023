using System;

namespace Neptuno2023.Entidades.Entidades
{
    public class Proveedor:ICloneable
    {
        public int ProveedorId { get; set; }
        public string NombreProveedor { get; set; }
        public string Direccion { get; set; }
        public string CodPostal { get; set; }
        public int PaisId { get; set; }
        public Pais Pais { get; set; }
        public int CiudadId { get; set; }
        public Ciudad Ciudad { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
