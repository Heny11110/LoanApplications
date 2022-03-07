using LoanApplications.Shared.Repository;

namespace LoanApplications.Web.Models
{
    public class ApplicantModel 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
    }
}
