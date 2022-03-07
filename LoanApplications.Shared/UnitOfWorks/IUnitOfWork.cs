using System;
using System.Collections.Generic;
using System.Text;
using LoanApplications.Shared.Repository;

namespace LoanApplications.Shared.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryApplicant Applicants { get; }
        IRepositoryBusinessInfo BusinessInfos { get; }
        IRepositoryLoanApplication LoanApplications { get; }
        int SubmitChanges();
    }
}
