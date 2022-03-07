using System.ComponentModel.DataAnnotations;
using LoanApplications.Shared.Repository;

namespace LoanApplications.Web.Models
{
    public class LoanApplicationModel
    {
       
        public string Name { get; set; }
        public decimal LoanRequested { get; set; }
        public int MonthsToPayback { get; set; }
        public int APRRate { get; set; }
        public int CreditRating   { get; set; }
        [Required]
        public int NumberOfDefaults { get; set; }
        public int LateLoanPayments { get; set; }
        public int TotalOutstandingDebt { get; set; }
        public string RiskRating { get; set; }

        public int ApplicantId { get; set; }
    }
}
