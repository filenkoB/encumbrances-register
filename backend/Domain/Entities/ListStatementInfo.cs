using Domain.Common;
using System;

namespace Domain.Entities
{
    public class ListStatementInfo : EntityId
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public Guid StatementTypeId { get; set; }
    }
}
