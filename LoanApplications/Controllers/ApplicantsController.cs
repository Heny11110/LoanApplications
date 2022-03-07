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
    public class ApplicantsController : Controller
    {
        readonly HttpClient _client = new HttpClient();
        string url = "https://localhost:44318/api/";

         
        public async Task<IActionResult> Index()
        {
            var model = JsonConvert.DeserializeObject<List<Applicant>>(await _client.GetStringAsync(url + "Applicants")).ToList();
            
            return View(model);
        }
        public async Task<IActionResult> Edit(int Id)
        {
            var updatedUrl = url + Id.ToString();
           var model = JsonConvert.DeserializeObject<Applicant>(await _client.GetStringAsync(updatedUrl));

            return View(model);
        }
        
 
        public async Task<IActionResult> Delete(int Id)
        {
            var updatedUrl = url + Id.ToString();
            var model = JsonConvert.DeserializeObject<Applicant>(await _client.GetStringAsync(updatedUrl));
            var deleteTask = _client.DeleteAsync(updatedUrl);
            deleteTask.Wait();

            var result = deleteTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int Id)
        {
            var updatedUrl = url + Id.ToString();
            var model = JsonConvert.DeserializeObject<Applicant>(await _client.GetStringAsync(updatedUrl));

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateApplicant(Applicant model)
        {
            // var content = new HttpContent((model));
            var stringContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            using var response = await _client.PostAsync(url + "Applicants", stringContent);
            string jsonResponse = await response.Content.ReadAsStringAsync();
            
                return View();
            
        }
    }
}
