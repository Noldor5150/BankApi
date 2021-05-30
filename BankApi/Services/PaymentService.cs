using BankApi.Models;
using BankApi.Services.Interfaces;
using System;

namespace BankApi.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ILoanService _calculationService;
        public PaymentService(ILoanService calculationService)
        {
            _calculationService = calculationService;
        }
        public PaymentOverviewResponse GetPaymentOverview(PaymentOverviewRequest request)
        {
            int numberOfMonths = request.DurationInYears * 12;
            double fees = _calculationService.CountAdminFee(request.AdminFeeRate, request.AdminFeeMaxAmount, request.LoanAmount);
            double payment = _calculationService.CountMonthlyPayment(request.LoanAmount, request.AnualInterestRate, numberOfMonths);
            double totalInterest = Math.Round(payment * numberOfMonths - request.LoanAmount, 2);
            double apr = _calculationService.CountAPR(request.LoanAmount, totalInterest, request.DurationInYears, fees);
            {
                return new PaymentOverviewResponse
                {
                    AdminFee = fees,
                    MonthlyPayment = payment,
                    TotAmountOfInterest = totalInterest,
                    APR = apr
                };
            }
        }

    }
}
