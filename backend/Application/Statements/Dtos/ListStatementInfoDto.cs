using Application.Common;
using System;

namespace Application.Statements.Dtos
{
    public class ListStatementInfoDto : IdDto
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public string TypeName { get; set; }
    }
}
