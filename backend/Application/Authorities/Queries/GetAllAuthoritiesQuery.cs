using Application.Authorities.Dtos;
using Domain.PostgreSQL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;
using MediatR;

namespace Application.Authorities.Queries
{
    public class GetAllAuthoritiesQuery : IRequest<IEnumerable<ShortAuthorityDto>>
    { }

    public class GetAllAthoritiesQueryHandler : IRequestHandler<GetAllAuthoritiesQuery, IEnumerable<ShortAuthorityDto>>
    {
        private readonly Domain.Interfaces.Abstract.IReadRepository<Authority> _authorityReadRepository;
        private readonly IMapper _mapper;
        public GetAllAthoritiesQueryHandler(Domain.Interfaces.Abstract.IReadRepository<Authority> authorityReadRepository, IMapper mapper)
        {
            _authorityReadRepository = authorityReadRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ShortAuthorityDto>> Handle(GetAllAuthoritiesQuery query, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<ShortAuthorityDto>>(await _authorityReadRepository.GetEntitiesAsync("Authorities"));
        }
    }
}
