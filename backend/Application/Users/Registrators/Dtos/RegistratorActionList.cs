using Domain.Entities;

namespace Application.Users.Registrators.Dtos
{
    public class RegistratorActionList
    {
        public RegistratorAction[] Actions { get; set; }
        public int Length { get; set; }
    }
}
