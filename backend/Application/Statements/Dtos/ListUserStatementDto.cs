using Application.Common;
using System;

namespace Application.Statements.Dtos
{
    public class ListUserStatementDto : IdDto
    {
        public Guid StatementTypeId { get; set; }
        public string StatementType { get; set; }
        public int StatementStatus { get; set; }
    }
}
