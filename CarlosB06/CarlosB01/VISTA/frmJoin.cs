using CarlosB01.DAO;
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
    public partial class frmJoin : Form
    {
        public frmJoin()
        {
            InitializeComponent();
        }

        private void frmJoin_Load(object sender, EventArgs e)
        {
            ClsDJoin join = new ClsDJoin();
            List<List<Object>> matriz = new List<List<object>>();
            matriz = join.JoinUsuarioType();
            for (int i = 0; i < matriz.Count; i++) {
                dataGridView1.Rows.Add(matriz[i][0], matriz[i][1], matriz[i][2], matriz[i][3]);
            }
            //     0         1             2              3
            // 0  Id, NombreUsuario, IdTypeOfUser, TypeOfUserName
            // 1  Id, NombreUsuario, IdTypeOfUser, TypeOfUserName
            // 2  Id, NombreUsuario, IdTypeOfUser, TypeOfUserName
            // 3  Id, NombreUsuario, IdTypeOfUser, TypeOfUserName
        }
    }
}
