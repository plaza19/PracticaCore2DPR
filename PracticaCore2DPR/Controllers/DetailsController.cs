using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaCore2DPR.Models;
using PracticaCore2DPR.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore2DPR.Controllers
{
    public class DetailsController : Controller
    {

        private RepositoryLibros repo;

        public DetailsController(RepositoryLibros repo)
        {
            this.repo = repo;
        }

        public IActionResult Details(int idLibro, String actionString)
        {
            if (actionString == "comprar")
            {
                HttpContext.Session.SetString(idLibro.ToString(),idLibro.ToString());
                Libro l = this.repo.getLibroById(idLibro);
                return View(l);
            }else
            {
                Libro l = this.repo.getLibroById(idLibro);
                return View(l);
            }

           
            
        }
    }
}
