using System;

namespace Application.Statements.Dtos
{
    public class BasisDocumentDto
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Issuer { get; set; }
        public DateTime IssueDate { get; set; }
    }
}
