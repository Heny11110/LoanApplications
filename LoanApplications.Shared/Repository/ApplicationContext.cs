using LoanApplications.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanApplications.Shared.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }

        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<BusinessInfo> BusinessInfos { get; set; }
        public DbSet<LoanApplication> LoanApplications { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Applicant>()
                .HasData(
                    new Applicant
                    {
                        Id = 1,
                        FirstName = "Henoke",
                        LastName = "Banjaw",
                        Phone = 7894561233,
                        Address = "1 main",
                    },
                    new Applicant
                    {
                        Id = 2,
                        FirstName = "Henoke2",
                        LastName = "Banjaw2",
                        Phone = 7894561233,
                        Address = "2 main",
                       },
                    new Applicant
                    {
                        Id = 3,
                        FirstName = "Henoke3",
                        LastName = "Banjaw3",
                        Phone = 7894561233,
                        Address = "3 main",
                        
                    }
                );

            modelBuilder.Entity<LoanApplication>()
                .HasData(
                    new LoanApplication
                    {
                        Id = 2,
                        CreditRating = 700,
                        APRRate = 5,
                        LateLoanPayments = 123123,
                        LoanRequested = 23423,
                        MonthsToPayback = 12,
                        RiskRating = "Good",
                        NumberOfDefaults = 22
                    },
                    new LoanApplication
                    {
                        Id = 3,
                        CreditRating = 700,
                        APRRate = 5,
                        LateLoanPayments = 123123,
                        LoanRequested = 23423,
                        MonthsToPayback = 12,
                        RiskRating = "Good",
                        NumberOfDefaults = 22

                    },
                    new LoanApplication
                    {
                        Id = 1,
                        CreditRating = 700,
                        APRRate = 5,
                        LateLoanPayments = 123123,
                        LoanRequested = 23423,
                        MonthsToPayback = 12,
                        RiskRating = "Good",
                        NumberOfDefaults = 22
                    });

            modelBuilder.Entity<BusinessInfo>()
                .HasData(
                    new BusinessInfo
                    {
                        Id = 2,
                        Name = "Buss Name3"
                    },
                    new BusinessInfo
                    {
                        Id = 3,
                        Name = "Buss Name"
                    },
                    new BusinessInfo
                    {
                        Id = 1,
                        Name = "Buss Name2"
                    });


        }
    }
}
