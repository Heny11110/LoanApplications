using System.ComponentModel.DataAnnotations;
using LoanApplications.Shared.Repository;

namespace LoanApplications.Web.Models
{
    public class BusinessInfoModel
    {
        public int ApplicantId { get; set; }
        [Required]
        public string Name { get; set; }

        
    }
}
