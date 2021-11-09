using Domain.Common;
using System.Collections.Generic;

namespace Domain.PostgreSQL.Entities
{
    public class CurrencyType : EnumType
    {
        public char Sign { get; set; }

        public ICollection<EncumbranceTerms> EncumbranceTerms { get; set; }
    }
}
