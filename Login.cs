using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;
using CapaEntidad;

namespace Billig_System_L_M
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();//Cerrar programa
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            Usuarios usuarios = new CN_Usuarios().Listar().Where(u => u.Email == editText_User.Text && u.Codigo_Usuario == 
            editText_Password.Text).FirstOrDefault();

            if (usuarios != null)
            { 
                Home home = new Home(usuarios);
                home.FormClosing += frm_closing;
                this.Hide();
                home.Show();
            }
            else
            {
                MessageBox.Show("No se encontro este Usuario", "Alert", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            editText_User.Text = "";
            editText_Password.Text = "";

            this.Show();
        }
    }
}
