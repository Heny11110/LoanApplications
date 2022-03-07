using LoanApplications.Shared.Domain;

namespace LoanApplications.Shared.Repository
{
    public class RepositoryLoanApplication : Repository<LoanApplication>, IRepositoryLoanApplication
    {
        public RepositoryLoanApplication(ApplicationContext context) : base(context)
        {

        }

    }
}
