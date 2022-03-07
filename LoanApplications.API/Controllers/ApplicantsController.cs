using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanApplications.Shared.Domain;
using LoanApplications.Shared.UnitOfWorks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanApplications.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;


        public ApplicantsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // GET: api/<ApplicantsController>
        [HttpGet]
        public IActionResult Get()
        {
            var applicants = _unitOfWork.Applicants.GetAll();
            return Ok(applicants);
        }

        // GET api/<Applicantsontroller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var applicants = _unitOfWork.Applicants.GetById(id);
            return Ok(applicants);

        }

        // POST api/<Applicantsontroller>
        [HttpPost]
        public IActionResult Post(Applicant model )
        {
            var applicant = _unitOfWork.Applicants.GetById(model.Id);
            if (applicant == null)
            {
                _unitOfWork.Applicants.Add(model);
            }
            else
            {
                applicant = model;
            }
            var response = _unitOfWork.SubmitChanges();
            return Ok(model);
        }

        // PUT api/<Applicantsontroller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Applicantsontroller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var applicants = _unitOfWork.Applicants.GetById(id);
            _unitOfWork.Applicants.Remove(applicants);
            _unitOfWork.SubmitChanges();
            return Ok(applicants);
        }
    }
}
