using Application.Statements.Dtos;
using AutoMapper;
using Domain.Entities.PostgreSQL;
using Domain.Interfaces.Abstract;
using Domain.Interfaces.Read;
using MediatR;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Statements.Queries
{
    public class GetUserStatementsQuery : IRequest<UserStatementListDto>
    {
        public int Page { get; set; }
        public int Length { get; set; }
        public Guid UserId { get; set; }

        public GetUserStatementsQuery(int page, int length, Guid userId)
        {
            Page = page;
            Length = length;
            UserId = userId;
        }
    }

    public class GetUserStatementsQueryHandler : IRequestHandler<GetUserStatementsQuery, UserStatementListDto>
    {
        private readonly IStatementReadRepository _statementReadRepository;
        private readonly IReadRepository<StatementType> _statementTypeReadRepository;
        private readonly IMapper _mapper;

        public GetUserStatementsQueryHandler(
            IStatementReadRepository statementReadRepository,
            IReadRepository<StatementType> statementTypeReadRepository,
            IMapper mapper)
        {
            _statementTypeReadRepository = statementTypeReadRepository;
            _statementReadRepository = statementReadRepository;
            _mapper = mapper;
        }
        public async Task<UserStatementListDto> Handle(GetUserStatementsQuery query, CancellationToken cancellationToken)
        {
            IEnumerable<BsonDocument> statementsBson =
                await _statementReadRepository.GetUserStatementsAsync(query.Page, query.Length, query.UserId);

            var statements = _mapper.Map<IEnumerable<ListUserStatementDto>>(statementsBson);
            foreach (var statement in statements)
            {
                statement.StatementType = (await _statementTypeReadRepository.GetEntityByIdAsync(statement.StatementTypeId, "StatementTypes")).Name;
            }
            return new UserStatementListDto()
            {
                Statements = statements.ToArray(),
                Length = await _statementReadRepository.GetUserStatementsNumberAsync(query.UserId)
            };
        }
    }
}
