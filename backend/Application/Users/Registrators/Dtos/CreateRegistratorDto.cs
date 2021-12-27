using Application.Common;
using Application.Users.Users.Dtos;
using System;

namespace Application.Users.Registrators.Dtos
{
    public class CreateRegistratorDto : HumanDto
    {
        public PassportInfoDto PassportInfo { get; set; }
        public Guid AuthorityId { get; set; }
    }
}
