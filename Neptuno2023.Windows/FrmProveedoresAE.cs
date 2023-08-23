using Neptuno2023.Entidades.Entidades;
using Neptuno2023.Windows.Helpers;
using System;
using System.Windows.Forms;

namespace Neptuno2023.Windows
{
    public partial class FrmProveedoresAE : Form
    {
        public FrmProveedoresAE()
        {
            InitializeComponent();
        }

        public void SetProveedor(Proveedor proveedor)
        {
            this.proveedor = proveedor;
        }

        private Proveedor proveedor;
        public Proveedor GetProveedor()
        {
            return proveedor;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarComboPaises(ref cboPaises);
            if (proveedor == null) return;
            txtProveedor.Text = proveedor.NombreProveedor;
            txtCalle.Text = proveedor.Direccion;
            txtCodPostal.Text = proveedor.CodPostal;
            txtTelefono.Text = proveedor.Telefono;
            txtEmail.Text = proveedor.Email;
            cboPaises.SelectedValue = proveedor.Pais.PaisId;
            CombosHelper.CargarComboCiudades(ref cboCiudades, proveedor.PaisId);
            cboCiudades.SelectedValue = proveedor.Ciudad.CiudadId;

        }


        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void PaisesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPaises.SelectedIndex != 0)
            {
                Pais pais = (Pais)cboPaises.SelectedItem;
                CombosHelper.CargarComboCiudades(ref cboCiudades, pais.PaisId);
            }
            else
            {
                cboCiudades.DataSource = null;
            }
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (proveedor == null)
                {
                    proveedor = new Proveedor();
                }

                proveedor.NombreProveedor = txtProveedor.Text;
                proveedor.Direccion = txtCalle.Text;
                proveedor.CodPostal = txtCodPostal.Text;
                proveedor.PaisId = (int)cboPaises.SelectedValue;
                proveedor.CiudadId = (int)cboCiudades.SelectedValue;
                proveedor.Telefono = txtTelefono.Text;
                proveedor.Email = txtEmail.Text;

                DialogResult = DialogResult.OK;

            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtProveedor.Text)
                || string.IsNullOrWhiteSpace(txtProveedor.Text))
            {
                valido = false;
                errorProvider1.SetError(txtProveedor, "El nombre de la compañía es requerido");
            }

            if (cboPaises.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboPaises, "Debe seleccionar un país");
            }

            if (cboCiudades.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboCiudades, "Debe seleccionar una ciudad");
            }

            return valido;
        }
    }
}
