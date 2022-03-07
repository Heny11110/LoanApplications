using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using LoanApplications.Shared.Domain;
using LoanApplications.Web.Models;
using Newtonsoft.Json;

namespace LoanApplications.Web.Controllers
{
    public class SearchController : Controller
    {
        readonly HttpClient _client = new HttpClient();
        string url  = "https://localhost:44318/api/";
        
        public IActionResult Index()
        {
            //var model = new SearchModel
            //{
            //    Applicants = JsonConvert.DeserializeObject<List<Applicant>>(await _client.GetStringAsync(url)).ToList()
            //};

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(SearchModel searchCriteria)
        {
            var applicants = JsonConvert.DeserializeObject<List<Applicant>>(await _client.GetStringAsync(url+ "Applicants")).ToList();
            var loanApplications = JsonConvert.DeserializeObject<List<LoanApplication>>(await _client.GetStringAsync(url+"LoanApplications")).ToList();
            var businessInfos = JsonConvert.DeserializeObject<List<BusinessInfo>>(await _client.GetStringAsync(url+"BusinessInfo")).ToList();
            if (searchCriteria!=null)
            {
                if (!String.IsNullOrEmpty(searchCriteria.FirstName))
                    applicants = (List<Applicant>) applicants.Where(s => s.FirstName.Contains(searchCriteria.FirstName)).ToList();
                if (!String.IsNullOrEmpty(searchCriteria.LastName)) 
                    applicants = (List<Applicant>)applicants.Where(s => s.LastName.Contains(searchCriteria.LastName));
                if ( searchCriteria.CreditRating.HasValue) 
                    applicants = (List<Applicant>)applicants.Where(s => Equals(s.LoanApplications, loanApplications.Where(rec => rec.CreditRating.Equals(searchCriteria.CreditRating))));
                if (searchCriteria.LoanAmount.HasValue) 
                    applicants = (List<Applicant>)applicants.Where(s => Equals(s.LoanApplications, loanApplications.Where(rec => rec.LoanRequested.Equals(searchCriteria.LoanAmount))));
                if (!String.IsNullOrEmpty(searchCriteria.BusinessName)) 
                    applicants = (List<Applicant>)applicants.Where(s => Equals(s.BusinessInformationCollection, businessInfos.Where(rec => rec.Name.Contains(searchCriteria.BusinessName))));
                searchCriteria.Applicants = applicants;
            }

           
            return View(searchCriteria);
        }


    }
}
