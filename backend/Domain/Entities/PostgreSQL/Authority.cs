using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.PostgreSQL.Entities
{
    public class Authority
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid AddressId { get; set; }
        public bool IsActive { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<PassportInfo> PassportInfos { get; set; }
        public ICollection<Registrator> Registrators { get; set; }
        public ICollection<Admin> Admins { get; set; }
        public Address Address { get; set; }
    }
}
