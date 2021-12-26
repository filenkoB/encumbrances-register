using Application.AlienationLimits.Queries;
using Domain.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    public class AlienationLimitController : BaseController
    {
        public AlienationLimitController(IMediator mediator, IJwtService jwtService)
            : base(mediator, jwtService)
        { }

        [HttpGet]
        public async Task<IActionResult> GetAlienationLimitsAsync()
        {
            return Ok(await Mediator.Send(new GetAllAlienationLimitsQuery()));
        }
    }
}
