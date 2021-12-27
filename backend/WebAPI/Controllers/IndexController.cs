using Application.Indices.Queries;
using Domain.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    public class IndexController : BaseController
    {
        public IndexController(IMediator mediator, IJwtService jwtService)
            : base(mediator, jwtService)
        { }

        [HttpGet("City/{cityId}")]
        public async Task<IActionResult> GetCityIndicesAsync(Guid cityId)
        {
            return Ok(await Mediator.Send(new GetAllCityIndicesQuery(cityId)));
        }
    }
}
