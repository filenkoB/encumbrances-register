using Application.AlienationLimits.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    public class AlienationLimitController : BaseController
    {
        public AlienationLimitController(IMediator mediator)
            : base(mediator)
        { }

        [HttpGet]
        public async Task<IActionResult> GetAlienationLimitsAsync()
        {
            return Ok(await Mediator.Send(new GetAllAlienationLimitsQuery()));
        }
    }
}
