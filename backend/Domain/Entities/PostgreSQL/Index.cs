using System;

namespace Domain.PostgreSQL.Entities
{
    public class Index
    {
        public Guid CityId { get; set; }
        public string IndexCode { get; set; }

        public City City { get; set; }
    }
}
