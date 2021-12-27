using Application.Common;
using System;

namespace Application.Users.Registrators.Dtos
{
    public class ShortRegistratorDto : IdDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegisteredAt { get; set; }
        public int Status { get; set; }
    }
}
