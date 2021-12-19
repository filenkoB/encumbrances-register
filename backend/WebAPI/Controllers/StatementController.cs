using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Statements.Dtos;
using Application.Statements.Commands;
using System.Threading.Tasks;
using Application.Statements.Queries;
using System;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    public class StatementController : BaseController
    {
        public StatementController(IMediator mediator)
            : base(mediator)
        { }
        
        [HttpPost]
        [Route("Registration/Add")]
        public async Task<IActionResult> PostStatement([FromBody] AddRegistrationStatementDto registrationStatementDto)
        {
            return Ok(await Mediator.Send(new AddRegistrationStatementCommand(registrationStatementDto)));
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
    }
}
