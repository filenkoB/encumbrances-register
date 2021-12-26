using Application.RegistratorActionTypes.Queries;
using Domain.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    public class RegistratorActionTypeController : BaseController
    {
        public RegistratorActionTypeController(IMediator mediator, IJwtService jwtService)
            : base(mediator, jwtService)
        { }

        [HttpGet]
        public async Task<IActionResult> GetRegistratorActionTypesAsync()
        {
            return Ok(await Mediator.Send(new GetAllRegistratorActionTypesQuery()));
        }
    }
}
