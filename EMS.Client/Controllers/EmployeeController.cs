using EMS.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Client.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Create()
        {
            return View();
        }


        public IActionResult Create(EmployeeDto employee)
        {
            return View();
        }
    }
}
