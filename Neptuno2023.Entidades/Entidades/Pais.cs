using System;

namespace Neptuno2023.Entidades.Entidades
{
    public class Pais:ICloneable
    {
        public int PaisId { get; set; }
        public string NombrePais { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
