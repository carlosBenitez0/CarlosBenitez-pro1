using CarlosB01.DAO;
using CarlosB01.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarlosB01.VISTA
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
            Carga();
            clear();
        }

        void Carga() {
            dtgListaUsuarios.Rows.Clear();
            ClsDUserList cls = new ClsDUserList();
            List<UserList> Lista = cls.CargarDatosUserList();

            foreach (var iteracion in Lista)
            {
                dtgListaUsuarios.Rows.Add(iteracion.Id, iteracion.NombreUsuario, iteracion.Apellido, iteracion.Edad, iteracion.Pass);
            }
        }

        void clear() {
            txtId.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtEdad.Clear();
            txtPass.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (txtId.Text.Equals(""))
            {
                ClsDUserList cls = new ClsDUserList();
                //cls.SaveDatosUserList(txtNombre.Text, txtApellido.Text, Convert.ToInt32(txtEdad), Convert.ToInt32( txtPass));
                UserList userlist = new UserList();
                userlist.NombreUsuario = txtNombre.Text;
                userlist.Apellido = txtApellido.Text;
                userlist.Edad = Convert.ToInt32(txtEdad.Text);
                userlist.Pass = txtPass.Text;
                cls.SaveDatosUser(userlist);
            }
            else
            {
                ClsDUserList cls = new ClsDUserList();
                UserList userlist = new UserList();

                userlist.Id = Convert.ToInt32(txtId.Text);
                userlist.NombreUsuario = txtNombre.Text;
                userlist.Apellido = txtApellido.Text;
                userlist.Edad = Convert.ToInt32(txtEdad.Text);
                userlist.Pass = txtPass.Text;
                cls.UpdateDatosUser(userlist);
            }
            
            Carga();
            clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClsDUserList cls = new ClsDUserList();
            UserList userlist = new UserList();

            userlist.Id = Convert.ToInt32(txtId.Text);

            cls.DeleteDatosUser(userlist);
            Carga();
            clear();
        }

        private void dtgListaUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dtgListaUsuarios.CurrentRow.Cells[0].Value.ToString();
            string nombre = dtgListaUsuarios.CurrentRow.Cells[1].Value.ToString();
            string apellido = dtgListaUsuarios.CurrentRow.Cells[2].Value.ToString();
            string edad = dtgListaUsuarios.CurrentRow.Cells[3].Value.ToString();
            string pass = dtgListaUsuarios.CurrentRow.Cells[4].Value.ToString();

            txtId.Text = id;
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtEdad.Text = edad;
            txtPass.Text = pass;
        }
    }
}
