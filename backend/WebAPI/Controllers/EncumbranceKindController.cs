using Application.EncumbranceKinds.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    public class EncumbranceKindController : BaseController
    {
        public EncumbranceKindController(IMediator mediator)
            : base(mediator)
        { }

        [HttpGet]
        public async Task<IActionResult> GetEncumbranceKindsAsync()
        {
            return Ok(await Mediator.Send(new GetAllEncumbranceKindsQuery()));
        }
    }
}
