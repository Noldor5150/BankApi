using BankApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi.Services.Interfaces
{
   public interface ILoanService
    {
        public CalculationResponse GetPaymentOverview(CalculationRequest request);
    }
}
