using Application.EncumbranceKinds.Dtos;
using AutoMapper;
using Domain.Interfaces.Abstract;
using Domain.Interfaces.Read;
using Domain.PostgreSQL.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EncumbranceKinds.Queries
{
    public class GetAllEncumbranceKindsQuery : IRequest<IEnumerable<EncumbranceKindDto>>
    { }

    public class GetAllEncumbranceKindsQueryHandler : IRequestHandler<GetAllEncumbranceKindsQuery, IEnumerable<EncumbranceKindDto>>
    {
        private readonly IReadRepository<EncumbranceKind> _encumbranceKindReadRepository;
        private readonly IMapper _mapper;
        public GetAllEncumbranceKindsQueryHandler(IReadRepository<EncumbranceKind> encumbranceKindReadRepository, IMapper mapper)
        {
            _encumbranceKindReadRepository = encumbranceKindReadRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EncumbranceKindDto>> Handle(GetAllEncumbranceKindsQuery query, CancellationToken token)
        {
            return _mapper.Map<IEnumerable<EncumbranceKindDto>>(await _encumbranceKindReadRepository.GetEntitiesAsync("EncumbranceKinds"));
        }
    }
}
