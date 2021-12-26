using Application.CurrencyTypes.Queries;
using Domain.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    public class CurrencyTypeController : BaseController
    {
        public CurrencyTypeController(IMediator mediator, IJwtService jwtService)
            : base(mediator, jwtService)
        { }

        [HttpGet]
        public async Task<IActionResult> GetCurrencyTypesAsync()
        {
            return Ok(await Mediator.Send(new GetAllCurrencyTypesQuery()));
        }
    }
}
