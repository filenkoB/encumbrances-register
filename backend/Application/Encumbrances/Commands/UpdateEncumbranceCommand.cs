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
    public class UpdateEncumbranceCommand : IRequest<Unit>
    {
        public Guid StatementId { get; set; }
        public Guid RegistratorId { get; set; }
        public string IpAddress { get; set; }

        public UpdateEncumbranceCommand(Guid statementId, Guid registratorId, string ipAddress)
        {
            RegistratorId = registratorId;
            IpAddress = ipAddress;
            StatementId = statementId;
        }
    }

    public class UpdateEncumbranceCommandHandler : IRequestHandler<UpdateEncumbranceCommand, Unit>
    {
        private readonly IWriteRepository<Encumbrance> _encumbranceWriteRepository;
        private readonly IWriteRepository<EncumbranceParticipant> _encumbranceParticipantWriteRepository;
        private readonly IWriteRepository<BasisDocument> _basisDocumentWriteRepository;
        private readonly IWriteRepository<EncumbranceTerms> _encumbranceTermsWriteRepository;
        private readonly IEncumbranceObjectWriteRepository _encumbranceObjectWriteRepository;
        private readonly IStatementWriteRepository _statementWriteRepository;
        private readonly IWriteRepository<Address> _addressWriteRepository;
        private readonly IStatementReadRepository _statementReadRepository;
        private readonly IEncumbranceReadRepository _encumbranceReadRepository;
        private readonly IRegistratorLogService _registratorLogService;
        private readonly IMapper _mapper;

        public UpdateEncumbranceCommandHandler(
            IStatementReadRepository statementReadRepository,
            IStatementWriteRepository statementWriteRepository,
            IWriteRepository<Encumbrance> encumbranceWriteRepository,
            IWriteRepository<EncumbranceParticipant> encumbranceParticipantWriteRepository,
            IWriteRepository<BasisDocument> basisDocumentWriteRepository,
            IWriteRepository<EncumbranceTerms> encumbranceTermsWriteRepository,
            IEncumbranceObjectWriteRepository encumbranceObjectWriteRepository,
            IWriteRepository<Address> addressWriteRepository,
            IEncumbranceReadRepository encumbranceReadRepository,
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
            _encumbranceReadRepository = encumbranceReadRepository;
            _registratorLogService = registratorLogService;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateEncumbranceCommand command, CancellationToken cancellationToken)
        {
            BsonDocument statementBson = await _statementReadRepository.GetStatementAsync(command.StatementId);
            var statement = _mapper.Map<StatementRegistrationDto>(statementBson);

            var tierAddress = _mapper.Map<Address>(statement.EncumbranceTier.Address);
            await _addressWriteRepository.UpdateAsync(tierAddress);

            var tier = _mapper.Map<EncumbranceParticipant>(statement.EncumbranceTier);
            await _encumbranceParticipantWriteRepository.UpdateAsync(tier);

            var debtorAddress = _mapper.Map<Address>(statement.EncumbranceDebtor.Address);
            await _addressWriteRepository.UpdateAsync(debtorAddress);

            var debtor = _mapper.Map<EncumbranceParticipant>(statement.EncumbranceDebtor);
            await _encumbranceParticipantWriteRepository.UpdateAsync(debtor);

            var basisDocument = _mapper.Map<BasisDocument>(statement.BasisDocument);
            await _basisDocumentWriteRepository.UpdateAsync(basisDocument);

            var encumbranceObjectBson = statement.EncumbranceObject.ToBsonDocument();
            await _encumbranceObjectWriteRepository.UpdateDocumentAsync(encumbranceObjectBson);

            var encumbranceTerms = _mapper.Map<EncumbranceTerms>(statement.EncumbranceTerm);
            await _encumbranceTermsWriteRepository.UpdateAsync(encumbranceTerms);

            var encumbrance = _mapper.Map<Encumbrance>(statement.EncumbranceInfo);
            encumbrance.BasisDocumentId = basisDocument.Id;
            encumbrance.DebtorId = debtor.Id;
            encumbrance.TierId = tier.Id;
            encumbrance.TermsId = encumbranceTerms.Id;
            encumbrance.ObjectId = encumbranceObjectBson["_id"].AsGuid;
            encumbrance.Number = statement.EncumbranceInfo.Number;
            encumbrance.CreatedOn = statement.GeneralInfo.RegistrationDate;

            await _encumbranceWriteRepository.UpdateAsync(encumbrance);
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
