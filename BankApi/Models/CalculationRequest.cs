using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi.Models
{
    public class CalculationRequest
    {
        [Range(1000, 10000000000)]
        public double LoanAmount { get; set; }
        [Range(1, 100)]
        public int DurationInYears { get; set; }
        [Range(0.01, 100)]
        public double AnualInterestRate { get; set; } = 5;
        [Range(0, 100)]
        public double AdminFeeRate { get; set; } = 1;
        public double AdminFeeMaxAmount { get; set; } = 10000;

    }
}
