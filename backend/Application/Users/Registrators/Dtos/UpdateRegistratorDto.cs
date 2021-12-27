using Application.Common;
using System;

namespace Application.Users.Registrators.Dtos
{
    public class UpdateRegistratorDto : IdDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        public Guid AuthorityId { get; set; }
    }
}
