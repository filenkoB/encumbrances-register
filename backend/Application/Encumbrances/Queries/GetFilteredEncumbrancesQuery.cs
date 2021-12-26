using Application.Encumbrances.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Abstract;
using Domain.PostgreSQL.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Encumbrances.Queries
{
    public class GetFilteredEncumbrancesQuery : IRequest<EncumbranceList>
    {
        public EncumbranceSelectFilter Filter { get; set; }

        public GetFilteredEncumbrancesQuery(EncumbranceSelectFilter filter)
        {
            Filter = filter;
        }
    }

    public class GetFilteredEncumbrancesQueryHandler : IRequestHandler<GetFilteredEncumbrancesQuery, EncumbranceList>
    {
        private readonly IEncumbranceReadRepository _encumbranceReadRepository;
        private readonly IEncumbranceObjectReadRepository _encumbranceObjectReadRepository;
        private readonly IReadRepository<EncumbranceParticipant> _encumbranceParticipantReadRepository;

        public GetFilteredEncumbrancesQueryHandler(
            IEncumbranceReadRepository encumbranceReadRepository,
            IEncumbranceObjectReadRepository encumbranceObjectReadRepository,
            IReadRepository<EncumbranceParticipant> encumbranceParticipantReadRepository)
        {
            _encumbranceReadRepository = encumbranceReadRepository;
            _encumbranceObjectReadRepository = encumbranceObjectReadRepository;
            _encumbranceParticipantReadRepository = encumbranceParticipantReadRepository;
        }
        public async Task<EncumbranceList> Handle(GetFilteredEncumbrancesQuery query, CancellationToken cancellationToken)
        {
            EncumbranceSelectFilter filter = query.Filter;

            IEnumerable<Encumbrance> encumbrances = default;
            if (String.IsNullOrEmpty(filter.ObjectSerialNumber) && String.IsNullOrEmpty(filter.ObjectStateRegNumber))
            {
                encumbrances = await _encumbranceReadRepository.GetEncumbrancesByFilterAsync(filter);
            }
            else
            {
                encumbrances = await _encumbranceReadRepository.GetEncumbranesAsync();
            }

            var resultList = new List<ShortEncumbrance>();
            foreach (var encumbrance in encumbrances)
            {
                var encumbranceObject = await _encumbranceObjectReadRepository.GetEncumbranceObjectById(encumbrance.ObjectId);
                var serialNumber = encumbranceObject["SerialNumber"].IsBsonNull ? null : encumbranceObject["SerialNumber"].AsString;
                var stateRegistrationNumber = encumbranceObject["StateRegistrationNumber"].IsBsonNull ? null : encumbranceObject["StateRegistrationNumber"].AsString;

                if (!String.IsNullOrEmpty(filter.ObjectSerialNumber) && !String.IsNullOrEmpty(filter.ObjectStateRegNumber) &&
                    serialNumber != filter.ObjectSerialNumber && stateRegistrationNumber != filter.ObjectStateRegNumber)
                {
                    continue;
                }

                var tierName = (await _encumbranceParticipantReadRepository.GetEntityByIdAsync(encumbrance.TierId, "EncumbranceParticipants")).Name;
                resultList.Add(new ShortEncumbrance()
                {
                    Id = encumbrance.Id,
                    Number = encumbrance.Number,
                    Date = encumbrance.CreatedOn,
                    ObjectType = encumbranceObject == null 
                        ? "Невизначене рухоме майно"
                        : "Рухоме майно, що має серійні номери",
                    Tier = tierName
                });
            }

            return new EncumbranceList()
            {
                Encumbrances = resultList.ToArray(),
                Length = resultList.Count
            };
        }
    }
}
