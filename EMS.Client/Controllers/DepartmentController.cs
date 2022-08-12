using EMS.Client.Helpers;
using EMS.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Client.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ILogger<EmployeeController> logger;
        private readonly HttpCallHandler httpCallHandler;

        public DepartmentController(ILogger<EmployeeController> logger, HttpCallHandler httpCallHandler)
        {
            this.logger = logger;
            this.httpCallHandler = httpCallHandler;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DropDown()
        {
            var departmentDropDown = await httpCallHandler.GetAsyc<DropDownDto>("api/department/dropdown");
            return Json(departmentDropDown.Data);
        }
    }
}
