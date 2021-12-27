using Application.Statements.Dtos;
using AutoMapper;
using Domain.Interfaces.Read;
using MediatR;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Statements.Queries
{
    public class GetUserRegistrationStatementsQuery : IRequest<UserRegistrationStatementsListDto>
    {
        public int Page { get; set; }
        public int Length { get; set; }

        public GetUserRegistrationStatementsQuery(int page, int length)
        {
            Page = page;
            Length = length;
        }
    }

    public class GetUserRegistrationStatementsQueryHandler : IRequestHandler<GetUserRegistrationStatementsQuery, UserRegistrationStatementsListDto>
    {
        private readonly IStatementReadRepository _statementReadRepository;
        private readonly IMapper _mapper;

        public GetUserRegistrationStatementsQueryHandler(IStatementReadRepository statementReadRepository, IMapper mapper)
        {
            _statementReadRepository = statementReadRepository;
            _mapper = mapper;
        }
        public async Task<UserRegistrationStatementsListDto> Handle(GetUserRegistrationStatementsQuery query, CancellationToken cancellationToken)
        {
            int page = query.Page;
            int length = query.Length;

            IEnumerable<BsonDocument> documents = await _statementReadRepository.GetUserRegistrationStatementsAsync(page, length);
            var statements = _mapper.Map<IEnumerable<ListUserRegistrationStatementInfoDto>>(documents);

            return new UserRegistrationStatementsListDto()
            {
                Statements = statements.ToArray(),
                MaxStatements = await _statementReadRepository.GetRegistrationStatementsNumberAsync()
            };
        }
    }
}
