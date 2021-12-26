using Application.RegistrationTypes.Dtos;
using AutoMapper;
using Domain.Interfaces.Abstract;
using Domain.PostgreSQL.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.RegistrationTypes.Queries
{
    public class GetAllRegistrationTypesQuery : IRequest<IEnumerable<RegistrationTypeDto>>
    { }

    public class GetAllRegistrationTypesQueryHandler : IRequestHandler<GetAllRegistrationTypesQuery, IEnumerable<RegistrationTypeDto>>
    {
        private readonly IReadRepository<RegistrationType> _registrationTypeReadRepository;
        private readonly IMapper _mapper;
        public GetAllRegistrationTypesQueryHandler(IReadRepository<RegistrationType> registrationTypeReadRepository, IMapper mapper)
        {
            _registrationTypeReadRepository = registrationTypeReadRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RegistrationTypeDto>> Handle(GetAllRegistrationTypesQuery query, CancellationToken token)
        {
            return _mapper.Map<IEnumerable<RegistrationTypeDto>>(await _registrationTypeReadRepository.GetEntitiesAsync("RegistrationTypes"));
        }
    }
}
