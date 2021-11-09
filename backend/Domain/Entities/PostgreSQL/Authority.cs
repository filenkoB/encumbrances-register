using System;
using System.Collections.Generic;

namespace Domain.PostgreSQL.Entities
{
    public class Authority
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid AddressId { get; set; }
        public bool IsActive { get; set; }

        public ICollection<User> Users { get; set; }
        public Address Address { get; set; }
    }
}
