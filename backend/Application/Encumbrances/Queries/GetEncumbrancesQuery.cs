using Application.Encumbrances.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Encumbrances.Queries
{
    public class GetEncumbrancesQuery : IRequest<IEnumerable<ShortEncumbranceDto>>
    {
        public readonly EncumbrancesFilter Filter;
        public GetEncumbrancesQuery(EncumbrancesFilter filter)
        {
            Filter = filter;
        }
    }

    public class GetEncumbrancesQueryHandler : IRequestHandler<GetEncumbrancesQuery, IEnumerable<ShortEncumbranceDto>>
    {
        private readonly IEncumbranceReadRepository _encumbranceReadRepository;
        private readonly IMapper _mapper;

        public GetEncumbrancesQueryHandler(IEncumbranceReadRepository encumbranceReadRepository, IMapper mapper)
        {
            _encumbranceReadRepository = encumbranceReadRepository ?? throw new ArgumentNullException(nameof(encumbranceReadRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<ShortEncumbranceDto>> Handle(GetEncumbrancesQuery query, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<ShortEncumbranceDto>>(await _encumbranceReadRepository.GetEncumbrancesByFilterAsync(query.Filter));
        }
    }
}
