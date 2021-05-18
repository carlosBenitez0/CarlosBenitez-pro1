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
    public partial class frmUsuario : Form
    {
        public frmUsuario()
        {
            InitializeComponent();
        }
        void MostrarDatosUsuario() {
            dataGridView1.Rows.Clear();
            ClsDUsuario cls = new ClsDUsuario();
            List<tb_usuario> lista = cls.MostrarDatosUsuario();
            foreach (var iteracion in lista) {
                dataGridView1.Rows.Add(iteracion.iDUsuario, iteracion.email, iteracion.contrasena);
            }
        }

        void Limpiar(){
            txtId.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
        }
        private void frmUsuario_Load(object sender, EventArgs e)
        {
            MostrarDatosUsuario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ClsDUsuario cls = new ClsDUsuario();
            tb_usuario tb = new tb_usuario();

            tb.iDUsuario = Convert.ToInt32(txtId.Text);

            cls.EliminarUsuario(tb);

            MostrarDatosUsuario();
            Limpiar();

        }
        public int comprobar = 0;
        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Intentar hacerlo con un form de comprobacion
            ClsDUsuario cls = new ClsDUsuario();
            tb_usuario tbParaComprobar = new tb_usuario();
            tbParaComprobar.iDUsuario = Convert.ToInt32(txtId.Text);
            tbParaComprobar.contrasena = txtPassword.Text;

            frmComprobarContrasena frm = new frmComprobarContrasena(tbParaComprobar);
            this.Hide();
            frm.Show();

            if (comprobar == 1)
            {
                tb_usuario tb = new tb_usuario();

                tb.iDUsuario = Convert.ToInt32(txtId.Text);
                tb.email = txtEmail.Text;
                tb.contrasena = txtPassword.Text;

                cls.ModificarUsuario(tb);

                MessageBox.Show("Modificado");

                MostrarDatosUsuario();
                Limpiar();
            }

            //tb_usuario tb = new tb_usuario();
            //ClsDUsuario cls = new ClsDUsuario();

            //tb.iDUsuario = Convert.ToInt32(txtId.Text);
            //tb.email = txtEmail.Text;
            //tb.contrasena = txtPassword.Text;

            //cls.ModificarUsuario(tb);
            //MessageBox.Show("Modificado");

            //MostrarDatosUsuario();
            //Limpiar();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtPassword.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
