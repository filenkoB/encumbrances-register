using Application.RegistrationTypes.Queries;
using Domain.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    public class RegistrationTypeController : BaseController
    {
        public RegistrationTypeController(IMediator mediator, IJwtService jwtService)
            : base(mediator, jwtService)
        { }

        [HttpGet]
        public async Task<IActionResult> GetRegistrationTypesAsync()
        {
            return Ok(await Mediator.Send(new GetAllRegistrationTypesQuery()));
        }
    }
}
