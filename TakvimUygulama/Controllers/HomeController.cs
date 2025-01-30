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

        // Ana Sayfa (Index) sayfasý
        public IActionResult Index()
        {
            return View();
        }

        // Privacy sayfasý
        public IActionResult Privacy()
        {
            return View();
        }

        // Error sayfasý (Hata sayfasý)
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Günlük Plan sayfasý
        public IActionResult Daily()
        {
            return View();
        }

        // Haftalýk Plan sayfasý
        public IActionResult Weekly()
        {
            return View();
        }

        // Aylýk Plan sayfasý
        public IActionResult Monthly()
        {
            return View();
        }

        // Anasayfa sayfasý (Giriþ sonrasý yönlendirilecek)
        public IActionResult Anasayfa()
        {
            return View();
        }

        // Giriþ iþlemi sonrasý yönlendirme
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Basit bir kullanýcý doðrulama örneði
            if (username == "admin" && password == "admin123") // Örnek kullanýcý adý ve þifre
            {
                // Giriþ baþarýlý, anasayfaya yönlendir
                return RedirectToAction("Anasayfa");
            }
            else
            {
                // Hata durumunda login sayfasýna geri dön
                ViewBag.ErrorMessage = "Kullanýcý adý veya þifre hatalý!";
                return View("Index"); // Giriþ sayfasý olarak Index'e dön
            }
        }
    }
}
