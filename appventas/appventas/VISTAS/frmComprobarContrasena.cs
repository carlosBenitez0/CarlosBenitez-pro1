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
    public partial class frmComprobarContrasena : Form
    {
        public tb_usuario tb = new tb_usuario();
        public frmComprobarContrasena(tb_usuario tb)
        {
            InitializeComponent();
            this.tb = tb;
        }

        private void frmComprobarContrasena_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Antes de modificar un usuario deberá confirmar la contraseña");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ClsDUsuario cls = new ClsDUsuario();
            int comprobar = cls.Confirmar(tb);

            if (comprobar == 1)
            {
                frmUsuario frm = new frmUsuario();
                MessageBox.Show("Contraseña confirmada");

                frm.comprobar = 1;

                this.Hide();
                frm.Show();

            }
            else
            {
                MessageBox.Show("Contraseña incorrecta");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmUsuario frm = new frmUsuario();
            this.Hide();
            frm.Show();
        }
    }
}
