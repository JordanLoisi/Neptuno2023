using Neptuno2023.Entidades.Entidades;
using Neptuno2023.Servicios.Interfases;
using Neptuno2023.Servicios.Servicios;
using Neptuno2023.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Neptuno2023.Windows
{
    public partial class FrmCiudades : Form
    {
        public FrmCiudades()
        {
            InitializeComponent();
        }

        private IServiciosCiudades _servicio;
        private List<Ciudad> lista;
        private void FrmCiudades_Load(object sender, EventArgs e)
        {
            _servicio = new ServiciosCiudades();
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            try
            {
                lista = _servicio.GetCiudades(null);
                MostrarDatosEnGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (var ciudad in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, ciudad);
                GridHelper.AgregarFila(dgvDatos,r);
            }
        }

        

        

        

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmCiudadesAE frm = new FrmCiudadesAE();
            frm.Text = "Agregar Localidad";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Ciudad ciudad = frm.GetCiudad();
                    //Controlar repitencia

                    if (!_servicio.Existe(ciudad))
                    {
                        _servicio.Guardar(ciudad);
                       
                        DataGridViewRow r =GridHelper.ConstruirFila(dgvDatos);
                        GridHelper.SetearFila(r, ciudad);
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
            Ciudad ciudad= (Ciudad)r.Tag;
            DialogResult dr =
                MessageBox
                    .Show($@"¿Desea borrar el registro seleccionado de la ciudad {ciudad.NombreCiudad}?",
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
                _servicio.Borrar(ciudad.CiudadId);
                dgvDatos.Rows.Remove(r);
                MessageBox.Show("Registro borrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = dgvDatos.SelectedRows[0];
            Ciudad ciudad = (Ciudad)r.Tag;
            Ciudad ciudadAuxiliar =(Ciudad) ciudad.Clone();
            FrmCiudadesAE frm = new FrmCiudadesAE();
            frm.Text = "Editar Ciudad";
            frm.SetCiudad(ciudad);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                ciudad = frm.GetCiudad();
                //Controlar repitencia

                if (!_servicio.Existe(ciudad))
                {
                    _servicio.Guardar(ciudad);
                    
                    GridHelper.SetearFila(r, ciudad);
                    MessageBox.Show("Registro Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    GridHelper.SetearFila(r, ciudadAuxiliar);
                    MessageBox.Show("Registro ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception exception)
            {
                GridHelper.SetearFila(r, ciudadAuxiliar);

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarCiudades frm = new FrmBuscarCiudades();
            frm.Text = "Seleccionar País";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                Pais pais = frm.GetPais();
                lista = _servicio.GetCiudades(pais.PaisId);
                MostrarDatosEnGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }
    }
}

