using Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Encumbrances.Dtos
{
    public class ShortEncumbranceDto : IdDto
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public string Tier { get; set; }
        public string Type { get; set; }
    }
}
