using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyToFind.Controllers
{
    public class CriarCategorias : Controller
    {
        public IActionResult View1()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }
    }
}
