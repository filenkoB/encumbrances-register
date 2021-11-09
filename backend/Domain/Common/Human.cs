using Domain.Entities;
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
        public Guid IdentificatorId { get; set; }
        public Guid PassportInfoId { get; set; }

        public Identificator Identificator { get; set; }
        public PassportInfo PassportInfo { get; set; }
    }
}
