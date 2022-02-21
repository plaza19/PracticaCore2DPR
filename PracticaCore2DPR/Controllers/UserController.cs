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
    public class UserController : Controller
    {
        private RepositoryUsers repo;

        public UserController(RepositoryUsers repo)
        {
            this.repo = repo;
        }

        [AuthorizeUsers]
        public IActionResult Profile()
        {
            int id = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            User u = this.repo.getUserById(id);
            return View(u);
        }

        [AuthorizeUsers]
        public IActionResult ListaPedidos()
        {
            List<VistaPedidos> pedidos = this.repo.getPedidosFromUser(int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));

            if (pedidos == null)
            {
                ViewBag.mensaje = "No tienes pedidos";
                return View();
            }else
            {
                return View(pedidos);
            }
        }
    }
}
