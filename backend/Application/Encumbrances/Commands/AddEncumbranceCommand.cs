using Application.Statements.Dtos;
using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Abstract;
using Domain.Interfaces.Read;
using Domain.Interfaces.Write;
using Domain.PostgreSQL.Entities;
using Infrastructure.Repositories.Write;
using MediatR;
using MongoDB.Bson;
using System;
using System.Dynamic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Encumbrances.Commands
{
    public class AddEncumbranceCommand : IRequest<Unit>
    {
        public Guid StatementId { get; set; }

        public AddEncumbranceCommand(Guid statementId)
        {
            StatementId = statementId;
        }
    }

    public class AddEncumbranceCommandHandler : IRequestHandler<AddEncumbranceCommand, Unit>
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
        private readonly IMapper _mapper;

        public AddEncumbranceCommandHandler(
            IStatementReadRepository statementReadRepository,
            IStatementWriteRepository statementWriteRepository,
            IWriteRepository<Encumbrance> encumbranceWriteRepository,
            IWriteRepository<EncumbranceParticipant> encumbranceParticipantWriteRepository,
            IWriteRepository<BasisDocument> basisDocumentWriteRepository,
            IWriteRepository<EncumbranceTerms> encumbranceTermsWriteRepository,
            IEncumbranceObjectWriteRepository encumbranceObjectWriteRepository,
            IWriteRepository<Address> addressWriteRepository,
            IEncumbranceReadRepository encumbranceReadRepository,
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
            _mapper = mapper;
        }
        public async Task<Unit> Handle(AddEncumbranceCommand command, CancellationToken cancellationToken)
        {
            BsonDocument statementBson = await _statementReadRepository.GetStatementAsync(command.StatementId);
            var statement = _mapper.Map<StatementRegistrationDto>(statementBson);

            var tierAddress = _mapper.Map<Address>(statement.EncumbranceTier.Address);
            await _addressWriteRepository.InsertAsync(tierAddress);

            var tier = _mapper.Map<EncumbranceParticipant>(statement.EncumbranceTier);
            tier.AddressId = tierAddress.Id;
            await _encumbranceParticipantWriteRepository.InsertAsync(tier);

            var debtorAddress = _mapper.Map<Address>(statement.EncumbranceDebtor.Address);
            await _addressWriteRepository.InsertAsync(debtorAddress);

            var debtor = _mapper.Map<EncumbranceParticipant>(statement.EncumbranceDebtor);
            debtor.AddressId = debtorAddress.Id;
            await _encumbranceParticipantWriteRepository.InsertAsync(debtor);

            var basisDocument = _mapper.Map<BasisDocument>(statement.BasisDocument);
            await _basisDocumentWriteRepository.InsertAsync(basisDocument);

            var encumbranceObjectId = Guid.NewGuid();
            statement.EncumbranceObject.Id = encumbranceObjectId;
            var encumbranceObjectBson = _mapper.Map<EncumbranceObjectDto>(statement.EncumbranceObject).ToBsonDocument();
            await _encumbranceObjectWriteRepository.InsertDocumentAsync(encumbranceObjectBson);

            var encumbranceTerms = _mapper.Map<EncumbranceTermDto, EncumbranceTerms>(statement.EncumbranceTerm);
            await _encumbranceTermsWriteRepository.InsertAsync(encumbranceTerms);

            var encumbrance = _mapper.Map<Encumbrance>(statement.EncumbranceInfo);
            encumbrance.TierId = tier.Id;
            encumbrance.DebtorId = debtor.Id;
            encumbrance.BasisDocumentId = basisDocument.Id;
            encumbrance.ObjectId = encumbranceObjectId;
            encumbrance.KindId = statement.EncumbranceInfo.EncumbranceKindId;
            encumbrance.TypeId = statement.EncumbranceInfo.EncumbranceTypeId;
            encumbrance.AlienationLimitId = statement.EncumbranceInfo.AlienationLimitId;
            encumbrance.LastEncumbranceOccurrenceDate = statement.EncumbranceInfo.LastEncumbranceOccurrenceDate;
            encumbrance.TypeDescription = statement.EncumbranceInfo.TypeDescription;
            encumbrance.RegistrationTypeId = statement.EncumbranceInfo.RegistrationTypeId;
            encumbrance.TermsId = encumbranceTerms.Id;
            encumbrance.CreatedOn = DateTime.Now;
            encumbrance.Number = (await _encumbranceReadRepository.GetNextEncumbranceNumberAsync()).ToString();

            await _encumbranceWriteRepository.InsertAsync(encumbrance);
            await _statementWriteRepository.UpdateEncumbranceStatementStatus(statement.Id, 1);

            return Unit.Value;
        }
    }
}
