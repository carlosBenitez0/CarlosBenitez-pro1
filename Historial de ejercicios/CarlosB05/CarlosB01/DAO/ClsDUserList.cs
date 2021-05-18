using CarlosB01.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarlosB01.DAO
{
    class ClsDUserList
    {
        public List<UserList> CargarDatosUserList() {
            List<UserList> Lista;


            using (programacionEntities db = new programacionEntities())
            {
                Lista = db.UserLists.ToList();
            }
            return Lista;
        }

        public void SaveDatosUser(UserList user) {

            try
            {
                using (programacionEntities db = new programacionEntities())
                {

                    UserList userlist = new UserList();
                    userlist.NombreUsuario = user.NombreUsuario;
                    userlist.Apellido = user.Apellido;
                    userlist.Edad = user.Edad;
                    userlist.Pass = user.Pass;

                    db.UserLists.Add(userlist);
                    db.SaveChanges();

                    MessageBox.Show("Save");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }
        //public void SaveDatosUser(string nombre, string apellido, int edad, string pass)
        //{

        //    try
        //    {
        //        using (programacionEntities db = new programacionEntities())
        //        {

        //            UserList userlist = new UserList();
        //            userlist.NombreUsuario = nombre;
        //            userlist.Apellido = apellido;
        //            userlist.Edad = edad;
        //            userlist.Pass = pass;

        //            db.UserLists.Add(userlist);
        //            db.SaveChanges();

        //            MessageBox.Show("Save");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: " + ex);
        //    }
        //}

        public void DeleteDatosUser(UserList userlist)
        {
            try
            {
                using (programacionEntities db = new programacionEntities())
                {
                    userlist = db.UserLists.Find(userlist.Id);
                    db.UserLists.Remove(userlist);
                    db.SaveChanges();
                    MessageBox.Show("Removido");

                }

                /*using (programacionEntities db = new programacionEntities())
                {
                    int eliminar = Convert.ToInt32(txtId.Text);
                    UserList user = db.UserLists.Where(x => x.Id == eliminar).Select(x => x).FirstOrDefault();
                    db.UserLists.Remove(user);
                    db.SaveChanges();
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }
        public void UpdateDatosUser(UserList user) {
            try
            {
                using (programacionEntities db = new programacionEntities())
                {
                    int update = user.Id;
                    UserList userlist = db.UserLists.Where(x => x.Id == update).Select(x => x).FirstOrDefault();
                    userlist.NombreUsuario = user.NombreUsuario;
                    userlist.Apellido = user.Apellido;
                    userlist.Edad = Convert.ToInt32(user.Edad);
                    userlist.Pass = user.Pass;
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
