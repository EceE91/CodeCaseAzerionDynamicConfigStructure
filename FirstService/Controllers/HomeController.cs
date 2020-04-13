using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FirstService.Models;
using ConfiguratorLib;

namespace FirstService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ConfigReader _configReader;

        public HomeController(ILogger<HomeController> logger, ConfigReader configReader)
        {
            _logger = logger;
            _configReader = configReader;
        }

        public IActionResult Index()
        {
            var siteName = _configReader.GetValue<string>("SiteName");
            var maxItemCount = _configReader.GetValue<int>("MaxItemCount");
            var isBasketEnabled = _configReader.GetValue<bool>("IsBasketEnabled");

            ViewBag.siteName = siteName;
            ViewBag.maxItemCount = maxItemCount;
            ViewBag.isBasketEnabled = isBasketEnabled;

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
