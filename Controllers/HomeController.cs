using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using watchyproject.Models;using watchyproject.Utility;

namespace watchyproject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly JsonFileReader _jsonFileReader; 


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _jsonFileReader = new JsonFileReader();
        }

        public IActionResult Index()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data","top_10_movies.json");
            List<TopMovs> movs = _jsonFileReader.GetMovieFromFile(filePath);

            return View(movs);
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
