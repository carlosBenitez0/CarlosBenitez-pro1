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
    public partial class frmDocumento : Form
    {
        public frmDocumento()
        {
            InitializeComponent();
        }
        void Limpiar() {
            txtId.Clear();
            txtNombreDocumento.Clear();
        }
        void CargarDatos() {
            dataGridView1.Rows.Clear();
            ClsDDocumento cls = new ClsDDocumento();

            List<tb_documento> lista = cls.CargarDatosDocumento();
            foreach (var iteracion in lista) {
                dataGridView1.Rows.Add(iteracion.iDDocumento, iteracion.nombreDocumento);
            }
        }
        private void frmDocumento_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            if (txtId.Text.Equals(""))
            {

                ClsDDocumento cls = new ClsDDocumento();
                tb_documento tb = new tb_documento();
                tb.nombreDocumento = txtNombreDocumento.Text;
                cls.GuardarDatosDocumento(tb);
            }
            else
            {
                ClsDDocumento cls = new ClsDDocumento();
                tb_documento tb = new tb_documento();
                tb.iDDocumento = Convert.ToInt32(txtId.Text);
                tb.nombreDocumento = txtNombreDocumento.Text;
                cls.ModificarDatosDocumento(tb);
            }

            CargarDatos();
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ClsDDocumento cls = new ClsDDocumento();
            tb_documento tb = new tb_documento();
            tb.iDDocumento = Convert.ToInt32(txtId.Text);

            cls.EliminarDatosDocumento(tb);

            CargarDatos();
            Limpiar();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNombreDocumento.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
