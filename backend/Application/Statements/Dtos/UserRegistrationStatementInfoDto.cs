using Application.Common;
using Application.Enumerations;
using Application.Users.Users.Dtos;
using Domain.Entities;

namespace Application.Statements.Dtos
{
    public class UserRegistrationStatementInfoDto : HumanDto
    {
        public UserType UserType { get; set; }
        public ComposedAddress AuthorityAddress { get; set; }
        public PassportInfoDto PassportInfo { get; set; }
    }
}
