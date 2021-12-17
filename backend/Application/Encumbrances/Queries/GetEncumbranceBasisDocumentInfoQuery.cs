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
    public class GetEncumbranceBasisDocumentInfoQuery : IRequest<EncumbranceBasisDocumentInfoDto>
    {
        public Guid Id;

        public GetEncumbranceBasisDocumentInfoQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetEncumbranceBasisDocumentInfoQueryHandler : IRequestHandler<GetEncumbranceBasisDocumentInfoQuery, EncumbranceBasisDocumentInfoDto>
    {
        private readonly IEncumbranceReadRepository _encumbranceReadRepository;
        private readonly IMapper _mapper;

        public GetEncumbranceBasisDocumentInfoQueryHandler(IEncumbranceReadRepository encumbranceReadRepository, IMapper mapper)
        {
            _encumbranceReadRepository = encumbranceReadRepository ?? throw new ArgumentNullException(nameof(encumbranceReadRepository));
            _mapper = mapper;
        }

        public async Task<EncumbranceBasisDocumentInfoDto> Handle(GetEncumbranceBasisDocumentInfoQuery query, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
