using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Billig_System_L_M
{
    public partial class frmUsuarios : Form
    {
        private Usuarios usuarios = new Usuarios();
        private CN_Usuarios negocioUsuarios = new CN_Usuarios();
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                usuarios = new Usuarios()
                {
                    Codigo_Usuario = textCodigo.Text.Trim(),
                    NombreCompleto = textNombre.Text.Trim(),
                    Telefono = textTelefono.Text.Trim(),
                    Email = textEmail.Text.Trim(),
                    Direccion = textDireccion.Text.Trim()
                };

                negocioUsuarios = new CN_Usuarios();
                string mensaje = negocioUsuarios.CN_crear_Usuarios(usuarios);

                MessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                limpiar();
                CargarUsuarios();

            } catch(Exception ex) 
            {
                MessageBox.Show("Ocurrio un error: " + ex.Message);
            }
        }

        private void limpiar()
        {
            textID.Text = "";
            textCodigo.Text = "";
            textNombre.Text = "";
            textTelefono.Text = "";
            textEmail.Text = "";
            textDireccion.Text = "";
        }

        private void CargarUsuarios()
        {
            try
            {
                tablaUsuarios.DataSource = negocioUsuarios.CN_listarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            usuarios = new Usuarios()
            {
                id_Usuario = int.Parse(textID.Text),
                Codigo_Usuario = textCodigo.Text,
                NombreCompleto = textNombre.Text,
                Telefono = textTelefono.Text,
                Email = textEmail.Text,
                Direccion = textDireccion.Text
            };

            string mensaje = negocioUsuarios.CN_modificar_Usuarios(usuarios);

            MessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarUsuarios(); // refresca el DataGridView
            limpiar();
        }

        private void tablaUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = tablaUsuarios.Rows[e.RowIndex];

                textID.Text = fila.Cells["id_Usuario"].Value.ToString();
                textCodigo.Text = fila.Cells["Codigo_Usuario"].Value.ToString();
                textNombre.Text = fila.Cells["NombreCompleto"].Value.ToString();
                textTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                textEmail.Text = fila.Cells["Email"].Value.ToString();
                textDireccion.Text = fila.Cells["Direccion"].Value.ToString();
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            usuarios = new Usuarios()
            {
                id_Usuario = int.Parse(textID.Text)
            };

            string mensaje = negocioUsuarios.CN_eliminar_Usuarios(usuarios);

            MessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarUsuarios(); // refresca el DataGridView
            limpiar();
        }

        private void textNombreBuscar_TextChanged(object sender, EventArgs e)
        {
            tablaUsuarios.DataSource = negocioUsuarios.CN_buscar_usuario(textNombreBuscar.Text);
        }
    }
}
