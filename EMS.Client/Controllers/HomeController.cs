using EMS.Client.Helpers;
using EMS.Client.Models;
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

        public async Task<IActionResult> Index()
        {
            var employee = new { EmployeeName = "Azman Mollah", DepartmentId = 2, JoinDate = "18-12-1993" };
            var res = await _httpCallHandler.PostAsync("api/employee", employee);
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