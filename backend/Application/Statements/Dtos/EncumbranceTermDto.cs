using Application.Common;
using System;

namespace Application.Statements.Dtos
{
    public class EncumbranceTermDto : IdDto
    {
        public float ObligationAmount { get; set; }
        public DateTime TermTo { get; set; }
        public string AdditionalTerms { get; set; }
        public Guid CurrencyTypeId { get; set; }
    }
}
