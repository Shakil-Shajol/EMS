using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator MediatorObject => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
