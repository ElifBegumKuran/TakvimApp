using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TakvimUygulama.Models;

namespace TakvimUygulama.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Ana Sayfa (Index) sayfas�
        public IActionResult Index()
        {
            return View();
        }

        // Privacy sayfas�
        public IActionResult Privacy()
        {
            return View();
        }

        // Error sayfas� (Hata sayfas�)
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // G�nl�k Plan sayfas�
        public IActionResult Daily()
        {
            return View();
        }

        // Haftal�k Plan sayfas�
        public IActionResult Weekly()
        {
            return View();
        }

        // Ayl�k Plan sayfas�
        public IActionResult Monthly()
        {
            return View();
        }

        // Anasayfa sayfas� (Giri� sonras� y�nlendirilecek)
        public IActionResult Anasayfa()
        {
            return View();
        }

        // Giri� i�lemi sonras� y�nlendirme
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Basit bir kullan�c� do�rulama �rne�i
            if (username == "admin" && password == "admin123") // �rnek kullan�c� ad� ve �ifre
            {
                // Giri� ba�ar�l�, anasayfaya y�nlendir
                return RedirectToAction("Anasayfa");
            }
            else
            {
                // Hata durumunda login sayfas�na geri d�n
                ViewBag.ErrorMessage = "Kullan�c� ad� veya �ifre hatal�!";
                return View("Index"); // Giri� sayfas� olarak Index'e d�n
            }
        }
    }
}
