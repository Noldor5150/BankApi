using BankApi.Models;
using BankApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi.Services
{
    public class LoanService : ILoanService
    {
        private readonly ICalculationService _calculationService;
        public LoanService(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }
        public CalculationResponse GetPaymentOverview(CalculationRequest request)
        {
            int NumberOfMonths = request.DurationInYears * 12;
            double Fees = _calculationService.CountAdminFee(request.AdminFeeRate, request.AdminFeeMaxAmount, request.LoanAmount);
            double Payment = _calculationService.CountMonthlyPayment(request.LoanAmount, request.AnualInterestRate, NumberOfMonths);
            double TotalInterest = Math.Round(Payment * NumberOfMonths - request.LoanAmount, 2);
            double _APR = _calculationService.CountAPR(request.LoanAmount, TotalInterest, request.DurationInYears, Fees);
            {
                return new CalculationResponse
                {
                    AdminFee = Fees,
                    MonthlyPayment = Payment,
                    TotAmountOfInterest = TotalInterest,
                    APR = _APR
                };
            }
        }

    }
}
