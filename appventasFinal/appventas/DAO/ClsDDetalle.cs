using appventas.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appventas.DAO
{
    class ClsDDetalle
    {
        public void guardarDetalleVenta(tb_detalleVenta dtventa) {
            using (sistema_ventasEntities db = new sistema_ventasEntities() ) {
                tb_detalleVenta detalle = new tb_detalleVenta();
                detalle.idVenta = dtventa.idVenta;
                detalle.idProducto = dtventa.idProducto;
                detalle.cantidad = dtventa.cantidad;
                detalle.precio = dtventa.precio;
                detalle.total = dtventa.total;
                db.tb_detalleVenta.Add(detalle);
                db.SaveChanges();
            }
        
        }
    }
}
