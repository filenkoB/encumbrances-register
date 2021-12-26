using Application.Enumerations;
using Application.Extracts.Commands;
using Domain.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ExtractController : BaseController
    {
        public ExtractController(IMediator mediator, IJwtService jwtService)
            : base(mediator, jwtService)
        { }

        [HttpPost("{statementId}")]
        public async Task<IActionResult> SendExtract(Guid statementId)
        {
            Guid? userId = ValidateUserToken(HttpContext);
            if (userId is null)
            {
                return Unauthorized();
            }

            string token = HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1];
            string userTypeName = JwtService.GetTokenClaims(token).FindFirst(ClaimsIdentity.DefaultRoleClaimType).Value;
            UserType userType = (UserType)Enum.Parse(typeof(UserType), userTypeName);
            return Ok(await Mediator.Send(new SendExtractCommand(statementId, userType, (Guid)userId)));
        }
    }
}
