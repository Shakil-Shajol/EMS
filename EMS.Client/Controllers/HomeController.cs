using EMS.Client.Helpers;
using EMS.Client.Models;
using EMS.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EMS.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpCallHandler _httpCallHandler;

        public HomeController(ILogger<HomeController> logger,HttpCallHandler httpCallHandler)
        {
            _logger = logger;
            this._httpCallHandler = httpCallHandler;
        }

        public IActionResult Index()
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