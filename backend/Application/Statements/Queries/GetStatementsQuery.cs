using Application.Statements.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Read;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Statements.Queries
{
    public class GetStatementsQuery : IRequest<StatementsListDto>
    { 
        public int Page { get; set; }
        public int Length { get; set; }

        public GetStatementsQuery(int page, int length)
        {
            Page = page;
            Length = length;
        }
    }

    public class GetStatementsQueryHandler : IRequestHandler<GetStatementsQuery, StatementsListDto>
    {
        private readonly IStatementReadRepository _statementReadRepository;
        private readonly IStatementTypeReadRepository _statementTypeReadRepository;
        private readonly IMapper _mapper;

        public GetStatementsQueryHandler(IStatementReadRepository statementReadRepository, IStatementTypeReadRepository statementTypeReadRepository, IMapper mapper)
        {
            _statementReadRepository = statementReadRepository;
            _statementTypeReadRepository = statementTypeReadRepository;
            _mapper = mapper;
        }

        public async Task<StatementsListDto> Handle(GetStatementsQuery query, CancellationToken token)
        {
            int page = query.Page;
            int length = query.Length;
            var statements = _mapper.Map<IEnumerable<ListStatementInfo>>(await _statementReadRepository.GetStatementsWithOffsetAsync(page, length));

            var listingStatements = new List<ListStatementInfoDto>();
            foreach (var statement in statements)
            {
                var listingStatement = _mapper.Map<ListStatementInfoDto>(statement);
                listingStatement.TypeName = await _statementTypeReadRepository.GetTypeNameAsync(statement.StatementTypeId);
                listingStatements.Add(listingStatement);
            }

            return new StatementsListDto()
            {
                Statements = listingStatements.ToArray(),
                MaxStatements = await _statementReadRepository.GetStatementsNumberAsync()
            };
        }
    }
}
