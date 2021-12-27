using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.PostgreSQL.Entities
{
    public class City : EntityId
    {
        public string Name { get; set; }
        public Guid DistrictId { get; set; }

        public District District { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Index> Indices { get; set; }
        public ICollection<Street> Streets { get; set; }
    }
}
