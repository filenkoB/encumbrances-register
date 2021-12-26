using Application.RegistratorActionTypes.Dtos;
using AutoMapper;
using Domain.Interfaces.Abstract;
using Domain.PostgreSQL.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.RegistratorActionTypes.Queries
{
    public class GetAllRegistratorActionTypesQuery : IRequest<IEnumerable<RegistratorActionTypeDto>>
    { }

    public class GetAllRegistratorActionTypesQueryHandler : IRequestHandler<GetAllRegistratorActionTypesQuery, IEnumerable<RegistratorActionTypeDto>>
    {
        private readonly IReadRepository<RegistratorActionType> _registratorActionTypeReadRepository;
        private readonly IMapper _mapper;
        public GetAllRegistratorActionTypesQueryHandler(IReadRepository<RegistratorActionType> registratorActionTypeReadRepository, IMapper mapper)
        {
            _registratorActionTypeReadRepository = registratorActionTypeReadRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RegistratorActionTypeDto>> Handle(GetAllRegistratorActionTypesQuery query, CancellationToken token)
        {
            return _mapper.Map<IEnumerable<RegistratorActionTypeDto>>(await _registratorActionTypeReadRepository.GetEntitiesAsync("RegistratorActionTypes"));
        }
    }
}
