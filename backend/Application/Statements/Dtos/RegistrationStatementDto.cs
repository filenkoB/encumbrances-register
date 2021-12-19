using Application.Common;
using System;

namespace Application.Statements.Dtos
{
    public class RegistrationStatementDto : IdDto
    {
        public Guid StatementTypeId { get; set; }
        public GeneralInfoDto GeneralInfo { get; set; }
        public EncumbranceParticipantDto EncumbranceTier { get; set; }
        public EncumbranceParticipantDto EncumbranceDebtor { get; set; }
        public BasisDocumentDto BasisDocument { get; set; }
        public EncumbranceInfoDto EncumbranceInfo { get; set; }
        public EncumbranceTermDto EncumbranceTerm { get; set; }
    }
}
