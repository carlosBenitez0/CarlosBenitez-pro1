    using appventas.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appventas.DAO
{
    class ClsDDocumento
    {
        public List<tb_documento> CargarDatosDocumento()
        {
            List<tb_documento> Lista;


            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                Lista = db.tb_documento.ToList();
            }
            return Lista;
        }

        public void GuardarDatosDocumento(tb_documento tbParam)
        {

            try
            {
                using (sistema_ventasEntities db = new sistema_ventasEntities())
                {

                    tb_documento tb = new tb_documento();
                    tb.nombreDocumento = tbParam.nombreDocumento;

                    db.tb_documento.Add(tb);
                    db.SaveChanges();

                    MessageBox.Show("Save");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }
        
        public void EliminarDatosDocumento(tb_documento tbParam)
        {
            try
            {
                using (sistema_ventasEntities db = new sistema_ventasEntities())
                {
                    tbParam = db.tb_documento.Find(tbParam.iDDocumento);
                    db.tb_documento.Remove(tbParam);
                    db.SaveChanges();
                    MessageBox.Show("Removido");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }
        public void ModificarDatosDocumento(tb_documento tbParam)
        {
            try
            {
                using (sistema_ventasEntities db = new sistema_ventasEntities())
                {
                    int update = tbParam.iDDocumento;
                    tb_documento tb = db.tb_documento.Where(x => x.iDDocumento == update).Select(x => x).FirstOrDefault();
                    tb.nombreDocumento = tbParam.nombreDocumento;
                    
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
