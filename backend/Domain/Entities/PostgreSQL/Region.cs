using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.PostgreSQL.Entities
{
    public class Region : EntityId
    {
        public string Name { get; set; }
        public Guid CountryId { get; set; }

        public Country Country { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<District> Districts { get; set; }
    }
}
