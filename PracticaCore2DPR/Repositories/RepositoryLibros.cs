using PracticaCore2DPR.Data;
using PracticaCore2DPR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore2DPR.Repositories
{
    public class RepositoryLibros
    {
        private LibrosContext context;

        public RepositoryLibros(LibrosContext context)
        {
            this.context = context;
        }


        public List<Libro> getAllLibros(int page)
        {

            int perPage = 6;
            int initial;
            int final;

            initial = (page * perPage) - (perPage);



            var consulta = (from data
                           in this.context.libros
                            select data).Skip(initial).Take(perPage);

            if (consulta.Count() == 0)
            {
                return null;
            }else
            {
                return consulta.ToList();
            }
            
        }
        
        public List<Libro> getAllLibrosByGenero(int idGenero)
        {
            var consulta = from data
                           in this.context.libros
                           where data.idGenero == idGenero
                           select data;

            if (consulta.Count() == 0)
            {
                return null;
            }
            else
            {
                return consulta.ToList();
            }
        }

        public List<Genero> getAllGeneros()
        {
            var consulta = from data 
                           in this.context.generos 
                           select data;

            if (consulta.Count() == 0)
            {
                return null;
            }
            else
            {
                return consulta.ToList();
            }

        }

        public Libro getLibroById(int idLibro)
        {
            var consulta = from data 
                           in this.context.libros 
                           where data.idLibro == idLibro 
                           select data;

            return consulta.FirstOrDefault();
        }

        public int getNewid()
        {
            if (context.pedidos.Count() == 0)
            {
                return 1;
            }else
            {
                return context.pedidos.Max(u => u.idPedido) + 1;
            }
            
           
        }

        public void SavePedido(Pedido p)
        {
            this.context.pedidos.Add(p);
            this.context.SaveChanges();
        }

        public int getNumberOfBooks()
        {
            return this.context.libros.Count();
        }

        

    }
}
