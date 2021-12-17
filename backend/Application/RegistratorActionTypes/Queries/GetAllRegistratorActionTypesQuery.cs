using Application.RegistratorActionTypes.Dtos;
using AutoMapper;
using Domain.Interfaces.Read;
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
        private readonly IRegistratorActionTypeReadRepository _registratorActionTypeReadRepository;
        private readonly IMapper _mapper;
        public GetAllRegistratorActionTypesQueryHandler(IRegistratorActionTypeReadRepository registratorActionTypeReadRepository, IMapper mapper)
        {
            _registratorActionTypeReadRepository = registratorActionTypeReadRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RegistratorActionTypeDto>> Handle(GetAllRegistratorActionTypesQuery query, CancellationToken token)
        {
            return _mapper.Map<IEnumerable<RegistratorActionTypeDto>>(await _registratorActionTypeReadRepository.GetAllRegistratorActionTypesAsync());
        }
    }
}
