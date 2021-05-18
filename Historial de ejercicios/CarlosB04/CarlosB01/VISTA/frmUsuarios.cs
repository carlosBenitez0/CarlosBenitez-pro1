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
            using (programacionEntities db = new programacionEntities()) {
                var Lista = db.UserLists.ToList();
                foreach (var iteracion in Lista) {
                    dtgListaUsuarios.Rows.Add(iteracion.Id, iteracion.NombreUsuario, iteracion.Apellido, iteracion.Edad, iteracion.Pass);
                }
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
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            int edad = Convert.ToInt32(txtEdad.Text);
            string pass = txtPass.Text;

            try
            {
                using (programacionEntities db = new programacionEntities())
                {
                    UserList userlist = new UserList();
                    userlist.NombreUsuario = nombre;
                    userlist.Apellido = apellido;
                    userlist.Edad = edad;
                    userlist.Pass = pass;

                    db.UserLists.Add(userlist);
                    db.SaveChanges();

                    MessageBox.Show("Save");
                }

            }
            catch (Exception ex){
                MessageBox.Show("Error: " + ex);
            }
            Carga();
            clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                /*UserList userlist = new UserList();
                int eliminar = Convert.ToInt32(txtId.Text);
                using (programacionEntities db = new programacionEntities())
                {
                    userlist = db.UserLists.Find(eliminar);
                    db.UserLists.Remove(userlist);
                    db.SaveChanges();
                    MessageBox.Show("Removido");

                }*/

                using (programacionEntities db = new programacionEntities())
                {
                    int eliminar = Convert.ToInt32(txtId.Text);
                    UserList user = db.UserLists.Where(x => x.Id == eliminar).Select(x => x).FirstOrDefault();
                    db.UserLists.Remove(user);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            Carga();
            clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (programacionEntities db = new programacionEntities())
                {
                    int actualizar = Convert.ToInt32(txtId.Text);
                    UserList user = db.UserLists.Where(x => x.Id == actualizar).Select(x => x).FirstOrDefault();
                    user.NombreUsuario = txtNombre.Text;
                    user.Apellido = txtApellido.Text;
                    user.Edad = Convert.ToInt32(txtEdad.Text);
                    user.Pass = txtPass.Text;
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
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
