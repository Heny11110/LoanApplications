using LoanApplications.Shared.Repository;

namespace LoanApplications.Shared.Domain
{
    public class  LoanApplication: BaseDomainEntity    {
       
        public string Name { get; set; }
        public decimal LoanRequested { get; set; }
        public int MonthsToPayback { get; set; }
        public int APRRate { get; set; }
        public int CreditRating   { get; set; }
        public int NumberOfDefaults { get; set; }
        public int LateLoanPayments { get; set; }
        public int TotalOutstandingDebt { get; set; }
        public string RiskRating { get; set; }
        public Applicant Applicant { get; set; }
    }
}
