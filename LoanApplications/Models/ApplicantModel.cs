using System.ComponentModel.DataAnnotations;
using LoanApplications.Shared.Repository;

namespace LoanApplications.Web.Models
{
    public class ApplicantModel 
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
