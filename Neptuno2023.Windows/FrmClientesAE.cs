using Neptuno2023.Entidades.Entidades;
using Neptuno2023.Windows.Helpers;
using System;
using System.Windows.Forms;

namespace Neptuno2023.Windows
{
    public partial class FrmClientesAE : Form
    {
        public FrmClientesAE()
        {
            InitializeComponent();
        }

        private Cliente cliente;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarComboPaises(ref cboPaises);
            if (cliente != null)
            {
                txtCliente.Text = cliente.NombreCliente;
                txtCalle.Text = cliente.Direccion;
                txtCodPostal.Text = cliente.CodPostal;
                txtTelefono.Text = cliente.TelFijo;
                txtMovil.Text = cliente.TelMovil;
                cboPaises.SelectedValue = cliente.PaisId;
                CombosHelper.CargarComboCiudades(ref cboCiudades, cliente.PaisId);
                cboCiudades.SelectedValue = cliente.CiudadId;
            }

        }

        private void CancelarButton_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void PaisesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPaises.SelectedIndex != 0)
            {
                Pais pais = (Pais)cboPaises.SelectedItem;
                CombosHelper.CargarComboCiudades(ref cboCiudades, cliente.PaisId);
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
                if (cliente == null)
                {
                    cliente = new Cliente();
                }

                cliente.NombreCliente = txtCliente.Text;
                cliente.Direccion = txtCalle.Text;
                cliente.CodPostal = txtCodPostal.Text;
                cliente.PaisId = (int)cboPaises.SelectedValue;
                cliente.CiudadId = (int)cboCiudades.SelectedValue;
                cliente.TelFijo = txtTelefono.Text;
                cliente.TelMovil = txtMovil.Text;

                DialogResult = DialogResult.OK;

            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtCliente.Text)
                || string.IsNullOrWhiteSpace(txtCliente.Text))
            {
                valido = false;
                errorProvider1.SetError(txtCliente, "El nombre de la compañía es requerido");
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

        public Cliente GetCliente()
        {
            return cliente;
        }

        public void SetCliente(Cliente cliente)
        {
            this.cliente = cliente;
        }

    }
}
