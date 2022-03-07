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
    public class BusinessInfoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;


        public BusinessInfoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // GET: api/<BusinessInfoController>
 
        [HttpGet]
        public IActionResult Get()
        {
            var businessInfo = _unitOfWork.BusinessInfos.GetAll();
            return Ok(businessInfo);
        }

        // GET api/<BusinessInfoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var businessInfo = _unitOfWork.BusinessInfos.GetById(id);
            return Ok(businessInfo);
        }

        // POST api/<BusinessInfoController>
        [HttpPost]
        public IActionResult Post(BusinessInfo model )
        {
            
            _unitOfWork.BusinessInfos.Add(model);
            _unitOfWork.SubmitChanges();
            return Ok(model);
        }

        // PUT api/<BusinessInfoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BusinessInfoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
