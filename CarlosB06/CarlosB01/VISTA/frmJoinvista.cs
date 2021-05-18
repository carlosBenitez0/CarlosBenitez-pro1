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
    public partial class frmJoinvista : Form
    {
        public frmJoinvista()
        {
            InitializeComponent();
        }

       

        void Cargar(){
            dataGridView1.Rows.Clear();
            using (programacionEntities db = new programacionEntities())
            {
                var consulta = (from user in db.UserLists
                               from type in db.typeOfUsers                                          //Contains es como like en sql        
                               where user.FK_IdTypeOfUser == type.IdTypeOfUser && user.NombreUsuario.Contains(textBox1.Text)

                               select new {
                                   user.NombreUsuario,
                                   type.TypeOfUserName
                               }).ToList();
                foreach (var iteracion in consulta) {
                    dataGridView1.Rows.Add(iteracion.NombreUsuario, iteracion.TypeOfUserName);
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmJoinvista_Load(object sender, EventArgs e)
        {
            Cargar();
        }
    }
}
