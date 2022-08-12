using EMS.Client.Helpers;
using EMS.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Client.Controllers
{
    public class EmployeeController : Controller
    {
        #region Private Fields

        private readonly ILogger<EmployeeController> logger;
        private readonly HttpCallHandler httpCallHandler;

        #endregion Private Fields

        #region Public Constructors

        public EmployeeController(ILogger<EmployeeController> logger, HttpCallHandler httpCallHandler)
        {
            this.logger = logger;
            this.httpCallHandler = httpCallHandler;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<IActionResult> Index()
        {
            var employeeResponse = await httpCallHandler.GetAsyc<EmployeeReadDto>("api/employee");
            return View(employeeResponse);
        }

        public async Task<IActionResult> GetById(int id)
        {
            var employeeReadDto = await httpCallHandler.GetSingleAsyc<EmployeeReadDto>("api/employee/detail?id=" + id);
            return Json(employeeReadDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeDto employee)
        {
            await httpCallHandler.PostAsync("api/employee", employee);
            return RedirectToAction("Index");
        }

        #endregion Public Methods
    }
}
