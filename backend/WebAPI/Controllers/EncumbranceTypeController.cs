using Application.EncumbranceTypes.Queries;
using Domain.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    public class EncumbranceTypeController : BaseController
    {
        public EncumbranceTypeController(IMediator mediator, IJwtService jwtService)
            : base(mediator, jwtService)
        { }

        [HttpGet]
        public async Task<IActionResult> GetEncumbranceTypesAsync()
        {
            return Ok(await Mediator.Send(new GetAllEncumbranceTypesQuery()));
        }
    }
}
