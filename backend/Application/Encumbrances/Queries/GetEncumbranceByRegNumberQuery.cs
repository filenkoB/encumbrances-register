using Application.Encumbrances.Dtos;
using Application.Statements.Dtos;
using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Abstract;
using Domain.PostgreSQL.Entities;
using MediatR;
using MongoDB.Bson;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Encumbrances.Queries
{
    public class GetEncumbranceByRegNumberQuery : IRequest<EncumbranceDto>
    {
        public string Number { get; set; }

        public GetEncumbranceByRegNumberQuery(string number)
        {
            Number = number;
        }
    }

    public class GetEncumbranceByRegNumberQueryHandler : IRequestHandler<GetEncumbranceByRegNumberQuery, EncumbranceDto>
    {
        private readonly IEncumbranceReadRepository _encumbranceReadRepository;
        private readonly IReadRepository<EncumbranceParticipant> _encumbranceParticipantReadRepository;
        private readonly IReadRepository<BasisDocument> _basisDocumentReadRepository;
        private readonly IReadRepository<EncumbranceTerms> _encumbranceTermsReadRepository;
        private readonly IEncumbranceObjectReadRepository _encumbranceObjectReadRepository;
        private readonly IReadRepository<Address> _addressReadRepository;
        private readonly IMapper _mapper;

        public GetEncumbranceByRegNumberQueryHandler(
            IEncumbranceReadRepository encumbranceReadRepository,
            IReadRepository<EncumbranceParticipant> encumbranceParticipantReadRepository,
            IReadRepository<BasisDocument> basisDocumentReadRepository,
            IReadRepository<Address> addressReadRepository,
            IEncumbranceObjectReadRepository encumbranceObjectReadRepository,
            IReadRepository<EncumbranceTerms> encumbranceTermsReadRepository,
            IMapper mapper)
        {
            _encumbranceParticipantReadRepository = encumbranceParticipantReadRepository;
            _encumbranceObjectReadRepository = encumbranceObjectReadRepository;
            _basisDocumentReadRepository = basisDocumentReadRepository;
            _encumbranceReadRepository = encumbranceReadRepository;
            _encumbranceTermsReadRepository = encumbranceTermsReadRepository;
            _addressReadRepository = addressReadRepository;
            _mapper = mapper;
        }
        public async Task<EncumbranceDto> Handle(GetEncumbranceByRegNumberQuery query, CancellationToken cancellationToken)
        {
            var encumbrance = await _encumbranceReadRepository.GetEncumbranceByRegNumber(query.Number);

            var tier = await _encumbranceParticipantReadRepository.GetEntityByIdAsync(encumbrance.TierId, "EncumbranceParticipants");
            tier.Address = await _addressReadRepository.GetEntityByIdAsync(tier.AddressId, "Addresses");
            var debtor = await _encumbranceParticipantReadRepository.GetEntityByIdAsync(encumbrance.DebtorId, "EncumbranceParticipants");
            debtor.Address = await _addressReadRepository.GetEntityByIdAsync(debtor.AddressId, "Addresses");
            var basisDocument = await _basisDocumentReadRepository.GetEntityByIdAsync(encumbrance.BasisDocumentId, "BasisDocuments");
            var terms = await _encumbranceTermsReadRepository.GetEntityByIdAsync(encumbrance.TermsId, "EncumbranceTerms");
            BsonDocument encumbranceObject = await _encumbranceObjectReadRepository.GetEncumbranceObjectById(encumbrance.ObjectId);

            var encumbranceDto = new EncumbranceDto()
            {
                EncumbranceTier = _mapper.Map<EncumbranceParticipantDto>(tier),
                EncumbranceDebtor = _mapper.Map<EncumbranceParticipantDto>(debtor),
                BasisDocument = _mapper.Map<BasisDocumentDto>(basisDocument),
                EncumbranceTerm = _mapper.Map<EncumbranceTermDto>(terms),
                EncumbranceInfo = _mapper.Map<EncumbranceInfoDto>(encumbrance),
                EncumbranceObject = _mapper.Map<EncumbranceObjectDto>(encumbranceObject)
            };

            return encumbranceDto;
        }
    }
}
