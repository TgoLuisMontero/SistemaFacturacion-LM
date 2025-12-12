
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

using CapaEntidad;
using CapaNegocio;

namespace Billig_System_L_M
{
    public partial class frmClientes : Form
    {
        private Cliente cliente = new Cliente();
        private CN_Cliente negocio = new CN_Cliente();

        public frmClientes()
        {
            InitializeComponent();
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            limpiarCajas();
        }

        private void limpiarCajas()
        {
            txtID.Text = "";
            txtNombre.Text = "";
            txtCedula.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
        }

        private void CargarClientes()
        {
            try
            {
                tbClientes.DataSource = negocio.CN_listarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }
        private void textNombreBuscar_TextChanged(object sender, EventArgs e)
        {
            tbClientes.DataSource = negocio.CN_buscar_Cliente(textNombreBuscar.Text);
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                cliente = new Cliente()
                {
                    NombreCompleto = txtNombre.Text.Trim(),
                    Cedula = txtCedula.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                };

                negocio = new CN_Cliente();
                string mensaje = negocio.CN_crear_Cliente(cliente);

                MessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                limpiarCajas();
                CargarClientes();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: " + ex.Message);
            }
        }

        private void tbClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = tbClientes.Rows[e.RowIndex];

                txtID.Text = fila.Cells["id_Cliente"].Value.ToString();
                txtNombre.Text = fila.Cells["NombreCompleto"].Value.ToString();
                txtCedula.Text = fila.Cells["Cedula"].Value.ToString();
                txtDireccion.Text = fila.Cells["Direccion"].Value.ToString();
                txtEmail.Text = fila.Cells["Email"].Value.ToString();
            }
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            try
            {
                cliente = new Cliente()
                {
                    id_Cliente = int.Parse(txtID.Text),
                    NombreCompleto = txtNombre.Text.Trim(),
                    Cedula = txtCedula.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                };

                negocio = new CN_Cliente();
                string mensaje = negocio.CN_modificar_Cliente(cliente);

                MessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                limpiarCajas();
                CargarClientes();

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
                cliente = new Cliente()
                {
                    id_Cliente = int.Parse(txtID.Text),
                };

                negocio = new CN_Cliente();
                string mensaje = negocio.CN_eliminar_Cliente(cliente);

                MessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                limpiarCajas();
                CargarClientes();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: " + ex.Message);
            }
        }
    }
}
