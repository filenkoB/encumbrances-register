namespace Application.Statements.Dtos
{
    public class StatementsListDto
    {
        public ListStatementInfoDto[] Statements { get; set; }
        public long MaxStatements { get; set; }
    }
}
