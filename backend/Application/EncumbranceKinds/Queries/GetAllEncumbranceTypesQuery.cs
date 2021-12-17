using Application.EncumbranceKinds.Dtos;
using AutoMapper;
using Domain.Interfaces.Read;
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
        private readonly IEncumbranceKindReadRepository _encumbranceKindReadRepository;
        private readonly IMapper _mapper;
        public GetAllEncumbranceKindsQueryHandler(IEncumbranceKindReadRepository encumbranceKindReadRepository, IMapper mapper)
        {
            _encumbranceKindReadRepository = encumbranceKindReadRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EncumbranceKindDto>> Handle(GetAllEncumbranceKindsQuery query, CancellationToken token)
        {
            return _mapper.Map<IEnumerable<EncumbranceKindDto>>(await _encumbranceKindReadRepository.GetAllEncumbranceKindsAsync());
        }
    }
}
