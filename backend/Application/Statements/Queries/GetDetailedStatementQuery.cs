using Application.Common;
using Application.Statements.Dtos;
using AutoMapper;
using Domain.Interfaces.Read;
using MediatR;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Statements.Queries
{
    public class GetDetailedStatementQuery : IRequest<object>
    {
        public Guid StatementId { get; set; }
        public GetDetailedStatementQuery(Guid statementId)
        {
            StatementId = statementId;
        }
    }

    public class GetDetailedStatementQueryHandler : IRequestHandler<GetDetailedStatementQuery, object>
    {
        private readonly IStatementReadRepository _statementReadRepository;
        private readonly IMapper _mapper;
        public GetDetailedStatementQueryHandler(IStatementReadRepository statementReadRepository, IMapper mapper)
        {
            _statementReadRepository = statementReadRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetDetailedStatementQuery query, CancellationToken token)
        {
            BsonDocument statement = await _statementReadRepository.GetStatementAsync(query.StatementId);
            
            switch (statement["StatementTypeId"].AsGuid.ToString())
            {
                case "b231d49d-8c34-4efc-bde2-e398d35a5587":
                    return _mapper.Map<RegistrationStatementDto>(statement);
                default:
                    throw new InvalidOperationException();
            }

        }
    }
}
 