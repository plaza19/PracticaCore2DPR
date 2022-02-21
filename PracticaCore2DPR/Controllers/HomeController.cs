using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PracticaCore2DPR.Models;
using PracticaCore2DPR.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore2DPR.Controllers
{
    public class HomeController : Controller
    {
        private RepositoryLibros repo;

        public HomeController(RepositoryLibros repo)
        {
            this.repo = repo;
        }

        public IActionResult Index(int? idGenero, int page)
        {


            if (page == 0) {
                page = 1;
            }

            ViewBag.count = this.repo.getNumberOfBooks();
            ViewBag.page = page;
            ViewBag.perPage = 6;
            ViewBag.action = "normal";

            if (idGenero == null)
            {
                List<Libro> libros = this.repo.getAllLibros(page);
                return View(libros);
            }else
            {
                ViewBag.action = "genero";
                List<Libro> libros = this.repo.getAllLibrosByGenero(idGenero.Value);
                return View(libros);
            }

            
        }

      


        public IActionResult Privacy()
        {
            return View();
        }

      
    }
}
