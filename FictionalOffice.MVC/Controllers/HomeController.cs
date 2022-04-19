using FictionalOffice.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FictionalOffice.MVC.Controllers
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
            return View(new CompanyDataViewModel()
            {
                CompanyName = "Company",
                Phone = "+7(789)123-45-67",
                Email = "support@company.com"
            });
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