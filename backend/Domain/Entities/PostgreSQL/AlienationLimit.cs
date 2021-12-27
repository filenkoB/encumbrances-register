using Domain.Common;
using System.Collections.Generic;

namespace Domain.PostgreSQL.Entities
{
    public class AlienationLimit : EnumType
    {
        public ICollection<Encumbrance> Encumbrances { get; set; }
    }
}
