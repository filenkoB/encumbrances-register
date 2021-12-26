using System;

namespace Application.Common
{
    public class AddressComposedDto
    {
        public string CountryId { get; set; }
        public string RegionId { get; set; }
        public string DistrictId { get; set; }
        public string CityId { get; set; }
        public string IndexCode { get; set; }
        public string StreetId { get; set; }
        public string Building { get; set; }
        public int? Corps { get; set; }
        public int? Flat { get; set; }
    }
}
