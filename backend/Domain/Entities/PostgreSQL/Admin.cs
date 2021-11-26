using Domain.Common;
using System;

namespace Domain.PostgreSQL.Entities
{
    public class Admin : Human
    {
        public string AuthorityId { get; set; }
        
        public Authority Authority { get; set; }
    }
}
