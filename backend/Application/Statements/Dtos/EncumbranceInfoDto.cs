using System;

namespace Application.Statements.Dtos
{
    public class EncumbranceInfoDto
    {
        public Guid EncumbranceKindId { get; set; }
        public Guid RegistrationTypeId { get; set; }
        public DateTime LastEncumbranceOccurrenceDate { get; set; }
        public Guid EncumbranceTypeId { get; set; }
        public Guid AlienationLimitId { get; set; }
        public string TypeDescription { get; set; }
    }
}
