using Application.EncumbranceTypes.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    public class EncumbranceTypeController : BaseController
    {
        public EncumbranceTypeController(IMediator mediator)
            : base(mediator)
        { }

        [HttpGet]
        public async Task<IActionResult> GetEncumbranceTypesAsync()
        {
            return Ok(await Mediator.Send(new GetAllEncumbranceTypesQuery()));
        }
    }
}
