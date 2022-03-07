using System;
using System.Collections.Generic;
using LoanApplications.Shared.Repository;
using Microsoft.EntityFrameworkCore;

namespace LoanApplications.Shared.Domain
{
    public class Applicant: BaseDomainEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
        public ICollection<LoanApplication> LoanApplications { get; set; }
        public ICollection<BusinessInfo> BusinessInformationCollection { get; set; }
    }
    
}
