using EMS.Application.Commands.Employees.CreateEmployees;
using EMS.Application.Common.Models.Enum;
using EMS.Application.Queries.Employees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Api.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
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
            var result = await MediatorObject.Send(new EmployeeListQuery());
            if (!result.Success || result.Data == null)
            {
                _logger.LogError(result.Exception, result.Message);
                if (result.MessageType == MessageType.Invalid) return BadRequest(result.Message);
                return NotFound(result.Message);
            }

            return Ok(result);
        }

        /// <summary>
        ///     Gets details of an Bank with specified id.
        /// </summary>
        /// <returns>Details of Bank.</returns>
        [HttpGet("detail")]
        public async Task<ActionResult> GetById([FromQuery] int id)
        {
            var queryResult =
                await MediatorObject.Send(new EmployeeDetailsQuery { Id = id });
            if (!queryResult.Success || queryResult.Data == null)
            {
                _logger.LogError(queryResult.Exception, queryResult.Message);
                if (queryResult.MessageType == MessageType.Invalid) return BadRequest(queryResult.Message);
                return NotFound(queryResult.Message);
            }

            return Ok(queryResult);
        }

        /// <summary>
        ///     Saves details of new Bank.
        /// </summary>
        /// <param name="command">Bank object.</param>
        /// <returns>Saved details of Bank.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Create(CreateEmployeeCommand command)
        {
            var result = await MediatorObject.Send(command);
            if (!result.Success || result.Data == null)
            {
                _logger.LogError(result.Exception, result.Message);
                if (result.MessageType == MessageType.Invalid || result.MessageType == MessageType.Error)
                {
                    return BadRequest(result.Message);
                }
                return NotFound(result.Message);
            }

            return Ok(result);
        }
    }
}
