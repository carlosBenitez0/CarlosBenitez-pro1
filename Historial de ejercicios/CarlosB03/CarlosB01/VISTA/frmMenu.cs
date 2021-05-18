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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void clickParaMásInformaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAcercaDe frm = new frmAcercaDe();
            frm.MdiParent = this;
            frm.Show();
        }

        private void listaDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListaDeUsuariosVisual frmusu = new frmListaDeUsuariosVisual();
            frmusu.MdiParent = this;
            frmusu.Show();
        }
        public string usuarioEstado;
        private void frmMenu_Load(object sender, EventArgs e)
        {
            label1.Text = "Ha iniciado sesión como: "+ usuarioEstado;
        }

        private void sumaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOperacionesMatematicas frmop = new frmOperacionesMatematicas();
            frmop.MdiParent = this;
            frmop.btnResta.Enabled = false;
            frmop.Show();
        }

        private void restaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOperacionesMatematicas frmop = new frmOperacionesMatematicas();
            frmop.MdiParent = this;
            frmop.btnSuma.Enabled = false;
            frmop.Show();
        }
    }
}
