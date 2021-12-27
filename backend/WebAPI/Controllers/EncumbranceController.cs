using Microsoft.AspNetCore.Authorization;
using Application.Encumbrances.Commands;
using Application.Encumbrances.Queries;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;
using System;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("/[controller]")]
    public class EncumbranceController : BaseController
    {
        public EncumbranceController(IMediator mediator, IJwtService jwtService)
            : base(mediator, jwtService)
        { }

        #region Encumbrance getting
        [HttpGet]
        [Route("RegistrationNumber/{number}")]
        public async Task<IActionResult> GetEncumbranceByRegistrationNumber(string number)
        {
            return Ok(await Mediator.Send(new GetEncumbranceByRegNumberQuery(number)));
        }

        [HttpPost]
        public async Task<IActionResult> GetFilteredEncumbrances([FromBody] EncumbranceSelectFilter filter, [FromQuery] int page = 1, [FromQuery] int length = 10)
        {
            return Ok(await Mediator.Send(new GetFilteredEncumbrancesQuery(filter, page, length)));
        }
        #endregion

        #region Encumbrance statement accepting/declining
        [HttpPost]
        [Route("Register/Statement/{statementId}/Accept")]
        public async Task<IActionResult> AddEncumbranceByStatement(Guid statementId)
        {
            Guid? registratorId = ValidateUserToken(HttpContext);
            if (registratorId == null)
            {
                return Unauthorized();
            }

            var ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return Ok(await Mediator.Send(new AddEncumbranceCommand(statementId, (Guid)registratorId, ipAddress)));
        }

        [HttpPost]
        [Route("Update/Statement/{statementId}/Accept")]
        public async Task<IActionResult> UpdateEncumbranceByStatement(Guid statementId)
        {
            Guid? registratorId = ValidateUserToken(HttpContext);
            if (registratorId == null)
            {
                return Unauthorized();
            }

            var ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return Ok(await Mediator.Send(new UpdateEncumbranceCommand(statementId, (Guid)registratorId, ipAddress)));
        }

        [HttpPost]
        [Route("Remove/Statement/{statementId}/Accept")]
        public async Task<IActionResult> RemoveEncumbranceByStatement(Guid statementId)
        {
            Guid? registratorId = ValidateUserToken(HttpContext);
            if (registratorId == null)
            {
                return Unauthorized();
            }

            var ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return Ok(await Mediator.Send(new RemoveEncumbranceCommand(statementId, (Guid)registratorId, ipAddress)));
        }

        [HttpPost]
        [Route("Statement/{statementId}/Decline")]
        public async Task<IActionResult> DeclineEncumbranceAddingStatement(Guid statementId)
        {
            Guid? registratorId = ValidateUserToken(HttpContext);
            if (registratorId == null)
            {
                return Unauthorized();
            }

            var ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            return Ok(await Mediator.Send(new DeclineEncumbranceStatementCommand(statementId, (Guid)registratorId, ipAddress)));
        }
        #endregion
    }
}
