using LoanApplications.Shared.Domain;
using LoanApplications.Shared.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanApplicationsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanApplicationsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;


        public LoanApplicationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        

        // GET: api/<LoanApplicationsControllers>
        [HttpGet]
        public IActionResult Get()
        {
            var applicants = _unitOfWork.Applicants.GetAll() ;
            return Ok(applicants);
        }

        // GET api/<LoanApplicationsControllers>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoanApplicationsControllers>
        [HttpPost]
        public IActionResult Post()
        {
            var applicant = new Applicant
            {
                FirstName = "Henoke",
                LastName = "Mukesh Murugan"
            };
            
            _unitOfWork.Applicants.Add(applicant);
            _unitOfWork.SubmitChanges();
            return Ok();
        }

        // PUT api/<LoanApplicationsControllers>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoanApplicationsControllers>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
