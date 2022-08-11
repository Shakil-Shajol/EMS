using EMS.Application.Common.Models.Enum;
using EMS.Application.Queries.Departments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : BaseController
    {
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(ILogger<DepartmentController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets list of all Bank.
        /// </summary>
        /// <returns>The collection of all Bank.</returns>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await MediatorObject.Send(new DepartmentListQuery());
            if (!result.Success || result.Data == null)
            {
                _logger.LogError(result.Exception, result.Message);
                if (result.MessageType == MessageType.Invalid) return BadRequest(result.Message);
                return NotFound(result.Message);
            }

            return Ok(result);
        }

        /// <summary>
        /// Gets list of all Bank.
        /// </summary>
        /// <returns>The collection of all Bank.</returns>
        [HttpGet("dropdown")]
        public async Task<ActionResult> GetDropDown()
        {
            var result = await MediatorObject.Send(new DepartmentDropdownListQuery());
            if (!result.Success || result.Data == null)
            {
                _logger.LogError(result.Exception, result.Message);
                if (result.MessageType == MessageType.Invalid) return BadRequest(result.Message);
                return NotFound(result.Message);
            }

            return Ok(result);
        }
    }
}
