using System;
using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Users.Common.Commands;
using Domain.Interfaces.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class UserController : BaseController
    {
        public UserController(IMediator mediator, IJwtService jwtService)
            : base(mediator, jwtService)
        { }

        [HttpPost("id")]
        [Route("{id}/Status")]
        public async Task<IActionResult> ChangeUserStatus(Guid id, [FromBody] bool isActive)
        {
            await Mediator.Send(new ChangeUserStatusCommand(id, isActive));
            return Ok();
        }
    }
}
