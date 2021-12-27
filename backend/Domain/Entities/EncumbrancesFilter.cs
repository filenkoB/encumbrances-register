using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EncumbrancesFilter
    {
		public string EncumbranceRegistrationNumber { get; set; }
		public Guid ObjectId { get; set; }
		public string DebtorFirstName { get; set; }
		public string DebtorLastName { get; set; }
		public string DebtorPatronymic { get; set; }
		public string DebtopTaxpayerACN { get; set; }
		public string DebtopDepName { get; set; }
		public string DebtorIdentificator { get; set; }
	}
}
