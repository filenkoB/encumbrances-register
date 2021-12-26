using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.PostgreSQL.Entities
{
    public class Authority : EntityId
    {
        public string Name { get; set; }
        public Guid AddressId { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Registrator> Registrators { get; set; }
        public ICollection<Admin> Admins { get; set; }
        public Address Address { get; set; }
    }
}
