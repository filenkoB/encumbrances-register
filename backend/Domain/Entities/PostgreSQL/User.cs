using System;
using System.Collections.Generic;
using Domain.Common;

namespace Domain.PostgreSQL.Entities
{
    public class User : Human
    {
        public Guid? AuthorityId { get; set; }
        public Guid? AddressId { get; set; }
        public bool IsForeigner { get; set; }

        public string TaxpayerAccountCardNumber { get; set; }
        public string TaxpayerACNAbsenceReason { get; set; }
        public Authority Authority { get; set; }
        public Address Address { get; set; }
        public ICollection<Encumbrance> Encumbrances { get; set; }
        public ICollection<ExtractGettingActionsHistory> ExtractGettingActions { get; set; }
    }
}
