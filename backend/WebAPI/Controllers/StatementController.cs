using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Statements.Dtos;
using Application.Statements.Commands;
using System.Threading.Tasks;
using Application.Statements.Queries;
using System;
using Microsoft.AspNetCore.Authorization;
using Domain.Interfaces.Services;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class StatementController : BaseController
    {
        public StatementController(IMediator mediator, IJwtService jwtService)
            : base(mediator, jwtService)
        { }

        #region Encumbrance statement registration
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterStatement([FromBody] AddRegistrationStatementDto registrationStatementDto)
        {
            Guid? userId = ValidateUserToken(HttpContext);
            registrationStatementDto.StatementOwnerId = (Guid)userId;
            return Ok(await Mediator.Send(new RegisterStatementCommand(registrationStatementDto)));
        }

        [HttpPost]
        [Route("Register/Extract/{encumbranceId}")]
        public async Task<IActionResult> RegisterExtractStatement(Guid encumbranceId)
        {
            Guid? userId = ValidateUserToken(HttpContext);
            if (userId == null)
            {
                return Unauthorized();
            }
            return Ok(await Mediator.Send(new RegisterExtractStatementCommand(
                new AddExtractStatementDto(encumbranceId, (Guid)userId)
            )));
        }

        [HttpGet]
        public async Task<IActionResult> GetStatements([FromQuery] int page = 1, [FromQuery] int length = 10)
        {
            return Ok(await Mediator.Send(new GetStatementsQuery(page, length)));
        }

        [HttpGet("{statementId}")]
        public async Task<IActionResult> GetDetailedStatemet(Guid statementId)
        {
            var result = await Mediator.Send(new GetDetailedStatementQuery(statementId));

            return result is null
                ? NotFound()
                : Ok(result);
        }

        #endregion

        #region Encumbrance registration statements
        [HttpGet]
        [Route("Registration/Users/{statementId}")]
        public async Task<IActionResult> GetUserRegistrationStatementInfo(Guid statementId)
        {
            return Ok(await Mediator.Send(new GetDetailedUserRegistrationStatementQuery(statementId)));
        }

        [HttpGet]
        [Route("Registration/Users")]
        public async Task<IActionResult> GetUserRegistrationStatements([FromQuery] int page = 1, [FromQuery] int length = 10)
        {
            return Ok(await Mediator.Send(new GetUserRegistrationStatementsQuery(page, length)));
        }
        #endregion

        [HttpGet]
        [Route("User")]
        public async Task<IActionResult> GetUserStatements([FromQuery] int page = 1, [FromQuery] int length = 10)
        {
            Guid? userId = ValidateUserToken(HttpContext);
            if (userId == null)
            {
                return Unauthorized();
            }

            return Ok(await Mediator.Send(new GetUserStatementsQuery(page, length, (Guid)userId)));
        }

        [HttpPost]
        [Route("Extract/{statementId}/Accept")]
        public async Task<IActionResult> AcceptExtractStatement(Guid statementId)
        {
            if (ValidateUserToken(HttpContext) == null)
            {
                return Unauthorized();
            }

            return Ok(await Mediator.Send(new ChangeExtractStatementStatusCommand(statementId, 1)));
        }

        [HttpPost]
        [Route("Extract/{statementId}/Decline")]
        public async Task<IActionResult> DeclineExtractStatement(Guid statementId)
        {
            if (ValidateUserToken(HttpContext) == null)
            {
                return Unauthorized();
            }

            return Ok(await Mediator.Send(new ChangeExtractStatementStatusCommand(statementId, 2)));
        }
    }
}
