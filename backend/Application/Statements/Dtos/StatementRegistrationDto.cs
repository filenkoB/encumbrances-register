using Application.Common;
using System;

namespace Application.Statements.Dtos
{
    public class StatementRegistrationDto : IdDto
    {
        public byte Status { get; set; }
        public Guid StatementTypeId { get; set; }
        public Guid StatementOwnerId { get; set; }
        public GeneralInfoDto GeneralInfo { get; set; }
        public EncumbranceParticipantDto EncumbranceTier { get; set; }
        public EncumbranceParticipantDto EncumbranceDebtor { get; set; }
        public BasisDocumentDto BasisDocument { get; set; }
        public EncumbranceInfoDto EncumbranceInfo { get; set; }
        public EncumbranceTermDto EncumbranceTerm { get; set; }
        public EncumbranceObjectDto EncumbranceObject { get; set; }
    }
}
