using Domain.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IMediator Mediator { get; set; }
        protected IJwtService JwtService { get; set; }

        public BaseController(IMediator mediator, IJwtService jwtService)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            JwtService = jwtService;
        }

        protected Guid? ValidateUserToken(HttpContext context)
        {
            string token = context.Request.Headers["Authorization"].ToString().Split(" ")[1];
            return JwtService.ValidateUserToken(token);
        }
    }
}
