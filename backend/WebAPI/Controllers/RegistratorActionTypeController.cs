using Application.RegistratorActionTypes.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    public class RegistratorActionTypeController : BaseController
    {
        public RegistratorActionTypeController(IMediator mediator)
            : base(mediator)
        { }

        [HttpGet]
        public async Task<IActionResult> GetRegistratorActionTypesAsync()
        {
            return Ok(await Mediator.Send(new GetAllRegistratorActionTypesQuery()));
        }
    }
}
