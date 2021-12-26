using Application.Streets.Dtos;
using AutoMapper;
using Domain.Interfaces.Abstract;
using Domain.Interfaces.Read;
using Domain.PostgreSQL.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Streets.Queries
{
    public class GetAllCityStreetsQuery : IRequest<IEnumerable<StreetDto>>
    {
        public Guid CityId { get; set; }
        public GetAllCityStreetsQuery(Guid cityId)
        {
            CityId = cityId;
        }
    }

    public class GetAllCityStreetsQueryHandler : IRequestHandler<GetAllCityStreetsQuery, IEnumerable<StreetDto>>
    {
        private readonly IReadRepository<Street> _streetReadRepository;
        private readonly IMapper _mapper;
        public GetAllCityStreetsQueryHandler(IReadRepository<Street> streetReadRepository, IMapper mapper)
        {
            _streetReadRepository = streetReadRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StreetDto>> Handle(GetAllCityStreetsQuery query, CancellationToken token)
        {
            return _mapper.Map<IEnumerable<StreetDto>>(await _streetReadRepository.GetEntitiesByParamsAsync(
                "Streets",
                ("CityId", query.CityId)    
            ));
        }
    }
}
