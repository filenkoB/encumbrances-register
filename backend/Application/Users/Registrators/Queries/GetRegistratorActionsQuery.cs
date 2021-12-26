using Domain.Entities;
using Domain.Interfaces.Read;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Registrators.Queries
{
    public class GetRegistratorActionsQuery : IRequest<IEnumerable<RegistratorAction>>
    {
        public Guid RegistratorId { get; set; }
        
        public GetRegistratorActionsQuery(Guid registratorId)
        {
            RegistratorId = registratorId;
        }
    }

    public class GetRegistratorActionsQueryHandler : IRequestHandler<GetRegistratorActionsQuery, IEnumerable<RegistratorAction>>
    {
        private readonly IRegistratorActionReadRepository _registratorActionReadRepository;

        public GetRegistratorActionsQueryHandler(IRegistratorActionReadRepository registratorActionReadRepository)
        {
            _registratorActionReadRepository = registratorActionReadRepository;
        }
        public async Task<IEnumerable<RegistratorAction>> Handle(GetRegistratorActionsQuery query, CancellationToken cancellationToken)
        {
            return await _registratorActionReadRepository.GetRegistratorActionsAsync(query.RegistratorId);
        }
    }
}
