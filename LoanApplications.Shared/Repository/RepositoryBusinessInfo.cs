using LoanApplications.Shared.Domain;

namespace LoanApplications.Shared.Repository
{
    public class RepositoryBusinessInfo : Repository<BusinessInfo>, IRepositoryBusinessInfo
    {
        public RepositoryBusinessInfo(ApplicationContext context) : base(context)
        {

        }
    }
}
