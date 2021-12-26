namespace Application.Statements.Dtos
{
    public class UserRegistrationStatementsListDto
    {
        public ListUserRegistrationStatementInfoDto[] Statements { get; set; }
        public long MaxStatements { get; set; }
    }
}
