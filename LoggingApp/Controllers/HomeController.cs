using LoggingApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoggingApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILoggerFactory _loggerFactory;

        public HomeController(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            //_logger.LogDebug("Index Sayfasına girildi");

            var _logger= _loggerFactory.CreateLogger("HomeSınıfı");
            _logger.LogInformation("Index Sayfasına girildi");

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