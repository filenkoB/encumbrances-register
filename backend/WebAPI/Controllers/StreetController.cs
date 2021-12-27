using Application.Streets.Queries;
using Domain.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    public class StreetController : BaseController
    {
        public StreetController(IMediator mediator, IJwtService jwtService)
            : base(mediator, jwtService)
        { }

        [HttpGet("City/{cityId}")]
        public async Task<IActionResult> GetCityStreetsAsync(Guid cityId)
        {
            return Ok(await Mediator.Send(new GetAllCityStreetsQuery(cityId)));
        }
    }
}
