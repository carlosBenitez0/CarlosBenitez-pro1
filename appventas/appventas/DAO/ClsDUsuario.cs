using appventas.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appventas.DAO
{
    class ClsDUsuario
    {
        public List<tb_usuario> MostrarDatosUsuario() {
            List<tb_usuario> lista = new List<tb_usuario>();

            using (sistema_ventasEntities db = new sistema_ventasEntities()) {
                lista = db.tb_usuario.ToList();
            }

            return lista;
        }

        public void EliminarUsuario(tb_usuario tb) {
            

            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                tb = db.tb_usuario.Find(tb.iDUsuario);
                db.tb_usuario.Remove(tb);
                db.SaveChanges();
                MessageBox.Show("Removido");

            }
        }

        public void ModificarUsuario(tb_usuario tb) {

            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                int update = tb.iDUsuario;
                tb_usuario tbu = db.tb_usuario.Where(x => x.iDUsuario == update).Select(x => x).FirstOrDefault();
                tbu.email = tb.email;
                tbu.contrasena = tb.contrasena;
                db.SaveChanges();
            }
        }

        public int Confirmar(tb_usuario tbParametro)
        {
            //Intentar crear un metodo que me traiga solo las contrasenas y usarlo para comparar la contrasena del usuario con las de la db
            int comprobar = 0;
            ClsDUsuario cls = new ClsDUsuario();
            tb_usuario tb = new tb_usuario();

            List<tb_usuario> lista = cls.MostrarDatosUsuario();

            using (sistema_ventasEntities db = new sistema_ventasEntities()) {
                //tbParametro = db.tb_usuario.Find(tbParametro.iDUsuario);

                for (int i = 0; i < lista.Count; i++) {
                    if (lista[i].contrasena.Equals(tbParametro.contrasena))
                    {
                        comprobar = 1;
                    }
                }
            }


            //for (int i = 0; i < lista.Count; i++)
            //{
            //    if (lista[i].contrasena == pass)
            //    {
            //        comprobar = 1;
            //    }
            //}
            return comprobar;
        }
    }
}
