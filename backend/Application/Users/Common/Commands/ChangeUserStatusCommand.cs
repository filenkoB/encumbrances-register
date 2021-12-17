using Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Common.Commands
{
    public class ChangeUserStatusCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }

        public ChangeUserStatusCommand(Guid id, bool isActive)
        {
            Id = id;
            IsActive = isActive;
        }
    }

    public class ChangeUserStatusCommandHandler : IRequestHandler<ChangeUserStatusCommand, Unit>
    {
        private readonly IUsersCommonWriteRepository _usersCommonWriteRepository;
        
        public ChangeUserStatusCommandHandler(IUsersCommonWriteRepository usersCommonWriteRepository)
        {
            _usersCommonWriteRepository = usersCommonWriteRepository;
        }

        public async Task<Unit> Handle(ChangeUserStatusCommand command, CancellationToken token)
        {
            await _usersCommonWriteRepository.ChangeUserIdentificatorStatusAsync(command.Id, command.IsActive);
            return Unit.Value;
        }
    }
}
