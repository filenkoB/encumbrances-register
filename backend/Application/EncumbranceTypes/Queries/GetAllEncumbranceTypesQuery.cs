using Application.EncumbranceTypes.Dtos;
using AutoMapper;
using Domain.Interfaces.Abstract;
using Domain.PostgreSQL.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EncumbranceTypes.Queries
{
    public class GetAllEncumbranceTypesQuery : IRequest<IEnumerable<EncumbranceTypeDto>>
    { }

    public class GetAllEncumbranceTypesQueryHandler : IRequestHandler<GetAllEncumbranceTypesQuery, IEnumerable<EncumbranceTypeDto>>
    {
        private readonly IReadRepository<EncumbranceType> _encumbranceTypeReadRepository;
        private readonly IMapper _mapper;
        public GetAllEncumbranceTypesQueryHandler(IReadRepository<EncumbranceType> encumbranceTypeReadRepository, IMapper mapper)
        {
            _encumbranceTypeReadRepository = encumbranceTypeReadRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EncumbranceTypeDto>> Handle(GetAllEncumbranceTypesQuery query, CancellationToken token)
        {
            return _mapper.Map<IEnumerable<EncumbranceTypeDto>>(await _encumbranceTypeReadRepository.GetEntitiesAsync("EncumbranceTypes"));
        }
    }
}
