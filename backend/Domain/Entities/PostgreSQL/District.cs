using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.PostgreSQL.Entities
{
    public class District : EntityId
    {
        public string Name { get; set; }
        public Guid RegionId { get; set; }

        public Region Region { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
