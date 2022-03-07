using LoanApplications.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanApplications.Shared.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<BusinessInfo> BusinessInfos { get; set; }
        public DbSet<LoanApplication> LoanApplications { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    var test = new List<Applicant>
        //    {
        //        new Applicant
        //        {
        //            Address="test"
        //        }
        //    };
        //    modelBuilder.Entity<Applicant>()
        //        .HasData(
        //            new Applicant
        //            {
        //                Id= 1,FirstName = "Henoke", LastName = "Banjaw", Phone = 1231231234, Address = "1 main",
        //                //LoanApplications = new List<LoanApplication>
        //                //{
        //                //    new LoanApplication
        //                //    {   Id= 1,
        //                //        CreditRating = "Good"
        //                //    }

        //                //},
        //                //BusinessInformationCollection = new List<BusinessInfo>
        //                //{
        //                //    new BusinessInfo
        //                //    {   Id= 1,
        //                //        Name = "Buss Name2"
        //                //    }
        //                //}

        //            },
        //            new Applicant
        //            {
        //                Id = 2, FirstName = "Henoke2", LastName = "Banjaw2", Phone = 1231231234, Address = "2 main",
        //                //LoanApplications = new List<LoanApplication>
        //                //{
        //                //    new LoanApplication
        //                //    {    Id = 2,
        //                //        CreditRating = "Good",
                                
        //                //    }

        //                //},
        //                //BusinessInformationCollection = new List<BusinessInfo>
        //                //{
        //                //    new BusinessInfo
        //                //    {Id = 2,
        //                //        Name = "Buss Name3"
        //                //    }
        //                //}
        //            },
        //            new Applicant
        //            {
        //                Id = 3, FirstName = "Henoke3", LastName = "Banjaw3", Phone = 1231231234, Address = "3 main",
        //                //LoanApplications = new List<LoanApplication>
        //                //{
        //                //    new LoanApplication
        //                //    { Id = 3,
        //                //        CreditRating = "Good"
        //                //    }

        //                //},
        //                //BusinessInformationCollection = new List<BusinessInfo>
        //                //{
        //                //    new BusinessInfo
        //                //    { Id = 3,
        //                //        Name = "Buss Name"
        //                //    }
        //                //}
        //            }
        //        );

        //}
    }
}
