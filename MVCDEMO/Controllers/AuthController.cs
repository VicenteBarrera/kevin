using Microsoft.AspNetCore.Mvc;
using MVCDEMO.Models;
using Newtonsoft.Json;
using System.Text;

namespace MVCDEMO.Controllers
{
    public class AuthController : Controller
    {
      
            private readonly HttpClient _httpClient;

            public AuthController()
            {
                _httpClient = new HttpClient();
            }

            [HttpGet]
            public IActionResult Login()
            {
            ViewBag.HideNavBar = true;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {

            Console.WriteLine(userLogin);


            if (userLogin.Username == "rolando" && userLogin.Password == "1234" )
            {
                HttpContext.Session.SetString("Username", userLogin.Username);
                return RedirectToAction("Welcome", "Home");
            }

            ViewBag.HideNavBar = true;
            ViewBag.Error = "Credenciales invalidas"; 
            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
    
}
