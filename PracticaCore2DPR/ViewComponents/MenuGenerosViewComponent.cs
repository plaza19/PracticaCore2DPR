using Microsoft.AspNetCore.Mvc;
using PracticaCore2DPR.Models;
using PracticaCore2DPR.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore2DPR.ViewComponents
{
    public class MenuGenerosViewComponent : ViewComponent
    {
        private RepositoryLibros repo;
            public MenuGenerosViewComponent(RepositoryLibros repo)
            {
            this.repo = repo;
            }

        public async Task<IViewComponentResult> InvokeAsync(int idGenero)
        {
            List<Genero> generos = this.repo.getAllGeneros();

            return View(generos);
        }


    }

    }



