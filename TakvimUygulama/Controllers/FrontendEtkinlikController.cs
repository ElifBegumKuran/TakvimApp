using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using TakvimUygulama.Data; // Etkinlik modelini dahil ediyoruz

namespace TakvimUygulama.Controllers
{
    public class FrontendEtkinlikController : Controller
    {
        private readonly HttpClient _httpClient;

        public FrontendEtkinlikController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            // API'den etkinlikleri almak için GET isteği gönderiyoruz
            var etkinlikler = await _httpClient.GetFromJsonAsync<List<Etkinlik>>("https://localhost:5001/api/Etkinlik");

            // Etkinlikleri View'a gönderiyoruz
            return View(etkinlikler);
        }
    }
}
