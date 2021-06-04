using appventas.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appventas.DAO
{
    class ClsDRegistro
    {
        public void RegistrarUsuario(tb_usuario tbu) {
            try {
                using (sistema_ventasEntities db = new sistema_ventasEntities())
                {
                    db.tb_usuario.Add(tbu);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Escriba una dirección de correo diferente");
            }
        }
    }
}
