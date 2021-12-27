using Application.Authorities.Dtos;
using Domain.Entities.PostgreSQL;
using Domain.Interfaces.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;
using MediatR;

namespace Application.Authorities.Queries
{
    public class GetAllPassportAuthoritiesQuery : IRequest<IEnumerable<ShortPassportAuthorityDto>>
    { }

    public class GetAllPassportAuthoritiesQueryHandler : IRequestHandler<GetAllPassportAuthoritiesQuery, IEnumerable<ShortPassportAuthorityDto>>
    {
        private readonly IReadRepository<PassportAuthority> _authorityReadRepository;
        private readonly IMapper _mapper;
        public GetAllPassportAuthoritiesQueryHandler(IReadRepository<PassportAuthority> authorityReadRepository, IMapper mapper)
        {
            _authorityReadRepository = authorityReadRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ShortPassportAuthorityDto>> Handle(GetAllPassportAuthoritiesQuery query, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<ShortPassportAuthorityDto>>(await _authorityReadRepository.GetEntitiesAsync("PassportAuthority"));
        }
    }
}
