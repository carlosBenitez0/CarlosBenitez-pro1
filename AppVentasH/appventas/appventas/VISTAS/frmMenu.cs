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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }
        //Public porque queremos acceder a el desde otras clases
        //static porque no queremos que el valor del objeto cambie en ningun momento
        
        private void formCRUDClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente frm = new frmCliente();
            frm.MdiParent = this;
            frm.Show();
            //AbrirFormulario(frm);
        }

        private void formCRUDUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuario frm = new frmUsuario();
            frm.MdiParent = this;
            frm.Show();
            //AbrirFormulario(frm);
        }

        private void formCRUDDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDocumento frm = new frmDocumento();
            frm.MdiParent = this;
            frm.Show();
            //AbrirFormulario(frm);
        }

        private void formCRUDProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProducto frm = new frmProducto();
            frm.MdiParent = this;
            frm.Show();
            //AbrirFormulario(frm);
        }
        public static frmVenta frmVenta = new frmVenta();
        private void formularioDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVenta.MdiParent = this;
            frmVenta.Show();
            //AbrirFormulario(frm);
        }


        //private void AbrirFormulario(object formParam)
        //{
        //    if (this.menuStrip1.Controls.Count > 0)
        //    {
        //        this.menuStrip1.Controls.RemoveAt(0);

        //        Form frm = formParam as Form;
        //        frm.TopLevel = false;
        //        frm.Dock = DockStyle.Fill;

        //        this.menuStrip1.Controls.Add(frm);
        //        this.menuStrip1.Tag = frm;
        //        frm.Show();
        //    }
        //}
    }
}
