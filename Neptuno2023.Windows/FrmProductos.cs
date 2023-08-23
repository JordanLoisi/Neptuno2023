using Neptuno2023.Entidades.Entidades;
using Neptuno2023.Servicios.Interfases;
using Neptuno2023.Servicios.Servicios;
using Neptuno2023.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Neptuno2023.Windows
{
    public partial class FrmProductos : Form
    {
        public FrmProductos()
        {
            InitializeComponent();
        }

        private IServiciosProductos _servicio;
        private List<Producto> _lista;
        private void FrmProductos_Load(object sender, EventArgs e)
        {
            _servicio = new ServiciosProductos();
            try
            {
                _lista = _servicio.GetProductos();
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
            foreach (var producto in _lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, producto);
                GridHelper.AgregarFila(dgvDatos,r);
            }
        }


        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmProductosAE frm = new FrmProductosAE();
            frm.Text = "Agregar Producto";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {

                Producto producto = frm.GetProducto();
                //Controlar repetido
                if (_servicio.Existe(producto))
                {
                    MessageBox.Show("Registro Repetido", "Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                _servicio.Guardar(producto);
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                
                GridHelper.SetearFila(r, producto);
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
            Producto producto = (Producto)r.Tag;
            Producto productoAux = (Producto)producto.Clone();
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja el producto {producto.NombreProducto}?",
                "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }

            try
            {
                _servicio.Borrar(producto.ProductoId);
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
            Producto producto = (Producto)r.Tag;
            Producto productoAuxiliar = (Producto)producto.Clone();
            FrmProductosAE frm = new FrmProductosAE();
            frm.Text = "Editar Cliente";
            frm.SetProducto(producto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                producto = frm.GetProducto();
                //Controlar repitencia

                if (!_servicio.Existe(producto))
                {
                    _servicio.Guardar(producto);
                    GridHelper.SetearFila(r, producto);
                    MessageBox.Show("Registro Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    GridHelper.SetearFila(r, productoAuxiliar);
                    MessageBox.Show("Registro ya existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception exception)
            {
                GridHelper.SetearFila(r, productoAuxiliar);

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
