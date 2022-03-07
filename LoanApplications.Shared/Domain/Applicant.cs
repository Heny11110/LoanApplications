using System.Collections.Generic;
using LoanApplications.Shared.Repository;

namespace LoanApplications.Shared.Domain
{
    public class Applicant: BaseDomainEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public ICollection<LoanApplication> LoanApplications { get; set; }
        public ICollection<BusinessInfo> BusinessInformationCollection { get; set; }
    }
}
