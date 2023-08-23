using Neptuno2023.Entidades.Entidades;
using Neptuno2023.Servicios.Interfases;
using Neptuno2023.Servicios.Servicios;
using Neptuno2023.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Neptuno2023.Windows
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private IServiciosClientes _servicio;
        private List<Cliente> _lista;

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            _servicio = new ServiciosClientes();
            ActualizarGrilla();

        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (var cliente in _lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, cliente);
                GridHelper.AgregarFila(dgvDatos,r);
            }
        }


        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmClientesAE frm = new FrmClientesAE();
            frm.Text = "Agregar Cliente";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {

                Cliente cliente = frm.GetCliente();
                //Controlar repetido
                if (_servicio.Existe(cliente))
                {
                    MessageBox.Show("Registro Repetido", "Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                _servicio.Guardar(cliente);
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, cliente);
                GridHelper.AgregarFila(dgvDatos, r);
                MessageBox.Show("Registro Agregado", "Mensaje", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = dgvDatos.SelectedRows[0];
            Cliente cliente = (Cliente)r.Tag;
            Cliente clienteoAux = (Cliente)cliente.Clone();
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja al cliente {cliente.NombreCliente}?",
                "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }

            try
            {
                _servicio.Borrar(cliente.ClienteId);
                GridHelper.QuitarFila(dgvDatos, r);
                MessageBox.Show("Registro Borrado", "Mensaje", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow r = dgvDatos.SelectedRows[0];
            Cliente cliente = (Cliente)r.Tag;
            Cliente clienteAuxiliar = (Cliente)cliente.Clone();
            FrmClientesAE frm = new FrmClientesAE();
            frm.Text = "Editar Cliente";
            frm.SetCliente(cliente);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                cliente = frm.GetCliente();
                //Controlar repitencia

                if (!_servicio.Existe(cliente))
                {
                    _servicio.Guardar(cliente);

                    GridHelper.SetearFila(r, cliente);
                    MessageBox.Show("Registro Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    GridHelper.SetearFila(r, clienteAuxiliar);
                    MessageBox.Show("Registro ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception exception)
            {
                GridHelper.SetearFila(r, clienteAuxiliar);

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarGente frm = new FrmBuscarGente();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    Pais pais = frm.GetPais();
                    Ciudad ciudad= frm.GetCiudad();
                    MostrarDatosEnGrilla();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            try
            {
                _lista = _servicio.GetClientes();
                MostrarDatosEnGrilla();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
