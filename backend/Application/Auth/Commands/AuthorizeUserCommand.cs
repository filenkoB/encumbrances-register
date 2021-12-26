using Domain.Interfaces.Services;
using Application.Enumerations;
using System.Threading.Tasks;
using Application.Auth.Dtos;
using Domain.Interfaces;
using System.Threading;
using MediatR;

namespace Application.Auth.Commands
{
    public class AuthorizeUserCommand : IRequest<UserTokenDto>
    {
        public AuthUserDto AuthUser { get; set; }

        public AuthorizeUserCommand(AuthUserDto authUser)
        {
            AuthUser = authUser;
        }
    }

    public class AuthorizeUserCommandHandler : IRequestHandler<AuthorizeUserCommand, UserTokenDto>
    {
        private readonly IJwtService _jwtService;
        private readonly IUserCommonReadRepository _userCommonReadRepository;
        public AuthorizeUserCommandHandler(IJwtService jwtService, IUserCommonReadRepository userCommonReadRepository)
        {
            _jwtService = jwtService;
            _userCommonReadRepository = userCommonReadRepository;
        }
        public async Task<UserTokenDto> Handle(AuthorizeUserCommand command, CancellationToken token)
        {
            var login = command.AuthUser.Login;
            var password = command.AuthUser.Password;

            var jwtToken = await _jwtService.GetJwtToken(login, password);
            if (jwtToken is null)
            {
                return null;
            }

            UserType userType = await _userCommonReadRepository.GetUserTypeByIdentificatorAsync(login);

            return new UserTokenDto(jwtToken, userType, login);
        }
    }
}
