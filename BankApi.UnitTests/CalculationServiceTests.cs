using BankApi.Services;
using System;
using Xunit;

namespace BankApi.UnitTests
{
    public class CalculationServiceTests
    {
        private readonly CalculationService _calculationService;
        public CalculationServiceTests()
        {
            _calculationService = new CalculationService();
        }
        [Theory]
        [InlineData(1, 10000, 500000, 5000)]
        [InlineData(1, 2000, 500000, 2000)]
        [InlineData(1, 5000, 100000, 1000)]
        public void CountAdminFee_differentScenarios(double adminFeeRate, double adminFeeMaxAmount, double loanAmount, double expected)
        {
            var result = _calculationService.CountAdminFee(adminFeeRate, adminFeeMaxAmount, loanAmount);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(500000, 5, 120, 5303.28)]
        [InlineData(100000, 4, 60, 1841.65)]
        [InlineData(300000, 6, 12, 25819.93)]
        public void CountMonthlyPayment_differentScenarios(double loanAmount, double yearlyInterestRate, int numberOfMonths, double expected)
        {
            var result = _calculationService.CountMonthlyPayment(loanAmount, yearlyInterestRate, numberOfMonths);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(500000, 136393.6, 10, 5000, 2.83)]

        public void CountAPR_differentScenarios(double loanAmount, double totalInterestPaid, int numberOfYears, double fees, double expected)
        {
            var result = _calculationService.CountAPR(loanAmount, totalInterestPaid, numberOfYears,fees);
            Assert.Equal(expected, result);
        }
    }
}
