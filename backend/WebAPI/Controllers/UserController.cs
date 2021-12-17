using System;
using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Users.Common.Commands;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class UserController : BaseController
    {
        public UserController(IMediator mediator)
            : base(mediator)
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
