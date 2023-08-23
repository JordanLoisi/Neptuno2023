using Neptuno2023.Entidades.Entidades;
using Neptuno2023.Windows.Helpers;
using System;
using System.Windows.Forms;

namespace Neptuno2023.Windows
{
    public partial class FrmBuscarGente : Form
    {
        public FrmBuscarGente()
        {
            InitializeComponent();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cboPaises.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboPaises, "Debe seleccioar al un país");
            }

            return valido;
        }

        private void FrmBuscarCliente_Load(object sender, EventArgs e)
        {
            CombosHelper.CargarComboPaises(ref cboPaises);
        }

        private Pais pais;
        private Ciudad ciudad;
        private void PaisesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPaises.SelectedIndex != 0)
            {
                pais = (Pais)cboPaises.SelectedItem;
                CombosHelper.CargarComboCiudades(ref cboCiudades, pais.PaisId);
            }
            else
            {
                cboCiudades.DataSource = null;
                ciudad = null;
                pais= null;
            }

        }

        private void CiudadesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCiudades.SelectedIndex > 0)
            {
                ciudad = (Ciudad)cboCiudades.SelectedItem;
            }
            else
            {
                ciudad = null;
            }
        }

        public Pais GetPais()
        {
            return pais;
        }

        public Ciudad GetCiudad()
        {
            return ciudad;
        }
    }
}
