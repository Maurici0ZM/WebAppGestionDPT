using GestionDPT.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GestionDPT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Usuarios()
        {
            return View();
        }
        public IActionResult Proyectos()
        {
            return View();
        }
        public IActionResult Tareas()
        {
            return View();
        }
        public IActionResult ParticipacionProyectos()
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