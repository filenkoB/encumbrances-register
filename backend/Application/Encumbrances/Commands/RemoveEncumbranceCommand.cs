using Application.Statements.Dtos;
using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Abstract;
using Domain.Interfaces.Read;
using Domain.Interfaces.Services;
using Domain.Interfaces.Write;
using Domain.PostgreSQL.Entities;
using Infrastructure.Repositories.Write;
using MediatR;
using MongoDB.Bson;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Encumbrances.Commands
{
    public class RemoveEncumbranceCommand : IRequest<Unit>
    {
        public Guid StatementId { get; set; }
        public Guid RegistratorId { get; set; }
        public string IpAddress { get; set; }

        public RemoveEncumbranceCommand(Guid statementId, Guid registratorId, string ipAddress)
        {
            RegistratorId = registratorId;
            IpAddress = ipAddress;
            StatementId = statementId;
        }
    }

    public class RemoveEncumbranceCommandHandler : IRequestHandler<RemoveEncumbranceCommand, Unit>
    {
        private readonly IWriteRepository<Encumbrance> _encumbranceWriteRepository;
        private readonly IWriteRepository<EncumbranceParticipant> _encumbranceParticipantWriteRepository;
        private readonly IWriteRepository<BasisDocument> _basisDocumentWriteRepository;
        private readonly IWriteRepository<EncumbranceTerms> _encumbranceTermsWriteRepository;
        private readonly IEncumbranceObjectWriteRepository _encumbranceObjectWriteRepository;
        private readonly IWriteRepository<Address> _addressWriteRepository;
        private readonly IStatementReadRepository _statementReadRepository;
        private readonly IRegistratorLogService _registratorLogService;
        private readonly IStatementWriteRepository _statementWriteRepository;
        private readonly IMapper _mapper;

        public RemoveEncumbranceCommandHandler(
            IStatementReadRepository statementReadRepository,
            IWriteRepository<Encumbrance> encumbranceWriteRepository,
            IWriteRepository<EncumbranceParticipant> encumbranceParticipantWriteRepository,
            IWriteRepository<BasisDocument> basisDocumentWriteRepository,
            IWriteRepository<EncumbranceTerms> encumbranceTermsWriteRepository,
            IEncumbranceObjectWriteRepository encumbranceObjectWriteRepository,
            IStatementWriteRepository statementWriteRepository,
            IWriteRepository<Address> addressWriteRepository,
            IRegistratorLogService registratorLogService,
            IMapper mapper)
        {
            _encumbranceWriteRepository = encumbranceWriteRepository;
            _addressWriteRepository = addressWriteRepository;
            _encumbranceObjectWriteRepository = encumbranceObjectWriteRepository;
            _encumbranceParticipantWriteRepository = encumbranceParticipantWriteRepository;
            _encumbranceTermsWriteRepository = encumbranceTermsWriteRepository;
            _basisDocumentWriteRepository = basisDocumentWriteRepository;
            _statementReadRepository = statementReadRepository;
            _statementWriteRepository = statementWriteRepository;
            _registratorLogService = registratorLogService;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(RemoveEncumbranceCommand command, CancellationToken cancellationToken)
        {
            BsonDocument statementBson = await _statementReadRepository.GetStatementAsync(command.StatementId);
            var statement = _mapper.Map<StatementRegistrationDto>(statementBson);

            await _encumbranceWriteRepository.DeleteAsync(statement.EncumbranceInfo.Id);

            var tier = _mapper.Map<EncumbranceParticipant>(statement.EncumbranceTier);
            await _encumbranceParticipantWriteRepository.DeleteAsync(tier.Id);
            await _addressWriteRepository.DeleteAsync(tier.Address.Id);

            var debtor = _mapper.Map<EncumbranceParticipant>(statement.EncumbranceDebtor);
            await _encumbranceParticipantWriteRepository.DeleteAsync(debtor.Id);
            await _addressWriteRepository.DeleteAsync(debtor.Address.Id);

            var basisDocument = _mapper.Map<BasisDocument>(statement.BasisDocument);
            await _basisDocumentWriteRepository.DeleteAsync(basisDocument.Id);

            await _encumbranceObjectWriteRepository.DeleteDocumentAsync(statement.EncumbranceObject.Id);

            var encumbranceTerms = _mapper.Map<EncumbranceTermDto, EncumbranceTerms>(statement.EncumbranceTerm);
            await _encumbranceTermsWriteRepository.DeleteAsync(encumbranceTerms.Id);
            await _statementWriteRepository.UpdateEncumbranceStatementStatus(statement.Id, 1);

            await _registratorLogService.LogStatementPerformOperation(
                statement.Id,
                command.RegistratorId,
                new Guid("45836c7d-81bc-4c61-950a-a6f1d9bea828"),
                command.IpAddress
            );

            return Unit.Value;
        }
    }
}
