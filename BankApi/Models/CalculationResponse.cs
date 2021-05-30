using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi.Models
{
    public class CalculationResponse
    {
        public double MonthlyPayment { get; set; }
        public double TotAmountOfInterest { get; set; }
        public double AdminFee { get; set; }
        public double APR { get; set; }
    }
}
