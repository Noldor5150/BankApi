using System;
using System.ComponentModel.DataAnnotations;

namespace BankApi.Models
{
    public class PaymentOverviewRequest
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
