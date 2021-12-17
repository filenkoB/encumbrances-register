using Application.RegistrationTypes.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    public class RegistrationTypeController : BaseController
    {
        public RegistrationTypeController(IMediator mediator)
            : base(mediator)
        { }

        [HttpGet]
        public async Task<IActionResult> GetRegistrationTypesAsync()
        {
            return Ok(await Mediator.Send(new GetAllRegistrationTypesQuery()));
        }
    }
}
