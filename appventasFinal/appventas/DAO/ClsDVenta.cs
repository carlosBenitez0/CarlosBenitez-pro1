using appventas.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appventas.DAO
{
    class ClsDVenta
    {
        public List<tb_venta> UltimaVenta() {

            List<tb_venta> consultarUltimaVenta = new List<tb_venta>();

            using (sistema_ventasEntities db = new sistema_ventasEntities()){

                consultarUltimaVenta = db.tb_venta.ToList();
            }
            return consultarUltimaVenta;
        }

        public void save(tb_venta ventas)
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities()) {
                tb_venta venta = new tb_venta();
                venta.iDDocumento = ventas.iDDocumento;
                venta.iDCliente = ventas.iDCliente;
                venta.iDUsuario = ventas.iDUsuario;
                venta.totalVenta = venta.totalVenta;
                venta.fecha = venta.fecha;
                db.tb_venta.Add(venta);
                db.SaveChanges();

            }
        }
    }
}
