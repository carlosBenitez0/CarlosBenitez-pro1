using CarlosB01.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarlosB01.DAO
{
    class ClsDJoin
    {
        public List<List<Object>> JoinUsuarioType(){

            List<List<Object>> matriz = new List<List<object>>();

            using (programacionEntities db = new programacionEntities())
            {
                var lista = (from usuario in db.UserLists
                            from type in db.typeOfUsers
                            where usuario.FK_IdTypeOfUser == type.IdTypeOfUser

                            select new
                            { 
                                usuario.Id,
                                usuario.NombreUsuario,
                                type.IdTypeOfUser,
                                type.TypeOfUserName

                            }).ToList();
                for (int i = 0; i < lista.Count; i++) {

                    matriz.Add(new List<Object>() {

                        lista[i].Id, lista[i].NombreUsuario, lista[i].IdTypeOfUser, lista[i].TypeOfUserName
                    }); 
                }
            }
            return matriz;
        }
    }
}
