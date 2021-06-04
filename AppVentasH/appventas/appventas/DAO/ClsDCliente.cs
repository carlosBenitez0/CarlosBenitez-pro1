    using appventas.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appventas.DAO
{
    class ClsDCliente
    {
        public List<tb_cliente> CargarDatosCliente()
        {
            List<tb_cliente> Lista;


            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                Lista = db.tb_cliente.ToList();
            }
            return Lista;
        }

        public void GuardarDatosCliente(tb_cliente tbParam)
        {

            try
            {
                using (sistema_ventasEntities db = new sistema_ventasEntities())
                {

                    tb_cliente tb = new tb_cliente();
                    tb.nombreCliente = tbParam.nombreCliente;
                    tb.direccionCliente = tbParam.direccionCliente;
                    tb.duiCliente = tbParam.duiCliente;

                    db.tb_cliente.Add(tb);
                    db.SaveChanges();

                    MessageBox.Show("Save");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        public void EliminarDatosCliente(tb_cliente tbParam)
        {
            try
            {
                using (sistema_ventasEntities db = new sistema_ventasEntities())
                {
                    tbParam = db.tb_cliente.Find(tbParam.iDCliente);
                    db.tb_cliente.Remove(tbParam);
                    db.SaveChanges();
                    MessageBox.Show("Removido");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }
        public void ModificarDatosCliente(tb_cliente tbParam)
        {
            try
            {
                using (sistema_ventasEntities db = new sistema_ventasEntities())
                {
                    int update = tbParam.iDCliente;
                    tb_cliente tb = db.tb_cliente.Where(x => x.iDCliente == update).Select(x => x).FirstOrDefault();
                    tb.nombreCliente = tbParam.nombreCliente;
                    tb.direccionCliente = tbParam.direccionCliente;
                    tb.duiCliente = tbParam.duiCliente;

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }
    }
}
