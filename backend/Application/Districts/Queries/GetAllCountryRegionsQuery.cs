using Application.Districts.Dtos;
using AutoMapper;
using Domain.Interfaces.Read;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Districts.Queries
{
    public class GetAllRegionDistrictsQuery : IRequest<IEnumerable<DistrictDto>>
    {
        public Guid RegionId { get; set; }
        public GetAllRegionDistrictsQuery(Guid regionId)
        {
            RegionId = regionId;
        }
    }

    public class GetAllRegionDistrictsQueryHandler : IRequestHandler<GetAllRegionDistrictsQuery, IEnumerable<DistrictDto>>
    {
        private readonly IDistrictReadRepository _districtReadRepository;
        private readonly IMapper _mapper;
        public GetAllRegionDistrictsQueryHandler(IDistrictReadRepository districtReadRepository, IMapper mapper)
        {
            _districtReadRepository = districtReadRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DistrictDto>> Handle(GetAllRegionDistrictsQuery query, CancellationToken token)
        {
            return _mapper.Map<IEnumerable<DistrictDto>>(await _districtReadRepository.GetAllRegionDistrictsAsync(query.RegionId));
        }
    }
}
