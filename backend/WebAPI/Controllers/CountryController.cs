using Application.Countries.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("[Controller]")]
    public class CountryController : BaseController
    {
        public CountryController(IMediator mediator)
            : base(mediator)
        { }

        [HttpGet]
        public async Task<IActionResult> GetCountriesAsync()
        {
            return Ok(await Mediator.Send(new GetAllCountriesQuery()));
        }
    }
}
