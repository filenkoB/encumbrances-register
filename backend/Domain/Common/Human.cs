using Domain.PostgreSQL.Entities;
using System;

namespace Domain.Common
{
    public class Human : EntityId
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public string IdentificatorId { get; set; }
        public string PassportInfoId { get; set; }

        public Identificator Identificator { get; set; }
        public PassportInfo PassportInfo { get; set; }
    }
}
