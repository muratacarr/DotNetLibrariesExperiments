using HangfireApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HangfireApp.Controllers
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
            BackgroundJobs.RecurringJobs.ReportingJob();

            // Yukarıdaki job id sini almamız gerekiyordu onu yapamadım onu aldığımızda continuation job da çalışacak
            // BackgroundJobs.ContinuationsJobs.AfterJobs(id);

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile picture)
        {
            string newFileName = string.Empty;

            if (picture != null && picture.Length > 0)
            {
                newFileName = "WATER-" + picture.FileName;

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pictures/watermark", newFileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await picture.CopyToAsync(stream);
                }
                string jobId = BackgroundJobs.DelayedJobs.AddWaterMarkJob(newFileName, "Murat-Silay");

            }

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