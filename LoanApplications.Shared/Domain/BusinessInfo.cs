using LoanApplications.Shared.Repository;

namespace LoanApplications.Shared.Domain
{
    public class BusinessInfo: BaseDomainEntity
    {
      
        public string Name { get; set; }

        public Applicant Applicant { get; set; }
    }
}
