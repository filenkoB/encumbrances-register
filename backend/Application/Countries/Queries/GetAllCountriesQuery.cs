using Application.Countries.Dtos;
using AutoMapper;
using Domain.Interfaces.Read;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Countries.Queries
{
    public class GetAllCountriesQuery : IRequest<IEnumerable<CountryDto>>
    { }

    public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQuery, IEnumerable<CountryDto>>
    {
        private readonly ICountryReadRepository _countryReadRepository;
        private readonly IMapper _mapper;
        public GetAllCountriesQueryHandler(ICountryReadRepository countryReadRepository, IMapper mapper)
        {
            _countryReadRepository = countryReadRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CountryDto>> Handle(GetAllCountriesQuery query, CancellationToken token)
        {
            return _mapper.Map<IEnumerable<CountryDto>>(await _countryReadRepository.GetAllCountriesAsync());
        }
    }
}
