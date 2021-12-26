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
        public async Task<IActionResult> GetFilteredEncumbrances([FromBody] EncumbranceSelectFilter filter)
        {
            return Ok(await Mediator.Send(new GetFilteredEncumbrancesQuery(filter)));
        }
        #endregion

        #region Encumbrance statement accepting/declining
        [HttpPost]
        [Route("Register/Statement/{statementId}/Accept")]
        public async Task<IActionResult> AddEncumbranceByStatement(Guid statementId)
        {
            return Ok(await Mediator.Send(new AddEncumbranceCommand(statementId)));
        }

        [HttpPost]
        [Route("Update/Statement/{statementId}/Accept")]
        public async Task<IActionResult> UpdateEncumbranceByStatement(Guid statementId)
        {
            return Ok(await Mediator.Send(new UpdateEncumbranceCommand(statementId)));
        }

        [HttpPost]
        [Route("Remove/Statement/{statementId}/Accept")]
        public async Task<IActionResult> RemoveEncumbranceByStatement(Guid statementId)
        {
            return Ok(await Mediator.Send(new RemoveEncumbranceCommand(statementId)));
        }

        [HttpPost]
        [Route("Statement/{statementId}/Decline")]
        public async Task<IActionResult> DeclineEncumbranceAddingStatement(Guid statementId)
        {
            return Ok(await Mediator.Send(new DeclineEncumbranceStatementCommand(statementId)));
        }
        #endregion
    }
}
