using Application.Common;

namespace Application.Statements.Dtos
{
    public class EncumbranceParticipantDto : IdDto
    {
        public string AdditionalInfo { get; set; }
        public string TaxpayerAccountCardNumber { get; set; }
        public bool IsForeigner { get; set; }
        public string Name { get; set; }
        public AddressDto Address { get; set; }
    }
}
