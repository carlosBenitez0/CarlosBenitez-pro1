using appventas.VISTAS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appventas.VistasD
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        //Para poder mover el form manteniendo el panelTop 1/2
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void AbrirFormulario(object formParam)
        {
            if (this.panelContenedor.Controls.Count > 0)
            {
                this.panelContenedor.Controls.RemoveAt(0);

                Form frm = formParam as Form;
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;

                this.panelContenedor.Controls.Add(frm);
                this.panelContenedor.Tag = frm;
                frm.Show();
            }
        }

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            //Para poder mover el form manteniendo el panelTop 2/2
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmUsuario());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmCliente());
        }

        private void btnDocumentos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmDocumento());
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmProducto());
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmVenta());
        }


    }
}
