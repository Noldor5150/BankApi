namespace BankApi.Services.Interfaces
{
    public interface ILoanService
    {
        double CountAdminFee(double adminFeeRate, double adminFeeMaxAmount, double loanAmount);
        double CountMonthlyPayment(double loanAmount, double yearlyInterestRate, int numberOfMonths);
        double CountAPR(double loanAmount, double totalInterestPaid, int numberOfYears, double fees);
    }
}
