using Application.Users.Registrators.Dtos;
using Domain.Entities;
using Domain.Interfaces.Read;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Registrators.Queries
{
    public class GetRegistratorActionsQuery : IRequest<RegistratorActionList>
    {
        public Guid RegistratorId { get; set; }
        
        public GetRegistratorActionsQuery(Guid registratorId)
        {
            RegistratorId = registratorId;
        }
    }

    public class GetRegistratorActionsQueryHandler : IRequestHandler<GetRegistratorActionsQuery, RegistratorActionList>
    {
        private readonly IRegistratorActionReadRepository _registratorActionReadRepository;

        public GetRegistratorActionsQueryHandler(IRegistratorActionReadRepository registratorActionReadRepository)
        {
            _registratorActionReadRepository = registratorActionReadRepository;
        }
        public async Task<RegistratorActionList> Handle(GetRegistratorActionsQuery query, CancellationToken cancellationToken)
        {
            IEnumerable<RegistratorAction> actions = await _registratorActionReadRepository.GetRegistratorActionsAsync(query.RegistratorId);
            return new RegistratorActionList()
            {
                Actions = actions.ToArray(),
                Length = actions.Count()
            };
        }
    }
}
