using System;

namespace Application.Users.Users.Dtos
{
    public class PassportInfoDto
    {
        public string SerialNumber { get; set; }
        public string PassportNumber { get; set; }
        public string AuthorityId { get; set; }
        public DateTime Date { get; set; }
    }
}