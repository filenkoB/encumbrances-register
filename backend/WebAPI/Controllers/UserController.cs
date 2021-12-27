using System;
using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces.Services;
using Application.Users.Users.Queries;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class UserController : BaseController
    {
        public UserController(IMediator mediator, IJwtService jwtService)
            : base(mediator, jwtService)
        { }

        [HttpGet("Authority")]
        public async Task<IActionResult> GetIsUserHasAuthority()
        {
            Guid? userId = ValidateUserToken(HttpContext);
            if (userId == null)
            {
                return Unauthorized();
            }
            return Ok(await Mediator.Send(new GetIsUserHasAuthorityQuery((Guid)userId)));
        }
    }
}
