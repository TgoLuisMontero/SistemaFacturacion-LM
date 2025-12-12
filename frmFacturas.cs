using CapaEntidad;
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
    public partial class frmFacturas : Form
    {
        private int _idCliente;
        private static Usuarios usuarioActual;
        public frmFacturas(Usuarios obj)
        {
            usuarioActual = obj;
            InitializeComponent();
        }

        public frmFacturas(int id, string nombre, string cedula, string email)
        {
            InitializeComponent();
            _idCliente = id;
            txtNombreCliente.Text = nombre;
            txtCedulaCliente.Text = cedula;
            txtEmailCliente.Text = email;
        }

        private void frmFacturas_Load(object sender, EventArgs e)
        {
            txtTelefonoUser.Text = usuarioActual.Telefono;
            txtNombreUser.Text = usuarioActual.NombreCompleto;
        }


        private void txtNombreCliente_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
