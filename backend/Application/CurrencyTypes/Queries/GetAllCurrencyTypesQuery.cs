using Application.CurrencyTypes.Dtos;
using AutoMapper;
using Domain.Interfaces.Read;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CurrencyTypes.Queries
{
    public class GetAllCurrencyTypesQuery : IRequest<IEnumerable<CurrencyTypeDto>>
    { }

    public class GetAllCurrencyTypesQueryHandler : IRequestHandler<GetAllCurrencyTypesQuery, IEnumerable<CurrencyTypeDto>>
    {
        private readonly ICurrencyTypeReadRepository _currencyTypeReadRepository;
        private readonly IMapper _mapper;
        public GetAllCurrencyTypesQueryHandler(ICurrencyTypeReadRepository currencyTypeReadRepository, IMapper mapper)
        {
            _currencyTypeReadRepository = currencyTypeReadRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CurrencyTypeDto>> Handle(GetAllCurrencyTypesQuery query, CancellationToken token)
        {
            return _mapper.Map<IEnumerable<CurrencyTypeDto>>(await _currencyTypeReadRepository.GetAllCurrencyTypesAsync());
        }
    }
}
