using Application.Cities.Dtos;
using AutoMapper;
using Domain.Interfaces.Read;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cities.Queries
{
    public class GetAllDistrictCitiesQuery : IRequest<IEnumerable<CityDto>>
    {
        public Guid DistrictId { get; set; }
        public GetAllDistrictCitiesQuery(Guid districtId)
        {
            DistrictId = districtId;
        }
    }

    public class GetAllDistrictCitiesQueryHandler : IRequestHandler<GetAllDistrictCitiesQuery, IEnumerable<CityDto>>
    {
        private readonly ICityReadRepository _cityReadRepository;
        private readonly IMapper _mapper;
        public GetAllDistrictCitiesQueryHandler(ICityReadRepository cityReadRepository, IMapper mapper)
        {
            _cityReadRepository = cityReadRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CityDto>> Handle(GetAllDistrictCitiesQuery query, CancellationToken token)
        {
            return _mapper.Map<IEnumerable<CityDto>>(await _cityReadRepository.GetAllDistrictCitiesAsync(query.DistrictId));
        }
    }
}
