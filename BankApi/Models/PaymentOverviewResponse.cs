namespace BankApi.Models
{
    public class PaymentOverviewResponse
    {
        public double MonthlyPayment { get; set; }
        public double TotAmountOfInterest { get; set; }
        public double AdminFee { get; set; }
        public double APR { get; set; }
    }
}
