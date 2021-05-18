using appventas.DAO;
using appventas.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appventas.VISTAS
{
    public partial class frmRegistro : Form
    {
        public frmRegistro()
        {
            InitializeComponent();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            ClsDRegistro cls = new ClsDRegistro();
            tb_usuario tbu = new tb_usuario();
            tbu.email = txtUsuario.Text;
            tbu.contrasena = txtPassword.Text;

            cls.RegistrarUsuario(tbu);

            this.Hide();
            frm.Show();
        }
    }
}
