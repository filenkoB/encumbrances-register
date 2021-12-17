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
    public class GetEncumbranceDebtorInfoQuery : IRequest<EncumbranceDebtorInfoDto>
    {
        public Guid Id;

        public GetEncumbranceDebtorInfoQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetEncumbranceDebtorInfoQueryHandler : IRequestHandler<GetEncumbranceDebtorInfoQuery, EncumbranceDebtorInfoDto>
    {
        private readonly IEncumbranceReadRepository _encumbranceReadRepository;
        private readonly IMapper _mapper;

        public GetEncumbranceDebtorInfoQueryHandler(IEncumbranceReadRepository encumbranceReadRepository, IMapper mapper)
        {
            _encumbranceReadRepository = encumbranceReadRepository ?? throw new ArgumentNullException(nameof(encumbranceReadRepository));
            _mapper = mapper;
        }

        public async Task<EncumbranceDebtorInfoDto> Handle(GetEncumbranceDebtorInfoQuery query, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
