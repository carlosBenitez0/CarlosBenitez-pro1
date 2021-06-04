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
    public partial class frmVenta : Form
    {
        public frmVenta()
        {
            InitializeComponent();
        }

        void UltimoCorrelativoDeVenta() {

            var consultarUltimaVenta = new ClsDVenta();

            int lista = 0;

            //List<tb_venta> listaVenta = consultarUltimaVenta.UltimaVenta();

            foreach (var i in consultarUltimaVenta.UltimaVenta())
            {
                lista = i.iDVenta;
            }
            lista++;

            txtUltimaVenta.Text = lista.ToString();
        }

        private void frmVenta_Load(object sender, EventArgs e)
        {
            txtBuscarProducto.Focus();
            UltimoCorrelativoDeVenta();

            ClsDCliente cls = new ClsDCliente();

            cbxCliente.DataSource = cls.CargarDatosCliente();
            //Mostrar miembros de la db, mostramos los nombres de los clientes.
            cbxCliente.DisplayMember = "nombreCliente";
            cbxCliente.ValueMember = "iDCliente";

            ClsDDocumento clsD = new ClsDDocumento();
            cbxTDocumento.DataSource = clsD.CargarDatosDocumento();
            cbxTDocumento.DisplayMember = "nombreDocumento";
            cbxTDocumento.ValueMember = "iDDocumento";

            //using (sistema_ventasEntities db = new sistema_ventasEntities())
            //{
            //    var consultaCliente = db.tb_cliente.ToList();
            //    cbxCliente.DataSource = consultaCliente;
            //    //Mostrar miembros de la db, mostramos los nombres de los clientes.
            //    cbxCliente.DisplayMember = "nombreCliente";
            //    cbxCliente.ValueMember = "iDCliente";

            //    var consultaDocumento = db.tb_documento.ToList();
            //    cbxCliente.DataSource = consultaDocumento;
            //    cbxCliente.DisplayMember = "nombreDocumento";
            //    cbxCliente.ValueMember = "iDDocumento";
            //}
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarProductoFiltro frm = new frmBuscarProductoFiltro();
            frm.Show();
        }

        void calcular() {
            try
            {
                Double precio, cantidad, total;

                precio = Convert.ToDouble(txtPrecioProducto.Text);
                cantidad = Convert.ToDouble(txtCantidad.Text);
                total = precio * cantidad;
                txtTotal.Text = total.ToString();
            }
            catch (Exception ex)
            {
                if (txtCantidad.Text.Equals(""))
                {
                    txtCantidad.Text = "0";
                    //Selecciona todo el texto que esta en el txtCantidad siempre que este vacio
                    txtCantidad.SelectAll();
                }
            }
        }
        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            
        }
        //performClick();

        void clear() {
            txtIdProducto.Clear();
            txtCantidad.Clear();
            txtNombreProducto.Clear();
            txtPrecioProducto.Clear();
            txtTotal.Clear();
        }
        void calcularTotal() {
            Double suma = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                //Como basicamente las columnas y filas son como arreglos, por eso los denotamos como arreglos con los corchetes
                //Vamos sumando todos los totales
                String datosAOperarTotal = dataGridView1.Rows[i].Cells[4].Value.ToString();

                Double datosConvertidos = Convert.ToDouble(datosAOperarTotal);

                //suma += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value.ToString());

                suma += Convert.ToDouble(datosConvertidos);

                txtTotalFinal.Text = suma.ToString();
            }
        }

        void AgregarAlDataGrid() {
            calcular();
            dataGridView1.Rows.Add(txtIdProducto.Text, txtNombreProducto.Text, txtPrecioProducto.Text, txtCantidad.Text, txtTotal.Text);
            calcularTotal();

            clear();
            //txtBuscarProducto.Focus();
            //Seleccionar la ultima fila
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
            int ultimaFila = dataGridView1.Rows.Count - 1;
            dataGridView1.Rows[ultimaFila].Selected = true;
            //
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarAlDataGrid();
        }

        private void txtBuscarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            //if (txtBuscarProducto.Focus() && e.KeyCode == Keys.Enter)
            //{
            //    //btnBuscar_Click(sender, e);//llama al evento click del boton
            //    //btnBuscar_Click(SendKeys.Send());
            //    btnBuscar.PerformClick();
            //}
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            //if (txtCantidad.Focus() && e.KeyCode == Keys.Enter)
                //{
                //    //btnBuscar_Click(sender, e);//llama al evento click del boton
                //    //btnBuscar_Click(SendKeys.Send());
                //    btnAgregar.PerformClick();
                //}
            }

            private void txtBuscarProducto_KeyPress(object sender, KeyPressEventArgs e)
            {
               
                if (e.KeyChar == 13) 


                if (txtBuscarProducto.Text.Equals(""))
                {
                    e.Handled = true;
                    btnBuscar.PerformClick();

                }
                else{
                    e.Handled = true;
                    ClsDProducto prod = new ClsDProducto();
                    var busqueda = prod.BuscarProducto(Convert.ToInt32(txtBuscarProducto.Text));

                    if (busqueda.Count < 1)
                    {
                        MessageBox.Show("El codigo no existe");
                        txtBuscarProducto.Text = "";
                    }

                    foreach (var i in busqueda)
                    {
                        txtIdProducto.Text = i.idProducto.ToString();
                        txtNombreProducto.Text = i.nombreProducto;
                        txtPrecioProducto.Text = i.precioProducto;
                        txtCantidad.Text = "1";
                        txtCantidad.Focus();
                        txtBuscarProducto.Text = "";
                    }
                }
                
            }
            

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                btnAgregar.PerformClick();
                
                txtBuscarProducto.Focus();
            }

        }

        private void btnGuardarVentas_Click(object sender, EventArgs e)
        {

            try {
                ClsDVenta ventas = new ClsDVenta();
                tb_venta tbventa = new tb_venta();
                tbventa.iDDocumento = Convert.ToInt32(cbxTDocumento.SelectedValue.ToString());
                tbventa.iDCliente = Convert.ToInt32(cbxCliente.SelectedValue.ToString());
                tbventa.iDUsuario = 1;
                tbventa.totalVenta = Convert.ToDecimal(txtTotalFinal.Text);
                tbventa.fecha = Convert.ToDateTime(dtpFecha.Text);
                ventas.save(tbventa);
                MessageBox.Show("save");

                ClsDDetalle clsDetalle = new ClsDDetalle();
                tb_detalleVenta tb_detalle = new tb_detalleVenta();
                foreach (DataGridViewRow dtgv in dataGridView1.Rows)
                {
                    tb_detalle.iDDetalleVenta = Convert.ToInt32(txtUltimaVenta.Text);
                    tb_detalle.idProducto = Convert.ToInt32(dtgv.Cells[0].Value.ToString());
                    tb_detalle.cantidad = Convert.ToInt32(dtgv.Cells[2].Value.ToString());
                    tb_detalle.precio = Convert.ToDecimal(dtgv.Cells[3].Value.ToString());
                    tb_detalle.total = Convert.ToDecimal(dtgv.Cells[4].Value.ToString());
                    clsDetalle.guardarDetalleVenta(tb_detalle);
                }
                UltimoCorrelativoDeVenta();
                dataGridView1.Rows.Clear();
                txtTotalFinal.Text = "";

            }
            catch (Exception ex) {
                MessageBox.Show("Error");
            }

        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            calcularTotal();
        }

        //if (txtBuscarProducto.Focus() && e.KeyCode == Keys.Enter)
        //    {
        //        //btnBuscar_Click(sender, e);//llama al evento click del boton
        //        //btnBuscar_Click(SendKeys.Send());
        //        btnBuscar.PerformClick();

        //    } else if (txtCantidad.Focus() && e.KeyCode == Keys.Enter) {
        //        btnAgregar.PerformClick();

        //    }
    }
}
