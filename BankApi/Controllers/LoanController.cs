using BankApi.Models;
using BankApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        // GET: api/<ValuesController>
        // Kaip pasiimti rekiama request is body

        private readonly IPaymentService _loanService;
        public LoanController(IPaymentService loanService)
        {
            _loanService = loanService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PaymentOverviewResponse),(int)HttpStatusCode.OK)]
        public ActionResult<PaymentOverviewResponse> Get([FromBody] PaymentOverviewRequest request)
        {
            if(request.LoanAmount == 0 || request.DurationInYears == 0)
            {
                return new BadRequestResult();
            }
            
            return _loanService.GetPaymentOverview(request);
        }
    }
}
