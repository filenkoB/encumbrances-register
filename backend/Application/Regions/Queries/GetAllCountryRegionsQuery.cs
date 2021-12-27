using Application.Regions.Dtos;
using AutoMapper;
using Domain.Interfaces.Abstract;
using Domain.PostgreSQL.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Regions.Queries
{
    public class GetAllCountryRegionsQuery : IRequest<IEnumerable<RegionDto>>
    {
        public Guid CountryId { get; set; }
        public GetAllCountryRegionsQuery(Guid countryId)
        {
            CountryId = countryId;
        }
    }

    public class GetAllCountryRegionsQueryHandler : IRequestHandler<GetAllCountryRegionsQuery, IEnumerable<RegionDto>>
    {
        private readonly IReadRepository<Region> _regionReadRepository;
        private readonly IMapper _mapper;
        public GetAllCountryRegionsQueryHandler(IReadRepository<Region> regionReadRepository, IMapper mapper)
        {
            _regionReadRepository = regionReadRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RegionDto>> Handle(GetAllCountryRegionsQuery query, CancellationToken token)
        {
            return _mapper.Map<IEnumerable<RegionDto>>(await _regionReadRepository.GetEntitiesByParamsAsync(
                "Regions",
                ("CountryId", query.CountryId))
            );
        }
    }
}
