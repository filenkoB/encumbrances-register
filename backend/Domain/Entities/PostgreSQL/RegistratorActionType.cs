using Domain.Common;
using System.Collections.Generic;

namespace Domain.PostgreSQL.Entities
{
    public class RegistratorActionType : EntityId
    {
        public string Name { get; set; }
        
        public ICollection<RegistratorEncumbranceActionsHistory> RegistratorEncumbranceActions { get; set; }
    }
}
