using Application.AlienationLimits.Dtos;
using AutoMapper;
using Domain.Interfaces.Read;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.AlienationLimits.Queries
{
    public class GetAllAlienationLimitsQuery : IRequest<IEnumerable<AlienationLimitDto>>
    { }

    public class GetAllAlienationLimitsQueryHandler : IRequestHandler<GetAllAlienationLimitsQuery, IEnumerable<AlienationLimitDto>>
    {
        private readonly IAlienationLimitsReadRepository _alienationLimitReadRepository;
        private readonly IMapper _mapper;
        public GetAllAlienationLimitsQueryHandler(IAlienationLimitsReadRepository alienationLimitReadRepository, IMapper mapper)
        {
            _alienationLimitReadRepository = alienationLimitReadRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AlienationLimitDto>> Handle(GetAllAlienationLimitsQuery query, CancellationToken token)
        {
            return _mapper.Map<IEnumerable<AlienationLimitDto>>(await _alienationLimitReadRepository.GetAllAlienationLimitsAsync());
        }
    }
}
