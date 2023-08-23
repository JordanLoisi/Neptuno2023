using Neptuno2023.Entidades.Entidades;
using Neptuno2023.Servicios.Interfases;
using Neptuno2023.Servicios.Servicios;
using Neptuno2023.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Neptuno2023.Windows
{
    public partial class FrmProveedores : Form
    {
        public FrmProveedores()
        {
            InitializeComponent();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private IServiciosProveedores _servicio;
        private List<Proveedor> _lista;
        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            try
            {
                _servicio = new ServiciosProveedores();
                _lista = _servicio.GetProveedores();
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
            foreach (var proveedor in _lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, proveedor);
                GridHelper.AgregarFila(dgvDatos,r);
            }
        }

        
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmProveedoresAE frm = new FrmProveedoresAE();
            frm.Text = "Agregar Proveedor";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {

                Proveedor proveedor = frm.GetProveedor();
                //Controlar repetido
                if (_servicio.Existe(proveedor))
                {
                    MessageBox.Show("Registro Repetido", "Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                _servicio.Guardar(proveedor);
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, proveedor);
                GridHelper.AgregarFila(dgvDatos,r);
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
            Proveedor proveedor = (Proveedor)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja al proveedor {proveedor.NombreProveedor}?",
                "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }

            try
            {
                _servicio.Borrar(proveedor.ProveedorId);
                GridHelper.QuitarFila(dgvDatos,r);
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
            Proveedor proveedor = (Proveedor)r.Tag;
            Proveedor proveedorAuxiliar = (Proveedor)proveedor.Clone();
            FrmProveedoresAE frm = new FrmProveedoresAE();
            frm.Text = "Editar Proveedor";
            frm.SetProveedor(proveedor);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                proveedor = frm.GetProveedor();
                //Controlar repitencia

                if (!_servicio.Existe(proveedor))
                {
                    _servicio.Guardar(proveedor);

                    GridHelper.SetearFila(r, proveedor);
                    MessageBox.Show("Registro Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    GridHelper.SetearFila(r, proveedorAuxiliar);
                    MessageBox.Show("Registro ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception exception)
            {
                GridHelper.SetearFila(r, proveedorAuxiliar);

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
