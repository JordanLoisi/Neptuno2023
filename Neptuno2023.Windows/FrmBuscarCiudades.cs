using Neptuno2023.Windows.Helpers;
using Neptuno2023.Entidades.Entidades;
using System.Windows.Forms;

namespace Neptuno2023.Windows
{
    public partial class FrmBuscarCiudades : Form
    {
        public FrmBuscarCiudades()
        {
            InitializeComponent();
        }

        private void FrmBuscarCiudades_Load(object sender, System.EventArgs e)
        {
            CombosHelper.CargarComboPaises(ref cboPaises);
        }

        private Pais pais;
        private void CancelarButton_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, System.EventArgs e)
        {
            if (ValidarDatos())
            {
                pais = (Pais)cboPaises.SelectedItem;
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
                errorProvider1.SetError(cboPaises, "Debe seleccionar un país");
            }

            return valido;
        }

        public Pais GetPais()
        {
            return pais;
        }
    }
}
