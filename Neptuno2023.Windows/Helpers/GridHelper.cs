using Neptuno2023.Entidades.Entidades;
using System.Windows.Forms;

namespace Neptuno2023.Windows.Helpers
{
    public static class GridHelper
    {
        public static void LimpiarGrilla(DataGridView dgv)
        {
            dgv.Rows.Clear();
        }
        public static DataGridViewRow ConstruirFila(DataGridView dgv)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgv);
            return r;

        }
        public static void SetearFila(DataGridViewRow r, object obj)
        {
            switch (obj)
            {
                case Pais pais:
                    r.Cells[0].Value = pais.NombrePais;
                    break;
                case Ciudad ciudad:
                    r.Cells[0].Value = ciudad.NombreCiudad;
                    r.Cells[1].Value = ciudad.PaisId;
                    break;
                case Categoria categoria:
                    r.Cells[0].Value = categoria.NombreCategoria;
                    break;
                case Cliente cliente:
                    r.Cells[0].Value = $"{cliente.NombreCliente}";
                    r.Cells[1].Value = cliente.PaisId;
                    r.Cells[2].Value = cliente.CiudadId;
                    break;
                case Proveedor proveedor:
                    r.Cells[0].Value = proveedor.NombreProveedor;
                    r.Cells[1].Value = proveedor.CiudadId;
                    r.Cells[2].Value = proveedor.PaisId;
                    break;
                case Producto producto:
                    r.Cells[0].Value = producto.NombreProducto;
                    r.Cells[1].Value = producto.CategoriaId;
                    r.Cells[2].Value = producto.PrecioUnitario;
                    r.Cells[3].Value = producto.Stock;
                    r.Cells[4].Value = producto.Suspendido;
                    break;

            }
            r.Tag = obj;

        }
        public static void AgregarFila(DataGridView dgv, DataGridViewRow r)
        {
            dgv.Rows.Add(r);
        }

        public static void QuitarFila(DataGridView dgv, DataGridViewRow r)
        {
            dgv.Rows.Remove(r);
        }
    }
}
