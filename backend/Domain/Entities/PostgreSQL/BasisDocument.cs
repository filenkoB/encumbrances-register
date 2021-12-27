using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PostgreSQL.Entities
{
    public class BasisDocument : EntityId
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public DateTime IssueDate { get; set; }
        public string Issuer { get; set; }

        public Encumbrance Encumbrance { get; set; }
    }
}
