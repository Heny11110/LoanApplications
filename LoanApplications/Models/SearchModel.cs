using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanApplications.Shared.Domain;

namespace LoanApplications.Web.Models
{
    public class SearchModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? LoanAmount { get; set; }
        public string BusinessName { get; set; }
        public int? CreditRating { get; set; }
        public IEnumerable<Applicant> Applicants { get; set; }

    }
}
