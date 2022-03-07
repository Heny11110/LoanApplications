using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using LoanApplications.Shared.Domain;
using LoanApplications.Shared.Repository;
using LoanApplications.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LoanApplications.Web.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        private IRepository<Applicant> repoAuthor;
        private IRepository<BusinessInfo> repoBook;
        public HomeController(IRepository<Applicant> repoAuthor, IRepository<BusinessInfo> repoBook)
        {
            this.repoAuthor = repoAuthor;
            this.repoBook = repoBook;
        }

        public IActionResult Index()
        {
            List<ApplicantModel> model = new List<ApplicantModel>();
            repoAuthor.GetAll().ToList().ForEach(a => {
                ApplicantModel author = new ApplicantModel
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Address = a.Address

                };
                model.Add(author);
            });
            return View("Index", model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
