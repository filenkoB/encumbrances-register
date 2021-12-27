using Domain.Common;
using System;
using System.Net;

namespace Domain.PostgreSQL.Entities
{
    public class RegistratorEncumbranceActionsHistory : EntityId
    {
        public DateTime Date { get; set; }
        public Guid RegistratorActionTypeId { get; set; }
        public Guid RegistratorId { get; set; }
        public Guid StatementId { get; set; }
        public string IpAddress { get; set; }
        public Registrator Registrator { get; set; }
        public RegistratorActionType RegistratorActionType { get; set; }
    }
}
