using BankApi.Models;
using BankApi.Services;
using BankApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        // GET: api/<ValuesController>
        // Kaip pasiimti rekiama request is body

        private readonly ILoanService _loanService;
        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CalculationResponse),(int)HttpStatusCode.OK)]
        public ActionResult<CalculationResponse> Get([FromBody] CalculationRequest request)
        {
            if(request.LoanAmount == 0 || request.DurationInYears == 0)
            {
                return new BadRequestResult();
            }
            
            return _loanService.GetPaymentOverview(request);
        }
    }
}
