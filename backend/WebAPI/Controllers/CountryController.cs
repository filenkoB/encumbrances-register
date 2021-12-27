using Application.Countries.Queries;
using Domain.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("[Controller]")]
    public class CountryController : BaseController
    {
        public CountryController(IMediator mediator, IJwtService jwtService)
            : base(mediator, jwtService)
        { }

        [HttpGet]
        public async Task<IActionResult> GetCountriesAsync()
        {
            return Ok(await Mediator.Send(new GetAllCountriesQuery()));
        }
    }
}
