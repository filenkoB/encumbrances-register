using Application.Common;
using Application.Statements.Dtos;
using AutoMapper;
using Domain.Interfaces.Abstract;
using Domain.Interfaces.Read;
using Domain.PostgreSQL.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Statements.Queries
{
    public class GetDetailedUserRegistrationStatementQuery : IRequest<UserRegistrationStatementInfoDto>
    {
        public Guid StatementId { get; set; }

        public GetDetailedUserRegistrationStatementQuery(Guid statementId)
        {
            StatementId = statementId;
        }
    }

    public class GetDetailedUserRegistrationStatementQueryHandler : IRequestHandler<GetDetailedUserRegistrationStatementQuery, UserRegistrationStatementInfoDto>
    {
        private readonly IStatementReadRepository _statementReadRepository;
        private readonly IReadRepository<Authority> _authorityReadRepository;
        private readonly IAddressReadRepository _addressReadRepository;
        private readonly IMapper _mapper;

        public GetDetailedUserRegistrationStatementQueryHandler(
            IAddressReadRepository addressReadRepository,
            IStatementReadRepository statementReadRepository,
            IReadRepository<Authority> authorityReadRepository,
            IMapper mapper)
        {
            _addressReadRepository = addressReadRepository;
            _authorityReadRepository = authorityReadRepository;
            _statementReadRepository = statementReadRepository;
            _mapper = mapper;
        }
        public async Task<UserRegistrationStatementInfoDto> Handle(GetDetailedUserRegistrationStatementQuery query, CancellationToken cancellationToken)
        {
            var statementId = query.StatementId;
            var statementBson = await _statementReadRepository.GetStatementAsync(statementId);

            var statement = _mapper.Map<UserRegistrationStatementInfoDto>(statementBson);
            var authorityId = statementBson["AuthorityId"].AsNullableGuid;

            if (authorityId == null)
            {
                return statement;
            }


            Guid? authorityAddressId = (await _authorityReadRepository.GetEntityByIdAsync((Guid)authorityId, "Authorities")).AddressId;
            if (authorityAddressId != null)
            {
                statement.AuthorityAddress = await _addressReadRepository.GetComposedAddressAsync((Guid)authorityAddressId);
            }

            return statement;
        }
    }
}
