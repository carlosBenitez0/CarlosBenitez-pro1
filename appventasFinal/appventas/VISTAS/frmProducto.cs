﻿using appventas.DAO;
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
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
        }
        void Limpiar()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            txtEstado.Clear();
        }

        void CargarDatos()
        {
            dataGridView1.Rows.Clear();
            ClsDProducto cls = new ClsDProducto();

            List<tb_producto> lista = cls.CargarDatosProducto();
            foreach (var i in lista)
            {
                dataGridView1.Rows.Add(i.idProducto, i.nombreProducto, i.precioProducto, i.estadoProducto);
            }
        }
        private void frmProducto_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            if (txtId.Text.Equals(""))
            {
                ClsDProducto cls = new ClsDProducto();
                tb_producto tb = new tb_producto();
                tb.nombreProducto = txtNombre.Text;
                tb.precioProducto = txtPrecio.Text;
                tb.estadoProducto = txtEstado.Text;
                cls.GuardarDatosProducto(tb);
            }
            else
            {
                ClsDProducto cls = new ClsDProducto();
                tb_producto tb = new tb_producto();
                tb.idProducto = Convert.ToInt32(txtId.Text);
                tb.nombreProducto = txtNombre.Text;
                tb.precioProducto = txtPrecio.Text;
                tb.estadoProducto = txtEstado.Text;
                cls.ModificarDatosProducto(tb);
            }

            Limpiar();
            CargarDatos();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            ClsDProducto cls = new ClsDProducto();
            tb_producto tb = new tb_producto();

            tb.idProducto = Convert.ToInt32(txtId.Text);
            cls.EliminarDatosProducto(tb);

            Limpiar();
            CargarDatos();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtPrecio.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtEstado.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
