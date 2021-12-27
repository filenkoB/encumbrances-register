using Application.Authorities.Dtos;
using Application.Common;

namespace Application.Users.Registrators.Dtos
{
    public class RegistratorDto : HumanDto
    {
        public int Status { get; set; }
        public ShortAuthorityDto Authority { get; set; }
    }
}
