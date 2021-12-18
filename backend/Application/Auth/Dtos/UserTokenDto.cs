using Application.Enumerations;

namespace Application.Auth.Dtos
{
    public class UserTokenDto
    {
        public string Token { get; set; }
        public UserType UserType { get; set; }
        public string Login { get; set; }

        public UserTokenDto(string token, UserType userType, string login)
        {
            Token = token;
            UserType = userType;
            Login = login;
        }
    }
}
