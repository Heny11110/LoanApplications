using LoanApplications.Shared.Domain;
using LoanApplications.Shared.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanApplications.API.Controllers
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
            var applicants = _unitOfWork.LoanApplications.GetAll();
            return Ok(applicants);
        }

        // GET api/<LoanApplicationsControllers>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var loanApplications = _unitOfWork.LoanApplications.GetById(id);
            return Ok(loanApplications);

        }

        // POST api/<LoanApplicationsControllers>
        [HttpPost]
        public IActionResult Post(LoanApplication model)
        {
             
            _unitOfWork.LoanApplications.Add(model);
            _unitOfWork.SubmitChanges();
            return Ok(model);
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