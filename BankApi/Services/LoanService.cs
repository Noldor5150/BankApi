using BankApi.Services.Interfaces;
using System;

namespace BankApi.Services
{
    public class LoanService : ILoanService
    {
        public double CountAdminFee(double adminFeeRate, double adminFeeMaxAmount, double loanAmount)
        {
            double adminFeeAmount;
            if (loanAmount * adminFeeRate / 100 >= adminFeeMaxAmount)
            {
                adminFeeAmount = adminFeeMaxAmount;
            }
            else
            {
                adminFeeAmount = loanAmount * adminFeeRate / 100;
            }
            return adminFeeAmount;
        }

        public double CountMonthlyPayment(double loanAmount, double yearlyInterestRate, int numberOfMonths)
        {
            double monthlyInterestRate = yearlyInterestRate / 12 / 100;
            double monthlyPaymentAmount = Math.Round(loanAmount * monthlyInterestRate / (1 - Math.Pow(1 + monthlyInterestRate, -1 * numberOfMonths)), 2);
            return monthlyPaymentAmount;
        }

        public double CountAPR(double loanAmount, double totalInterestPaid, int numberOfYears, double fees)
        {
            int numberOfDays = numberOfYears * 365;
            double apr = Math.Round(((fees + totalInterestPaid) / loanAmount) / numberOfDays * 365 * 100, 2);
            return apr;
        }
    }
}
