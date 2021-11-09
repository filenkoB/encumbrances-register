using Domain.Common;
using System;

namespace Domain.PostgreSQL.Entities
{
    public class EncumbranceParticipant : EntityId
    {
        public bool IsForeigner { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public Guid AddressId { get; set; }
        public string AdditionalInfo { get; set; }

        public Encumbrance Encumbrance { get; set; }
    }
}
