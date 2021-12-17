using Application.Cities.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    public class CityController : BaseController
    {
        public CityController(IMediator mediator)
            : base(mediator)
        { }

        [HttpGet("District/{districtId}")]
        public async Task<IActionResult> GetDistrictCitiesAsync(Guid districtId)
        {
            return Ok(await Mediator.Send(new GetAllDistrictCitiesQuery(districtId)));
        }
    }
}
