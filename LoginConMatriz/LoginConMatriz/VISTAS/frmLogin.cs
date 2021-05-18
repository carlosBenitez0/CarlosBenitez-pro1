using LoginConMatriz.DOMINIO;
using LoginConMatriz.NEGOCIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginConMatriz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            this.Close();
            /*int[][] numeros;
            numeros = new int[3][];
            numeros[0] = new int[2] { 1, 2 };
            numeros[1] = new int[2] { 3, 4 };
            numeros[2] = new int[2] { 4, 5 };

            for (int i = 0; i < numeros.Length; i++)
            {
                for(int j = 0; j < numeros[i]; j++)
                {
                    MessageBox.Show(numeros[i][j]);
                }
            }*/
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.User = txtUser.Text;
            log.Password = txtPassword.Text;

            ClsLogin clslog = new ClsLogin();

            int variabledeevaluacion = clslog.accesoTridimecional(log);

            if (variabledeevaluacion == 1)
            {
                MessageBox.Show("Enter");
            }
            else
            {
                MessageBox.Show("Datos incorrectos");
            }
        }
    }
}
