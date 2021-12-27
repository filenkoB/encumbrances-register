using Application.Districts.Queries;
using Domain.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    public class DistrictController : BaseController
    {
        public DistrictController(IMediator mediator, IJwtService jwtService)
            : base(mediator, jwtService)
        { }

        [HttpGet("Region/{regionId}")]
        public async Task<IActionResult> GetRegionDistrictsAsync(Guid regionId)
        {
            return Ok(await Mediator.Send(new GetAllRegionDistrictsQuery(regionId)));
        }
    }
}

