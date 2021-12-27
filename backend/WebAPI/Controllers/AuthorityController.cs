using Application.Authorities.Queries;
using Domain.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    public class AuthorityController : BaseController
    {
        public AuthorityController(IMediator mediator, IJwtService jwtService)
            : base(mediator, jwtService)
        { }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthorities()
        {
            return Ok(await Mediator.Send(new GetAllAuthoritiesQuery()));
        }

        [HttpGet]
        [Route("Passport")]
        public async Task<IActionResult> GetAllPassportAuthorities()
        {
            return Ok(await Mediator.Send(new GetAllPassportAuthoritiesQuery()));
        }
    }
}
