using Application.Common;
using System;

namespace Application.Cities.Dtos
{
    public class CityDto : EnumTypeDto
    { 
        public Guid DistrictId { get; set; }
    }
}
