using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApplications.Web.Controllers
{
    public class BusinessInfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
