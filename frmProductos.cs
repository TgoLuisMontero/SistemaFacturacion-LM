using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaEntidad;
using CapaNegocio;

namespace Billig_System_L_M
{
    public partial class frmProductos : Form
    {
        private Productos productos = new Productos();
        private CN_Producto negocio = new CN_Producto();
        public frmProductos()
        {
            InitializeComponent();
        }

        private void txtProductoBuscar_TextChanged(object sender, EventArgs e)
        {
            tbProductos.DataSource = negocio.CN_buscar_Producto(txtProductoBuscar.Text);
        }

        private void CargarProductos()
        {
            try
            {
                tbProductos.DataSource = negocio.CN_listarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            limpiarCajas();
        }

        private void limpiarCajas()
        {
            txtID.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            txtProductoBuscar.Text = "";
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                productos = new Productos()
                {
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Precio_Unitario = double.Parse(txtPrecio.Text.Trim()),
                    Stock = int.Parse(txtStock.Text.Trim())
                };

                negocio = new CN_Producto();
                string mensaje = negocio.CN_crear_Producto(productos);

                MessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                limpiarCajas();
                CargarProductos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: " + ex.Message);
            }
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            try
            {
                productos = new Productos()
                {
                    id_Producto = int.Parse(txtID.Text.Trim()),
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Precio_Unitario = double.Parse(txtPrecio.Text.Trim()),
                    Stock = int.Parse(txtStock.Text.Trim())
                };

                negocio = new CN_Producto();
                string mensaje = negocio.CN_modificar_Producto(productos);

                MessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                limpiarCajas();
                CargarProductos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: " + ex.Message);
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                productos = new Productos()
                {
                    id_Producto = int.Parse(txtID.Text.Trim())
                };

                negocio = new CN_Producto();
                string mensaje = negocio.CN_eliminar_Producto(productos);

                MessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                limpiarCajas();
                CargarProductos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: " + ex.Message);
            }
        }

        private void tbProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = tbProductos.Rows[e.RowIndex];

                txtID.Text = fila.Cells["id_Producto"].Value.ToString();
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = fila.Cells["Descripcion"].Value.ToString();
                txtPrecio.Text = fila.Cells["Precio_Unitario"].Value.ToString();
                txtStock.Text = fila.Cells["Stock"].Value.ToString();
            }
        }
    }
}
