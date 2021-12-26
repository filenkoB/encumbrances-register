using Application.Common;
using Application.Statements.Dtos;

namespace Application.Encumbrances.Dtos
{
    public class EncumbranceDto
    {
        public EncumbranceParticipantDto EncumbranceTier { get; set; }
        public EncumbranceParticipantDto EncumbranceDebtor { get; set; }
        public BasisDocumentDto BasisDocument { get; set; }
        public EncumbranceInfoDto EncumbranceInfo { get; set; }
        public EncumbranceTermDto EncumbranceTerm { get; set; }
        public EncumbranceObjectDto EncumbranceObject { get; set; }
    }
}
