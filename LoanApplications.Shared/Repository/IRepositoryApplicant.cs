using LoanApplications.Shared.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanApplications.Shared.Repository
{
    public interface IRepositoryApplicant : IRepository<Applicant>
    {
       
    }
}
  