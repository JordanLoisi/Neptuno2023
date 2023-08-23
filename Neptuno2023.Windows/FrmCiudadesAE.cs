using Neptuno2023.Entidades.Entidades;
using Neptuno2023.Windows.Helpers;
using System;
using System.Windows.Forms;

namespace Neptuno2023.Windows
{
    public partial class FrmCiudadesAE : Form
    {
        public FrmCiudadesAE()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarComboPaises(ref cboPaises);
            if (ciudad != null)
            {
                txtCiudad.Text = ciudad.NombreCiudad;
                cboPaises.SelectedValue = ciudad.PaisId;
            }
        }


        private Ciudad ciudad;

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ValidadDatos())
            {
                if (ciudad == null)
                {
                    ciudad = new Ciudad();
                }

                ciudad.NombreCiudad = txtCiudad.Text;
                ciudad.PaisId =(int) cboPaises.SelectedValue;
                
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidadDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtCiudad.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtCiudad, "La ciudad es requerida");
            }

            if (cboPaises.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboPaises, "Debe seleccionar un país");
            }

            return valido;
        }

        public void SetCiudad(Ciudad ciudad)
        {
            this.ciudad = ciudad;
        }

        public Ciudad GetCiudad()
        {
            return ciudad;
        }

    }
}
