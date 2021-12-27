using Domain.Common;
using System.Collections.Generic;

namespace Domain.PostgreSQL.Entities
{
    public class Country : EntityId
    {
        public string Name { get; set; }

        public ICollection<Address> Addresses { get; set; }
        public ICollection<Region> Regions { get; set; }
    }
}
