using Domain.Common;
using System;

namespace Domain.PostgreSQL.Entities
{
    public class EncumbranceTerms : EntityId
    {
        public float ObligationAmount { get; set; }
        public DateTime TermTo { get; set; }
        public string AdditionalTerms { get; set; }
        public Guid CurrencyTypeId { get; set; }

        public CurrencyType CurrencyType { get; set; }
        public Encumbrance Encumbrance { get; set; }
    }
}
