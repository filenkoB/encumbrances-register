using Domain.Common;
using Domain.PostgreSQL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.PostgreSQL
{
    public class PassportAuthority
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid AddressId { get; set; }
        public bool IsActive { get; set; }

        public ICollection<PassportInfo> PassportInfos { get; set; }
        public Address Address { get; set; }
    }
}
