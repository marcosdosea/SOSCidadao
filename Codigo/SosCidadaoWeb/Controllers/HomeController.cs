using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SosCidadaoWeb.Models;
using System.Diagnostics;

namespace SosCidadaoWeb.Controllers
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
            ViewBag.isBannerFull = true;
            ViewBag.isBannerHidden = false;
            return View();
        }
        public IActionResult IndexSystem()
        {
            ViewBag.isBannerFull = true;
            ViewBag.isBannerHidden = false;
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
