using Application.Districts.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    public class DistrictController : BaseController
    {
        public DistrictController(IMediator mediator)
            : base(mediator)
        { }

        [HttpGet("Region/{regionId}")]
        public async Task<IActionResult> GetRegionDistrictsAsync(Guid regionId)
        {
            return Ok(await Mediator.Send(new GetAllRegionDistrictsQuery(regionId)));
        }
    }
}

