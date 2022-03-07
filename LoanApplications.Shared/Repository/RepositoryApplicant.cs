using LoanApplications.Shared.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanApplications.Shared.Repository
{
    public class RepositoryApplicant :  Repository<Applicant>, IRepositoryApplicant
    {
        public RepositoryApplicant(ApplicationContext context) : base(context)
        {
        }
        //public RepositoryApplicant(EntityTypeBuilder<Applicant> entityBuilder) {

        //    entityBuilder.HasKey(r => r.Id);
        //    entityBuilder.Property(r => r.FirstName);
        //    entityBuilder.Property(r => r.LastName);
        //    entityBuilder.Property(r => r.Phone);
        //    entityBuilder.Property(r => r.Address);
        //} 
    }
}
  