using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.PostgreSQL.Entities
{
    public class Street : EntityId
    {
        public string Name { get; set; }
        public Guid CityId { get; set; }

        public City City { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
