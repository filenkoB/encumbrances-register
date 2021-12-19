using Application.StatementTypes.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    public class StatementTypeController : BaseController
    {
        public StatementTypeController(IMediator mediator)
            : base(mediator)
        { }

        [HttpGet]
        public async Task<IActionResult> GetStatementTypes()
        {
            return Ok(await Mediator.Send(new GetAllStatementTypesQuery()));
        }
    }
}
