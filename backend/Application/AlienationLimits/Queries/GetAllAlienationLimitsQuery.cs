using Application.AlienationLimits.Dtos;
using Domain.Interfaces.Abstract;
using Domain.PostgreSQL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;
using MediatR;

namespace Application.AlienationLimits.Queries
{
    public class GetAllAlienationLimitsQuery : IRequest<IEnumerable<AlienationLimitDto>>
    { }

    public class GetAllAlienationLimitsQueryHandler : IRequestHandler<GetAllAlienationLimitsQuery, IEnumerable<AlienationLimitDto>>
    {
        private readonly IReadRepository<AlienationLimit> _alienationLimitReadRepository;
        private readonly IMapper _mapper;
        public GetAllAlienationLimitsQueryHandler(IReadRepository<AlienationLimit> alienationLimitReadRepository, IMapper mapper)
        {
            _alienationLimitReadRepository = alienationLimitReadRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AlienationLimitDto>> Handle(GetAllAlienationLimitsQuery query, CancellationToken token)
        {
            return _mapper.Map<IEnumerable<AlienationLimitDto>>(await _alienationLimitReadRepository.GetEntitiesAsync("AlienationLimits"));
        }
    }
}
