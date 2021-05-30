using BankApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi.Services
{
    public class CalculationService : ICalculationService
    {
        public double CountAdminFee(double adminFeeRate, double adminFeeMaxAmount, double loanAmount)
        {
            double AdminFeeAmount;
            if (loanAmount * adminFeeRate / 100 >= adminFeeMaxAmount)
            {
                AdminFeeAmount = adminFeeMaxAmount;
            }
            else
            {
                AdminFeeAmount = loanAmount * adminFeeRate / 100;
            }
            return AdminFeeAmount;
        }

        public double CountMonthlyPayment(double loanAmount, double yearlyInterestRate, int numberOfMonths)
        {
            double MonthlyInterestRate = yearlyInterestRate / 12 / 100;
            double MonthlyPaymentAmount = Math.Round(loanAmount * MonthlyInterestRate / (1 - Math.Pow(1 + MonthlyInterestRate, -1 * numberOfMonths)), 2);
            return MonthlyPaymentAmount;
        }

        public double CountAPR(double loanAmount, double totalInterestPaid, int numberOfYears, double fees)
        {
            int numberOfDays = numberOfYears * 365;
            double APR = Math.Round(((fees + totalInterestPaid) / loanAmount) / numberOfDays * 365 * 100, 2);
            return APR;
        }
    }
}
