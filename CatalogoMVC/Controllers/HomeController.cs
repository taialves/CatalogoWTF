using CatalogoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CatalogoMVC.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            return View();
        }

    }
}
