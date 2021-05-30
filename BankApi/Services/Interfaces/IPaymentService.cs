using BankApi.Models;

namespace BankApi.Services.Interfaces
{
    public interface IPaymentService
    {
        public PaymentOverviewResponse GetPaymentOverview(PaymentOverviewRequest request);
    }
}
