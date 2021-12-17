using Application.Encumbrances.Dtos;
using AutoMapper;
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
    public class GetEncumbranceTierInfoQuery : IRequest<EncumbranceTierInfoDto>
    {
        public Guid Id;

        public GetEncumbranceTierInfoQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetEncumbranceTierInfoQueryHandler : IRequestHandler<GetEncumbranceTierInfoQuery, EncumbranceTierInfoDto>
    {
        private readonly IEncumbranceReadRepository _encumbranceReadRepository;
        private readonly IMapper _mapper;

        public GetEncumbranceTierInfoQueryHandler(IEncumbranceReadRepository encumbranceReadRepository, IMapper mapper)
        {
            _encumbranceReadRepository = encumbranceReadRepository ?? throw new ArgumentNullException(nameof(encumbranceReadRepository));
            _mapper = mapper;
        }

        public async Task<EncumbranceTierInfoDto> Handle(GetEncumbranceTierInfoQuery query, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
