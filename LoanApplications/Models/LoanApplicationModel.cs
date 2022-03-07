using LoanApplications.Shared.Repository;

namespace LoanApplications.Web.Models
{
    public class LoanApplicationModel
    {
       
        public string Name { get; set; }
        public decimal LoanRequested { get; set; }
        public int MonthsToPayback { get; set; }
        public decimal APRRate { get; set; }
        public string CreditRating   { get; set; }
        public int NumberOfDefaults { get; set; }
        public int LateLoanPayments { get; set; }
        public int TotalOutstandingDebt { get; set; }
        public decimal RiskRating { get; set; }

        public int ApplicantId { get; set; }
    }
}
