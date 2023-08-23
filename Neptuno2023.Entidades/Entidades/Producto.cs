using System;

namespace Neptuno2023.Entidades.Entidades
{
    public class Producto:ICloneable
    {
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public decimal PrecioUnitario { get; set; }
        public double Stock { get; set; }
        public double StockMinimo { get; set; }
        public bool Suspendido { get; set; }
        public string Imagen { get; set; }

        public object Clone()
        {
           return this.MemberwiseClone();
        }
    }
}
