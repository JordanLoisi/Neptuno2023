using Neptuno2023.Entidades.Entidades;
using Neptuno2023.Windows.Helpers;
using System;
using System.Windows.Forms;

namespace Neptuno2023.Windows
{
    public partial class FrmProductosAE : Form
    {
        public FrmProductosAE()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarComboCategorias(ref cboCategorias);
            CombosHelper.CargarComboProveedores(ref cboProveedores);


        }

        public void SetProducto(Producto producto)
        {
            this.producto = producto;
        }

        private Producto producto;
        public Producto GetProducto()
        {
            return producto;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (producto == null)
                {
                    producto = new Producto();
                }

                producto.NombreProducto = txtProducto.Text;
                producto.CategoriaId = (int)cboCategorias.SelectedValue;
                producto.ProveedorId = (int)cboProveedores.SelectedValue;
                producto.PrecioUnitario = decimal.Parse(txtPrecio.Text);
                producto.Stock = double.Parse(txtStock.Text);
                producto.StockMinimo = double.Parse(txtStockMinimo.Text);
                producto.Suspendido = chkSuspendido.Checked;


                DialogResult = DialogResult.OK;

            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtProducto.Text)
                || string.IsNullOrWhiteSpace(txtProducto.Text))
            {
                valido = false;
                errorProvider1.SetError(txtProducto, "El nombre es requerido");
            }

            if (cboCategorias.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboCategorias, "Debe seleccionar una categoría");
            }

            if (cboProveedores.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboProveedores, "Debe seleccionar un proveedor");
            }

            if (!double.TryParse(txtStock.Text, out double stock))
            {
                valido = false;
                errorProvider1.SetError(txtStock, "Stock mal ingresado");
            }
            else if (stock < 0 || stock > int.MaxValue)
            {
                valido = false;
                errorProvider1.SetError(txtStock, "Stock fuera del rango permitido");
            }
            if (!double.TryParse(txtStockMinimo.Text, out double enPedido))
            {
                valido = false;
                errorProvider1.SetError(txtStockMinimo, "Unidades en Pedido mal ingresado");
            }
            else if (enPedido < 0 || enPedido > int.MaxValue)
            {
                valido = false;
                errorProvider1.SetError(txtStockMinimo, "Unidades en Pedido fuera del rango permitido");
            }

            return valido;
        }
    }
}
