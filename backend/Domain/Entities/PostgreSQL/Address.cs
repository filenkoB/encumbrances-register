using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.PostgreSQL.Entities
{
    public class Address : EntityId
    {
        public int? Flat { get; set; }
        public string Building { get; set; }
        public int? Corps { get; set; }
        public Guid CountryId { get; set; }
        public Guid RegionId { get; set; }
        public Guid DistrictId { get; set; }
        public Guid CityId { get; set; }
        public string Index { get; set; }
        public Guid StreetId { get; set; }

        public User User { get; set; }
        public Country Country { get; set; }
        public Region Region { get; set; }
        public District District { get; set; }
        public City City { get; set; }
        public Street Street { get; set; }
        public Authority Authority { get; set; }
    }
}
