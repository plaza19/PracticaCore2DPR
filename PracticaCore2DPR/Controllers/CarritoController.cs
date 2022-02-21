using Microsoft.AspNetCore.Mvc;
using PracticaCore2DPR.Filters;
using PracticaCore2DPR.Models;
using PracticaCore2DPR.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PracticaCore2DPR.Controllers
{
    public class CarritoController : Controller
    {
        private RepositoryLibros repo;

        public CarritoController(RepositoryLibros repo)
        {
            this.repo = repo;
        }

        public IActionResult Carrito(String actionString, String idLibro)
        {

            if (actionString == "eliminar")
            {
                HttpContext.Session.Remove(idLibro);
            }

            List<Libro> libros = new List<Libro>();

            foreach(String id in this.HttpContext.Session.Keys)
            {
                libros.Add(this.repo.getLibroById(int.Parse(id)));
            }

            if (libros.Count() == 0)
            {
                ViewBag.mensaje = "No hay libros en el carrito";
                return View();
            }else
            {
                return View(libros);
            }

            
        }
        [AuthorizeUsers]
        public IActionResult FinalizarCompra()
        {
            int idFactura = 0;
            foreach (String id in HttpContext.Session.Keys)
            {
                Libro l = this.repo.getLibroById(int.Parse(id));
                Pedido p = new Pedido();
                int newid = this.repo.getNewid();
                
                if (idFactura == 0)
                {
                    idFactura = newid + 2;
                }

                p.idPedido = newid;
                p.idFactura = idFactura;
                p.idLibro = int.Parse(id);
                p.idUsuario = int.Parse( HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                p.cantidad = 1;
                p.fecha = DateTime.Now;
                this.repo.SavePedido(p);

                

            }

            HttpContext.Session.Clear();

            return RedirectToAction("ListaPedidos", "User");

        }
    }
}
