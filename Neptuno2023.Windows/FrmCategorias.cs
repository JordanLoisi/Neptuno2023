using Neptuno2023.Entidades.Entidades;
using Neptuno2023.Servicios.Interfases;
using Neptuno2023.Servicios.Servicios;
using Neptuno2023.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Neptuno2023.Windows
{
    public partial class FrmCategorias : Form
    {
        public FrmCategorias()
        {
            InitializeComponent();
        }

        private IServicioCategorias _servicio;
        private List<Categoria> _lista;
        private void FrmCatagorias_Load(object sender, EventArgs e)
        {
            _servicio = new ServiciosCategorias();
            try
            {
                _lista = _servicio.GetCategorias();
                MostrarDatosEnGrilla();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (var categoria in _lista)
            {
                DataGridViewRow r =GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, categoria);
                GridHelper.AgregarFila(dgvDatos,r);
            }
        }




        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmCategoriasAE frm = new FrmCategoriasAE();
            frm.Text = "Agregar Categoría";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Categoria categoria = frm.GetCategoria();
                    //Controlar repitencia

                    if (!_servicio.Existe(categoria))
                    {
                        _servicio.Guardar(categoria);
                        DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                        GridHelper.SetearFila(r, categoria);
                        GridHelper.AgregarFila(dgvDatos, r);
                        MessageBox.Show("Registro Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Registro ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                catch (Exception exception)
                {

                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = dgvDatos.SelectedRows[0];
            Categoria categoria = (Categoria)r.Tag;
            DialogResult dr =
                MessageBox
                    .Show($@"¿Desea borrar el registro seleccionado de la categoría {categoria.NombreCategoria}?",
                        "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2
                    );
            if (dr == DialogResult.No)
            {
                return;
            }

            try
            {
                //Controlar relaciones 
                _servicio.Borrar(categoria.CategoriaId);
                dgvDatos.Rows.Remove(r);
                MessageBox.Show("Registro borrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = dgvDatos.SelectedRows[0];
            Categoria categoria = (Categoria)r.Tag;
            Categoria categoriaDtoAux = categoria.Clone() as Categoria;
            FrmCategoriasAE frm = new FrmCategoriasAE();
            categoria = _servicio.GetCategoriaPorId(categoria.CategoriaId);
            frm.Text = "Editar Categoría";
            frm.SetCategoria(categoria);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                categoria = frm.GetCategoria();
                //Controlar repitencia

                if (!_servicio.Existe(categoria))
                {
                    _servicio.Guardar(categoria);
                    GridHelper.SetearFila(r, categoria);
                    MessageBox.Show("Registro Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    GridHelper.SetearFila(r, categoriaDtoAux);
                    MessageBox.Show("Registro ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception exception)
            {
                GridHelper.SetearFila(r, categoriaDtoAux);

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
