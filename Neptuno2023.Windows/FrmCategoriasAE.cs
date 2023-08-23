using Neptuno2023.Entidades.Entidades;
using System;
using System.Windows.Forms;

namespace Neptuno2023.Windows
{
    public partial class FrmCategoriasAE : Form
    {
        public FrmCategoriasAE()
        {
            InitializeComponent();
        }

        private Categoria categoria;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (categoria != null)
            {
                txtCategoria.Text = categoria.NombreCategoria;
                txtDescripcion.Text = categoria.Descripcion;
            }
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (categoria == null)
                {
                    categoria = new Categoria();
                }
                categoria.NombreCategoria = txtCategoria.Text;
                categoria.Descripcion = txtDescripcion.Text;

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {

            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtCategoria.Text) ||
                string.IsNullOrWhiteSpace(txtCategoria.Text))
            {
                valido = false;
                errorProvider1.SetError(txtCategoria, "Nombre de categoría requerido");
            }

            return valido;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public Categoria GetCategoria()
        {
            return categoria;
        }

        public void SetCategoria(Categoria categoria)
        {
            this.categoria = categoria;
        }
    }
}
