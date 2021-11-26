using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.PostgreSQL.Entities
{
    public class Index
    {
        [Key]
        public Guid CityId { get; set; }
        public string IndexCode { get; set; }

        public City City { get; set; }
    }
}
