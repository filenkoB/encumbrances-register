using Application.Auth.Commands;
using Application.Auth.Dtos;
using Domain.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    public class AuthController : BaseController
    {
        public AuthController(IMediator mediator, IJwtService jwtService)
            : base(mediator, jwtService)
        { }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AuthorizeUser([FromBody] AuthUserDto authUserDto)
        {
            var authorizationResult = await Mediator.Send(new AuthorizeUserCommand(authUserDto));
            return authorizationResult is null
                ? BadRequest()
                : Ok(authorizationResult);
        }
    }
}
