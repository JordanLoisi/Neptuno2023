using Neptuno2023.Entidades.Entidades;
using System;
using System.Windows.Forms;

namespace Neptuno2023.Windows
{
    public partial class FrmPaisesAE : Form
    {
        public FrmPaisesAE()
        {
            InitializeComponent();
        }

        private Pais pais;
        public void SetPais(Pais pais)
        {
            this.pais = pais;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (pais != null)
            {
                txtPais.Text = pais.NombrePais;
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (pais == null)
                {
                    pais = new Pais();
                }

                pais.NombrePais = txtPais.Text;
                DialogResult = DialogResult.OK;
            }

        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtPais.Text) || string.IsNullOrWhiteSpace(txtPais.Text))
            {
                valido = false;
                errorProvider1.SetError(txtPais, "El nombre del país es requerido");
            }

            return valido;
        }

        public Pais GetPais()
        {
            return pais;
        }

        private void PaisTextBox_Enter(object sender, EventArgs e)
        {
            txtPais.SelectAll();
        }
    }
}
