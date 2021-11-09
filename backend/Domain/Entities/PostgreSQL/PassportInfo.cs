using System;

namespace Domain.PostgreSQL.Entities
{
    public class PassportInfo
    {
        public string PassportNumber { get; set; }
        public string SerialNumber { get; set; }
        public DateTime Date { get; set; }
        public Guid AuthorityId { get; set; }

        public User User { get; set; }
    }
}
