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
    public partial class frmOperacionesMatematicas : Form
    {
        public frmOperacionesMatematicas()
        {
            InitializeComponent();
        }

        private void btnSuma_Click(object sender, EventArgs e)
        {
            //Para manejo de excepciones

            try
            {
                int suma;
                int dato1 = Convert.ToInt32(txtDato1.Text);
                int dato2 = Convert.ToInt32(txtDato2.Text);
                suma = dato1 + dato2;
                txtResultado.Text = suma.ToString();
            }
            //Creamos una variable ex de tipo de dato exeption
            catch (Exception ex)
            {
                MessageBox.Show("Ahh! Tus datos no son correctos, revisa" + ex.ToString());
            }




            /*int suma;
            suma = Convert.ToInt32(txtDato1.Text) + Convert.ToInt32(txtDato2.Text);
            txtResultado.Text = suma.ToString();*/
            //txtResultado = txtDato1.Text + txtDato2.Text;
        }

        private void btnResta_Click(object sender, EventArgs e)
        {
            try
            {
                int resta;
                int dato1 = Convert.ToInt32(txtDato1.Text);
                int dato2 = Convert.ToInt32(txtDato2.Text);
                resta = dato1 - dato2;
                txtResultado.Text = resta.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ahh! Tus datos no son correctos, revisa" + ex.ToString());
            }

        }
    }
}
