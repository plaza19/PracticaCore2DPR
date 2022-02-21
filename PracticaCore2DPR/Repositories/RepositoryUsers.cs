using PracticaCore2DPR.Data;
using PracticaCore2DPR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore2DPR.Repositories
{

    public class RepositoryUsers
    {
        private LibrosContext context;

        public RepositoryUsers(LibrosContext context)
        {
            this.context = context;
        }

        public User existUser(String username, String password)
        {
            var consulta = from data
                           in this.context.usuarios
                           where data.email == username && password == data.password
                           select data;

            return consulta.FirstOrDefault();
        }

        public User getUserById(int id)
        {
            var consulta = from data in this.context.usuarios where data.idUsuario == id select data;

            return consulta.FirstOrDefault();
        }

        public List<VistaPedidos> getPedidosFromUser(int idUsuario)
        {
            var consulta = from data in this.context.vistaPedidos
                           where data.idUsuario == idUsuario
                           select data;

            if (consulta.Count() == 0)
            {
                return null;
            }else
            {
                return consulta.ToList();
            }

            
}

    }
}
