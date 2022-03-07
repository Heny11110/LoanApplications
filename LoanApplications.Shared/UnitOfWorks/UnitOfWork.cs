 
using System;
using System.Collections.Generic;
using System.Text;
using LoanApplications.Shared.Domain;
using LoanApplications.Shared.Repository;

namespace LoanApplications.Shared.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Applicants = new RepositoryApplicant(_context);
            BusinessInfos = new RepositoryBusinessInfo (_context);
            LoanApplications = new RepositoryLoanApplication(_context);
        }
      
       public  IRepositoryApplicant Applicants { get; private set; }
       public IRepositoryBusinessInfo BusinessInfos { get; private set; }
       public IRepositoryLoanApplication LoanApplications { get; private set; }
        public int SubmitChanges()
        {
            return _context.SaveChanges();
        }
       
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
