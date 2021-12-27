using Application.Regions.Queries;
using Domain.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("[Controller]")]
    public class RegionController : BaseController
    {
        public RegionController(IMediator mediator, IJwtService jwtService)
            : base(mediator, jwtService)
        { }

        [HttpGet("Country/{countryId}")]
        public async Task<IActionResult> GetCountryRegionsAsync(Guid countryId)
        {
            return Ok(await Mediator.Send(new GetAllCountryRegionsQuery(countryId)));
        }
    }
}
