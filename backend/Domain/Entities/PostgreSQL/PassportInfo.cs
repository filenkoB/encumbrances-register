using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.PostgreSQL.Entities
{
    public class PassportInfo
    {
        [Key]
        public string PassportNumber { get; set; }
        public string SerialNumber { get; set; }
        public DateTime Date { get; set; }
        public string AuthorityId { get; set; }

        public User User { get; set; }
        public Registrator Registrator { get; set; }
        public Admin Admin { get; set; }
        public Authority Authority { get; set; }
    }
}
