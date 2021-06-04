using appventas.DAO;
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
    public partial class frmBuscarProductoFiltro : Form
    {
        public frmBuscarProductoFiltro()
        {
            InitializeComponent();
        }
        void cargarDatos(){
            var clsDProducto = new ClsDProducto();
            dataGridView1.Rows.Clear();

            foreach (var i in clsDProducto.CargarProductoFiltro(textBox1.Text)) {
                dataGridView1.Rows.Add(i.idProducto, i.nombreProducto, i.precioProducto);
            }

        }
        private void frmBuscarProductoFiltro_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            cargarDatos();
        }

        void Envio() {
            String id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            String nombre = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            String precio = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            frmMenu.frmVenta.txtIdProducto.Text = id;
            frmMenu.frmVenta.txtNombreProducto.Text = nombre;
            frmMenu.frmVenta.txtPrecioProducto.Text = precio;
            frmMenu.frmVenta.txtCantidad.Focus();
            this.Close();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Envio();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            //podemos usar este key down para abrir el formulario
            if (e.KeyCode == Keys.Enter) {
                Envio();
            }
        }
    }
}
