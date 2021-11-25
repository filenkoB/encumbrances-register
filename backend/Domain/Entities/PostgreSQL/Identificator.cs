using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.PostgreSQL.Entities
{
    public class Identificator
    {
        [Key]
        public string Login { get; set; }
        public string Password { get; set; }
        public Guid RefreshTokenId { get; set; }
        public int Status { get; set; }

        public User User { get; set; }
        public Admin Admin { get; set; }
        public Registrator Registrator { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}
