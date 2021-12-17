using Application.Indices.Dtos;
using AutoMapper;
using Domain.Interfaces.Read;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Indices.Queries
{
    public class GetAllCityIndicesQuery : IRequest<IEnumerable<IndexDto>>
    {
        public Guid CityId { get; set; }
        public GetAllCityIndicesQuery(Guid cityId)
        {
            CityId = cityId;
        }
    }

    public class GetAllCityIndicesQueryHandler : IRequestHandler<GetAllCityIndicesQuery, IEnumerable<IndexDto>>
    {
        private readonly IIndexReadRepository _indexReadRepository;
        private readonly IMapper _mapper;
        public GetAllCityIndicesQueryHandler(IIndexReadRepository indexReadRepository, IMapper mapper)
        {
            _indexReadRepository = indexReadRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<IndexDto>> Handle(GetAllCityIndicesQuery query, CancellationToken token)
        {
            return _mapper.Map<IEnumerable<IndexDto>>(await _indexReadRepository.GetAllCityIndicesAsync(query.CityId));
        }
    }
}
