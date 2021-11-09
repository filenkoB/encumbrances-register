using Domain.Common;
using System;

namespace Domain.PostgreSQL.Entities
{
    public class ExtractGettingActionsHistory : EntityId
    {
        public DateTime Date { get; set; }
        public Guid EncumbranceId { get; set; }
        public Guid? PaymentCertificateId { get; set; }
        public Guid IssuerId { get; set; }
        public Guid? StatementId { get; set; }

        public Registrator IssuerRegistrator { get; set; }
        public User IssuerUser { get; set; }
        public Encumbrance Encumbrance { get; set; }
    }
}
