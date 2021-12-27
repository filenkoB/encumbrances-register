using Application.Common;
using Application.Enumerations;
using System;

namespace Application.Users.Users.Dtos
{
    public class CreateUserDto : HumanDto
    {
        public PassportInfoDto PassportInfo { get; set; }
        public string TaxpayerAccountCardNumber { get; set; }
        public string TaxpayerACNAbsenceReason { get; set; }
        public Guid? AuthorityId { get; set; }
    }
}
