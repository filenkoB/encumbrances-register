using Application.Users.Registrators.Commands;
using Application.Users.Registrators.Dtos;
using Application.Users.Registrators.Queries;
using Domain.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class RegistratorController : BaseController
    {
        public RegistratorController(IMediator mediator, IJwtService jwtService)
            : base(mediator, jwtService)
        { }

        [HttpGet]
        public async Task<IActionResult> GetRegistrators([FromQuery] int page = 1, [FromQuery] int length = 10)
        {
            Guid? userId = ValidateUserToken(HttpContext);
            if (userId == null)
            {
                return Unauthorized();
            }

            return Ok(await Mediator.Send(new GetRegistratorsQuery(page, length)));
        }

        [HttpGet("{registratorId}")]
        public async Task<IActionResult> GetRegistrator(Guid registratorId)
        {
            Guid? userId = ValidateUserToken(HttpContext);
            if (userId == null)
            {
                return Unauthorized();
            }

            return Ok(await Mediator.Send(new GetRegistratorQuery(registratorId)));
        }

        [HttpGet]
        [Route("{registratorId}/Actions")]
        public async Task<IActionResult> GetRegistratorActions(Guid registratorId)
        {
            Guid? userId = ValidateUserToken(HttpContext);
            if (userId == null)
            {
                return Unauthorized();
            }

            return Ok(await Mediator.Send(new GetRegistratorActionsQuery(registratorId)));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRegistrator([FromBody] UpdateRegistratorDto registratorDto)
        {
            Guid? userId = ValidateUserToken(HttpContext);
            if (userId == null)
            {
                return Unauthorized();
            }

            return Ok(await Mediator.Send(new UpdateRegistratorCommand(registratorDto)));
        }
    }
}
