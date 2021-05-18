using appventas.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appventas.DAO
{
    class ClsDProducto
    {
        public List<tb_producto> CargarDatosProducto()
        {
            List<tb_producto> Lista;


            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                Lista = db.tb_producto.ToList();
            }
            return Lista;
        }

        public void GuardarDatosProducto(tb_producto tbParam)
        {

            try
            {
                using (sistema_ventasEntities db = new sistema_ventasEntities())
                {

                    tb_producto tb = new tb_producto();
                    tb.nombreProducto = tbParam.nombreProducto;
                    tb.precioProducto = tbParam.precioProducto;
                    tb.estadoProducto = tbParam.estadoProducto;

                    db.tb_producto.Add(tb);
                    db.SaveChanges();

                    MessageBox.Show("Save");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        public void EliminarDatosProducto(tb_producto tbParam)
        {
            try
            {
                using (sistema_ventasEntities db = new sistema_ventasEntities())
                {
                    tbParam = db.tb_producto.Find(tbParam.idProducto);
                    db.tb_producto.Remove(tbParam);
                    db.SaveChanges();
                    MessageBox.Show("Removido");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }
        public void ModificarDatosProducto(tb_producto tbParam)
        {
            try
            {
                using (sistema_ventasEntities db = new sistema_ventasEntities())
                {
                    int update = tbParam.idProducto;
                    tb_producto tb = db.tb_producto.Where(x => x.idProducto == update).Select(x => x).FirstOrDefault();
                    tb.nombreProducto = tbParam.nombreProducto;
                    tb.precioProducto = tbParam.precioProducto;
                    tb.estadoProducto = tbParam.estadoProducto;

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }
        public List<tb_producto> CargarProductoFiltro(String filtro)
        {
            List<tb_producto> Lista = new List<tb_producto>();

            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                Lista = (from listadproductos in db.tb_producto
                         where listadproductos.nombreProducto.Contains(filtro)
                         select listadproductos).ToList();
            }
            return Lista;
        }
    }
}
