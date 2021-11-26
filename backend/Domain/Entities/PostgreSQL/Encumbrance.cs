using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.PostgreSQL.Entities
{
    public class Encumbrance : EntityId
    {
        public DateTime CreatedOn { get; set; }
        public Guid TierId { get; set; }
        public Guid DebtorId { get; set; }
        public Guid BasisDocumentId { get; set; }
        public Guid KindId { get; set; }
        public Guid RegistrationTypeId { get; set; }
        public Guid TypeId { get; set; }
        public Guid AlienationLimitId { get; set; }
        public DateTime LastEncumbranceOccurrenceDate { get; set; }
        public string TypeDescription { get; set; }
        public Guid TermsId { get; set; }
        public Guid ObjectId { get; set; }

        public EncumbranceParticipant Tier { get; set; }
        public EncumbranceParticipant Debtor{ get; set; }
        public BasisDocument BasisDocument { get; set; }
        public EncumbranceKind EncumbranceKind { get; set; }
        public RegistrationType RegistrationType { get; set; }
        public EncumbranceType EncumbranceType { get; set; }
        public AlienationLimit AlienationLimit { get; set; }
        public EncumbranceTerms EncumbranceTerms { get; set; }
        public ICollection<ExtractGettingActionsHistory> ExtractGettingActions { get; set; }
    }
}
