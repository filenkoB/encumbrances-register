using Domain.Entities.PostgreSQL;
using Domain.Interfaces.Read;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.StatementTypes.Queries
{
    public class GetAllStatementTypesQuery : IRequest<IEnumerable<StatementType>>
    { }

    public class GetAllStatementTypesQueryHandler : IRequestHandler<GetAllStatementTypesQuery, IEnumerable<StatementType>>
    {
        private readonly IStatementTypeReadRepository _statementTypeReadRepository;
        public GetAllStatementTypesQueryHandler(IStatementTypeReadRepository statementTypeReadRepository)
        {
            _statementTypeReadRepository = statementTypeReadRepository;
        }
        public async Task<IEnumerable<StatementType>> Handle(GetAllStatementTypesQuery query, CancellationToken token)
        {
            return await _statementTypeReadRepository.GetAllStatementTypesAsync();
        }
    }
}
