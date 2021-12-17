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
    public class GetEncumbranceTermsInfoQuery : IRequest<EncumbranceTermsInfoDto>
    {
        public Guid Id;

        public GetEncumbranceTermsInfoQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetEncumbranceTermsInfoQueryHandler : IRequestHandler<GetEncumbranceTermsInfoQuery, EncumbranceTermsInfoDto>
    {
        private readonly IEncumbranceReadRepository _encumbranceReadRepository;
        private readonly IMapper _mapper;

        public GetEncumbranceTermsInfoQueryHandler(IEncumbranceReadRepository encumbranceReadRepository, IMapper mapper)
        {
            _encumbranceReadRepository = encumbranceReadRepository ?? throw new ArgumentNullException(nameof(encumbranceReadRepository));
            _mapper = mapper;
        }

        public async Task<EncumbranceTermsInfoDto> Handle(GetEncumbranceTermsInfoQuery query, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
