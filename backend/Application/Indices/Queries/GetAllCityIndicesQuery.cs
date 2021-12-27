using AutoMapper;
using Domain.Interfaces.Abstract;
using entities = Domain.PostgreSQL.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Application.Indices.Queries
{
    public class GetAllCityIndicesQuery : IRequest<IEnumerable<string>>
    {
        public Guid CityId { get; set; }
        public GetAllCityIndicesQuery(Guid cityId)
        {
            CityId = cityId;
        }
    }

    public class GetAllCityIndicesQueryHandler : IRequestHandler<GetAllCityIndicesQuery, IEnumerable<string>>
    {
        private readonly IReadRepository<entities.Index> _indexReadRepository;
        private readonly IMapper _mapper;
        public GetAllCityIndicesQueryHandler(IReadRepository<entities.Index> indexReadRepository, IMapper mapper)
        {
            _indexReadRepository = indexReadRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<string>> Handle(GetAllCityIndicesQuery query, CancellationToken token)
        {
            return (await _indexReadRepository.GetEntitiesByParamsAsync(
                "Indices",
                ("CityId", query.CityId)
            )).Select(i => i.IndexCode);
        }
    }
}
