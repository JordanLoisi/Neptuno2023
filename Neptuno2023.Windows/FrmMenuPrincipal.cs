using System;
using System.Windows.Forms;

namespace Neptuno2023.Windows
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void CerrarButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PaisesButton_Click(object sender, EventArgs e)
        {
            FrmPaises frm = new FrmPaises();
            frm.ShowDialog(this);
        }

        private void CiudadesButton_Click(object sender, EventArgs e)
        {
            FrmCiudades frm = new FrmCiudades();
            frm.ShowDialog(this);
        }

        private void CategoriasButton_Click(object sender, EventArgs e)
        {
            FrmCategorias frm=new FrmCategorias();
            frm.ShowDialog(this);
        }

        private void ClientesButton_Click(object sender, EventArgs e)
        {
            FrmClientes frm = new FrmClientes();
            frm.ShowDialog(this);
        }

        private void ProveedoresButton_Click(object sender, EventArgs e)
        {

            FrmProveedores frm = new FrmProveedores();
            frm.ShowDialog(this);
        }

        private void ProductosButton_Click(object sender, EventArgs e)
        {
            FrmProductos frm = new FrmProductos();
            frm.ShowDialog(this);
        }

        private void VentasButton_Click(object sender, EventArgs e)
        {
            //FrmVentas frm = new FrmVentas();
            //frm.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCompras frm = new frmCompras();
            frm.ShowDialog(this);
        }
    }
}
