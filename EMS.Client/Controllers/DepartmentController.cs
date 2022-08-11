using Microsoft.AspNetCore.Mvc;

namespace EMS.Client.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
