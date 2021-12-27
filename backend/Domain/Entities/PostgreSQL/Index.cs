using Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.PostgreSQL.Entities
{
    public class Index : EntityId
    {
        public string IndexCode { get; set; }
        public Guid CityId { get; set; }

        public City City { get; set; }
    }
}
