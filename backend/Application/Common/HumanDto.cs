using System;

namespace Application.Common
{
    public class HumanDto : IdDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public DateTime RegisteredAt { get; set; }
    }
}
