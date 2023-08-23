using Neptuno2023.Entidades.Entidades;
using Neptuno2023.Servicios.Interfases;
using Neptuno2023.Servicios.Servicios;
using Neptuno2023.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Neptuno2023.Windows
{
    public partial class FrmPaises : Form
    {
        public FrmPaises()
        {
            InitializeComponent();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private IServiciosPaises _servicio;
        private List<Pais> _lista;
        private void FrmPaises_Load(object sender, EventArgs e)
        {
            _servicio = new ServiciosPaises();
            try
            {
                _lista = _servicio.GetPaises();
                MostrarDatosEnGrilla();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (var pais in _lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, pais);
                GridHelper.AgregarFila(dgvDatos,r);
            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmPaisesAE frm = new FrmPaisesAE();
            frm.Text = "Agregar un País";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Pais pais = frm.GetPais();
                    //Controlar repitencia

                    if (!_servicio.Existe(pais))
                    {
                        _servicio.Guardar(pais);
                        DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                        
                        GridHelper.SetearFila(r, pais);
                        GridHelper.AgregarFila(dgvDatos,r);
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

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow r = dgvDatos.SelectedRows[0];
            Pais pais = (Pais)r.Tag;
            Pais paisAuxiliar = (Pais)pais.Clone();
                
            FrmPaisesAE frm = new FrmPaisesAE();
            frm.Text = "Editar Pais";
            frm.SetPais(pais);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    pais = frm.GetPais();

                    if (!_servicio.Existe(pais))
                    {
                        _servicio.Guardar(pais);
                        GridHelper.SetearFila(r, pais);
                        MessageBox.Show("Registro Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        GridHelper.SetearFila(r, paisAuxiliar);
                        MessageBox.Show("Registro ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                catch (Exception exception)
                {
                    GridHelper.SetearFila(r, paisAuxiliar);

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
            Pais pais = (Pais)r.Tag;

            DialogResult dr = MessageBox.Show($@"¿Desea dar de baja el registro seleccionado: {pais.NombrePais}?",
                @"Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (dr == DialogResult.Yes)
            {
                //Verificar que no está relacionado
                try
                {
                    _servicio.Borrar(pais.PaisId);
                    dgvDatos.Rows.Remove(r);
                    MessageBox.Show(@"Registro Borrado", @"Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }
    }
}
