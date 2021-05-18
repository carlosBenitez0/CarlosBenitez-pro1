using LoginConMatriz.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginConMatriz.VISTAS
{
    public partial class frmAlumno : Form
    {
        public frmAlumno()
        {
            InitializeComponent();
        }

        private void frmAlumno_Load(object sender, EventArgs e)
        {
            AlumnoDao dao = new AlumnoDao();
            foreach(var i in dao.alumnos)
            {
                foreach (var j in dao.alumnos) {
                    dataGridView1.Rows.Add(i.ToString(), j.ToString());
                }
                    
            }
        }
    }
}
