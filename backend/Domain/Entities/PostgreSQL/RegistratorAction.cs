using Domain.Common;
using System;

namespace Domain.Entities
{
    public class RegistratorAction : EntityId
    {
        public DateTime IssueDate { get; set; }
        public string IpAddress { get; set; }
        public long ExecutionTime { get; set; }
        public Guid ObjectId { get; set; }
        public string OperationDescription { get; set; }
    }
}
