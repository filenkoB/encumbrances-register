namespace Domain.Entities
{
    public class ExtractEncumbrance
    {
        public string Number { get; set; }
        public string IssueDate { get; set; }
        public string IssueRequest { get; set; }
        public string EncumbranceKind { get; set; }
        public string RegistrationType { get; set; }
        public string EncumbranceType { get; set; }
        public string BasisDocumentName { get; set; }
        public string BasisDocumentNumber { get; set; }
        public string BasisDocumentIssueDate { get; set; }
        public string BasisDocumentIssuer { get; set; }
        public string AlienationLimit { get; set; }
        public string Debtor { get; set; }
        public string Tier { get; set; }
        public string TermsObligationAmount { get; set; }
        public string CurrencyName { get; set; }
        public string EncumbranceTermTo { get; set; }
    }
}
