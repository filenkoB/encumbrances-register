using Domain.Common;
using System.Collections.Generic;

namespace Domain.PostgreSQL.Entities
{
    public class EncumbranceKind : EnumType
    {
        public ICollection<Encumbrance> Encumbrances { get; set; }
    }
}
