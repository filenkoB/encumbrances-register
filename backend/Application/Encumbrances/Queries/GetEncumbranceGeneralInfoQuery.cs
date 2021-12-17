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
    public class GetEncumbranceGeneralInfoQuery : IRequest<EncumbranceGeneralInfoDto>
    {
        public Guid Id;
        
        public GetEncumbranceGeneralInfoQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetEncumbranceGeneralInfoQueryHandler : IRequestHandler<GetEncumbranceGeneralInfoQuery, EncumbranceGeneralInfoDto>
    {
        private readonly IEncumbranceReadRepository _encumbranceReadRepository;
        private readonly IMapper _mapper;

        public GetEncumbranceGeneralInfoQueryHandler(IEncumbranceReadRepository encumbranceReadRepository, IMapper mapper)
        {
            _encumbranceReadRepository = encumbranceReadRepository ?? throw new ArgumentNullException(nameof(encumbranceReadRepository));
            _mapper = mapper;
        }

        public async Task<EncumbranceGeneralInfoDto> Handle(GetEncumbranceGeneralInfoQuery query, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
