using Domain.Common;
using System;

namespace Domain.PostgreSQL.Entities
{
    public class EncumbranceParticipant : EntityId
    {
        public bool IsForeigner { get; set; }
        public string Name { get; set; }
        public Guid AddressId { get; set; }
        public string AdditionalInfo { get; set; }
        public string TaxpayerAccountCardNumber { get; set; }

        public Address Address { get; set; }
        public Encumbrance EncumbranceToTier { get; set; }
        public Encumbrance EncumbranceToDebtor { get; set; }
    }
}
