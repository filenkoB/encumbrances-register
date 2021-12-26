using Application.Common;
using System;

namespace Application.Statements.Dtos
{
    public class ListUserRegistrationStatementInfoDto : IdDto
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
    }
}
