using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LoanApplications.Shared.Domain;
using LoanApplications.Shared.UnitOfWorks;
using LoanApplications.Web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LoanApplications.Web.Controllers
{
    public class LoanApplicationsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        HttpClient client = new HttpClient();
        string url = "https://localhost:44318/api/";
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateApplicant()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplicant(ApplicantModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // var content = new HttpContent((model));
            var stringContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            using var response = await client.PostAsync(url+"Applicants", stringContent);
            string jsonResponse = await response.Content.ReadAsStringAsync();
            JObject jsonDeserializeObject = JsonConvert.DeserializeObject<JObject>(jsonResponse);
            var applicationId = jsonDeserializeObject["id"].ToString();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
               return RedirectToAction("CreateBusinessInfo", new ApplicantModel { Id = Convert.ToInt32(applicationId) });
            }
            else
            {
                ModelState.Clear();
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> CreateBusinessInfo(ApplicantModel model)
        {
            if (!ModelState.IsValid)
            {
                return View( );
            }
            var updatedUrl = url + "Applicants/" + model.Id.ToString();
            var applicant = JsonConvert.DeserializeObject<Applicant>(await client.GetStringAsync(updatedUrl));
            
            var businessInfo = new BusinessInfoModel
            {
                ApplicantId = model.Id
            };
            if (applicant.BusinessInformationCollection==null ) return View(businessInfo);
            var bussInfo = applicant.LoanApplications.FirstOrDefault();
            if (bussInfo != null) businessInfo.Name = bussInfo.Name;
            return View(businessInfo);
        }
        [HttpGet]
        public async Task<IActionResult> CreateLoanApplication(ApplicantModel model)
        {
            if (!ModelState.IsValid)
            {
                return View( );
            }
            var updatedUrl = url + "Applicants/" + model.Id.ToString();
            var applicant = JsonConvert.DeserializeObject<Applicant>(await client.GetStringAsync(updatedUrl));
            var random = new Random();
            int apr = random.Next(4, 12);
            var loanApplication = new LoanApplicationModel
            {
                ApplicantId = model.Id,
              

            };
            if (applicant.LoanApplications == null)
            {
                loanApplication.APRRate = apr * 100;
                loanApplication.CreditRating = random.Next(600, 750);
                loanApplication.LateLoanPayments = random.Next(25000, 1000000);
                return View(loanApplication);
            }
            var loanApp = applicant.LoanApplications.FirstOrDefault();
            if (loanApp == null)
            {
                loanApplication.APRRate = apr * 100;
                loanApplication.CreditRating = random.Next(600, 750);
                loanApplication.LateLoanPayments = random.Next(25000, 1000000);
                

                return View(loanApplication);
            }
         
            loanApplication.Name = loanApp.Name;
            loanApplication.APRRate = loanApp.APRRate;
            loanApplication.CreditRating = loanApp.CreditRating;
            loanApplication.LateLoanPayments = loanApp.LateLoanPayments;
            loanApplication.LoanRequested = loanApp.LoanRequested;
            loanApplication.MonthsToPayback = loanApp.MonthsToPayback;
            loanApplication.NumberOfDefaults = loanApp.NumberOfDefaults;
            loanApplication.RiskRating = loanApp.RiskRating;

            return View(loanApplication);
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateBusinessInfo(BusinessInfoModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var updatedUrl = url+"Applicants/" + model.ApplicantId.ToString();
            var applicant = JsonConvert.DeserializeObject<Applicant>(await client.GetStringAsync(updatedUrl));

            var businessInfo = new BusinessInfo
            {
                Name = model.Name,
            };
            applicant.BusinessInformationCollection = new List<BusinessInfo>();
            applicant.BusinessInformationCollection.Add(businessInfo);
            var stringContent = new StringContent(JsonConvert.SerializeObject(applicant), Encoding.UTF8, "application/json");

           // using var response = await client.PostAsync(url+"BusinessInfo", stringContent);
            using var response = await client.PostAsync(url + "Applicants", stringContent);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var json = response.Content.ReadAsStringAsync();

                JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(json.Result);
                JObject jsonDeserializeObject = JsonConvert.DeserializeObject<JObject>(json.Result);
                var applicationId = jsonDeserializeObject["id"].ToString();

                return RedirectToAction("CreateLoanApplication", new ApplicantModel { Id = Convert.ToInt32(applicationId) });
            }
            else
            {
                ModelState.Clear();
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateLoanApplication(LoanApplicationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var updatedUrl = url + "Applicants/" + model.ApplicantId.ToString();
            var applicant = JsonConvert.DeserializeObject<Applicant>(await client.GetStringAsync(updatedUrl));

            var loanApplication = new LoanApplication
            {
                Name = model.Name,
                APRRate = model.APRRate,
                CreditRating = model.CreditRating,
                LateLoanPayments = model.LateLoanPayments,
                LoanRequested = model.LoanRequested,
                MonthsToPayback = model.MonthsToPayback,
                NumberOfDefaults = model.NumberOfDefaults,
                RiskRating =  Shared.BusinessLogic.Calculations.CalculateRisk(model.CreditRating )

            };
            applicant.LoanApplications = new List<LoanApplication>();
            applicant.LoanApplications.Add(loanApplication);
            var stringContent = new StringContent(JsonConvert.SerializeObject(applicant), Encoding.UTF8, "application/json");

            // using var response = await client.PostAsync(url+"BusinessInfo", stringContent);
            using var response = await client.PostAsync(url + "Applicants", stringContent);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
               return RedirectToAction("Index" );
            }
            else
            {
                ModelState.Clear();
                return View();
            }
        }

        public async Task<IActionResult> EditApplicant(int applicationId)
        {
            var updatedUrl = url + "Applicants/" + applicationId.ToString();
            var applicant = JsonConvert.DeserializeObject<Applicant>(await client.GetStringAsync(updatedUrl));

            return View(new ApplicantModel
            {
                FirstName = applicant.FirstName,LastName = applicant.LastName,Address = applicant.Address,Id = applicant.Id,Phone = applicant.Phone

            });
        }
        public async Task<IActionResult> EditBusinessInfo(int businessInfoId)
        {
            var updatedUrl = url + "BusinessInfo/" + businessInfoId.ToString();
            var businessInfo = JsonConvert.DeserializeObject<BusinessInfo>(await client.GetStringAsync(updatedUrl));
             
            return View(new BusinessInfoModel
            {
                Name = businessInfo.Name
            });
        }
    }
}
