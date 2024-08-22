using Microsoft.AspNetCore.Mvc;
using MVCDEMO.Models;
using System.Diagnostics;

namespace MVCDEMO.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Welcome()
        {
            ViewBag.HideNavBar = true;
            var username = HttpContext.Session.GetString("Username"); // Recuperar el nombre de usuario de la sesión
            if (username == null)
            {
                // Si no hay sesión, redirigir al login
                return RedirectToAction("Login", "Auth");
            }

            ViewData["Username"] = username; // Pasar el nombre de usuario a la vista
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}