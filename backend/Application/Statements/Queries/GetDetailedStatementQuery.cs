using Application.Statements.Dtos;
using AutoMapper;
using Domain.Interfaces.Read;
using MediatR;
using MongoDB.Bson;
using System;
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
                case "3c63d55d-4b8f-4c06-8122-6a1c3ac72699":
                case "beca126e-1e23-4db3-865a-a4645baf0428":
                case "41b2c7aa-7af6-4221-9afa-3d54e70b8470":
                    return _mapper.Map<StatementRegistrationDto>(statement);
                default:
                    throw new InvalidOperationException();
            }

        }
    }
}
 