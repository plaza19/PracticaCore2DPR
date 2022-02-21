using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PracticaCore2DPR.Models;
using PracticaCore2DPR.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PracticaCore2DPR.Controllers
{
    public class ManageController : Controller
    {

        private RepositoryUsers repo;


        public ManageController(RepositoryUsers repo)
        {
            this.repo = repo;
        }


        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost] 
        public async Task<IActionResult> LogIn(String username, String password)
        {
            User user = this.repo.existUser(username, password);

            if (user != null)
            {

                ClaimsIdentity identity =
                   new ClaimsIdentity
                   (CookieAuthenticationDefaults.AuthenticationScheme
                   , ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim
                    (new Claim(ClaimTypes.Name, user.nombre));
                identity.AddClaim
                    (new Claim(ClaimTypes.NameIdentifier, user.idUsuario.ToString()));
                identity.AddClaim(new Claim("profileimage", user.foto));

                ClaimsPrincipal userPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync
                    (CookieAuthenticationDefaults.AuthenticationScheme
                    , userPrincipal);

                return RedirectToAction("Profile", "User");

            }
            else
            {
                ViewBag.mensaje = "Error Login, comprueba usuario y password";
                return View();
            }
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
