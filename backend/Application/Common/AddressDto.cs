using System;

namespace Application.Common
{
    public class AddressDto : IdDto
    {
        public Guid CountryId { get; set; }
        public Guid RegionId { get; set; }
        public Guid DistrictId { get; set; }
        public Guid CityId { get; set; }
        public string IndexCode { get; set; }
        public Guid StreetId { get; set; }
        public string Building { get; set; }
        public int? Flat { get; set; }
        public int? Corps { get; set; }
    }
}
