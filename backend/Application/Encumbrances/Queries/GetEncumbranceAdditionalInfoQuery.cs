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
    public class GetEncumbranceAdditionalInfoQuery : IRequest<EncumbranceAdditionalInfoDto>
    {
        public Guid Id;

        public GetEncumbranceAdditionalInfoQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetEncumbranceAdditionalInfoQueryHandler : IRequestHandler<GetEncumbranceAdditionalInfoQuery, EncumbranceAdditionalInfoDto>
    {
        private readonly IEncumbranceReadRepository _encumbranceReadRepository;
        private readonly IMapper _mapper;

        public GetEncumbranceAdditionalInfoQueryHandler(IEncumbranceReadRepository encumbranceReadRepository, IMapper mapper)
        {
            _encumbranceReadRepository = encumbranceReadRepository ?? throw new ArgumentNullException(nameof(encumbranceReadRepository));
            _mapper = mapper;
        }

        public async Task<EncumbranceAdditionalInfoDto> Handle(GetEncumbranceAdditionalInfoQuery query, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
