using Domain.Common;
using System;

namespace Domain.Entities
{
    public class ShortEncumbrance : EntityId
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public string Tier { get; set; }
        public string ObjectType { get; set; }
    }
}
