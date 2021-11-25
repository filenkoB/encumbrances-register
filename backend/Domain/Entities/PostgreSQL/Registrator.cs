using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.PostgreSQL.Entities
{
    public class Registrator : Human
    {
        public string AuthorityId { get; set; }

        public Authority Authority { get; set; }
        public ICollection<RegistratorEncumbranceActionsHistory> RegistratorEncumbranceActions { get; set; }
        public ICollection<ExtractGettingActionsHistory> ExtractGettingActions { get; set; }
    }
}
