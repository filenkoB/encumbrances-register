using System;

namespace Domain.Entities
{
    public class RegistratorAction
    {
        public DateTime Date { get; set; }
        public string IpAddress { get; set; }
        public Guid ObjectId { get; set; }
        public string Description;
    }
}
