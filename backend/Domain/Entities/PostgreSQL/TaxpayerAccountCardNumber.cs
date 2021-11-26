using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.PostgreSQL.Entities
{
    public class TaxpayerAccountCardNumber : EntityId
    {
        public string CardNumber { get; set; }
        public string AbsenceReason { get; set; }

        public User User { get; set; }
    }
}
