using Application.Users.Users.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Application.Users.Users.Com;
using Application.Users.Users.Commmands;
using Application.Users.Registrators.Dtos;
using Application.Users.Registrators.Commands;
using Application.Users.Common.Dtos;
using Domain.Interfaces.Services;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    public class RegistrationController : BaseController
    {
        public RegistrationController(IMediator mediator, IJwtService jwtService)
            : base(mediator, jwtService)
        { }

        [HttpPost]
        [Route("User/Statement")]
        public async Task<IActionResult> RegisterUserRegistrationStatement(CreateUserDto createUserDto)
        {
            return Ok(await Mediator.Send(new AddUserRegistrationStatementCommand(createUserDto)));
        }

        [HttpPost]
        [Route("User/Accept/{statementId}")]
        public async Task<IActionResult> AcceptUserRegistrationStatement(Guid statementId)
        {
            return Ok(await Mediator.Send(new RegisterUserCommand(statementId)));
        }

        [HttpPost]
        [Route("User/Decline/{statementId}")]
        public async Task<IActionResult> DeclineUserRegistrationStatement(Guid statementId, [FromBody] DeclineInfoDto declineInfoDto)
        {
            return Ok(await Mediator.Send(new DeclineUserRegistrationCommand(statementId, declineInfoDto.Email, declineInfoDto.Reason)));
        }

        [HttpPost]
        [Route("Registrator/Statement")]
        public async Task<IActionResult> RegisterRegistratorRegistrationStatement(CreateRegistratorDto createRegistratorDto)
        {
            return Ok(await Mediator.Send(new AddRegistratorRegistrationStatementCommand(createRegistratorDto)));
        }

        [HttpPost]
        [Route("Registrator/Accept/{statementId}")]
        public async Task<IActionResult> AcceptRegistratorRegistrationStatement(Guid statementId)
        {
            return Ok(await Mediator.Send(new RegisterRegistratorCommand(statementId)));
        }

        [HttpPost]
        [Route("Registrator/Decline/{statementId}")]
        public async Task<IActionResult> DeclineRegistratorRegistrationStatement(Guid statementId, [FromBody] DeclineInfoDto declineInfoDto)
        {
            return Ok(await Mediator.Send(new DeclineRegistratorRegistrationCommand(statementId, declineInfoDto.Email, declineInfoDto.Reason)));
        }
    }
}
