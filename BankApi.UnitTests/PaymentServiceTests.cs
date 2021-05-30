using BankApi.Models;
using BankApi.Services;
using BankApi.Services.Interfaces;
using FakeItEasy;
using Xunit;

namespace BankApi.UnitTests
{
    public class PaymentServiceTests
    {
        private readonly PaymentService _loanService;
        private readonly ILoanService _calculationService;
        public PaymentServiceTests()
        {
            _calculationService = A.Fake<ILoanService>();
            _loanService = new PaymentService(_calculationService);
        }
        [Fact]
        public void GetPaymentOverview_Test()
        {
            var request = new PaymentOverviewRequest
            {
                LoanAmount = 500000,
                DurationInYears = 10
            };

            var expectedResult= new PaymentOverviewResponse
            {
                MonthlyPayment = 5303.28,
                TotAmountOfInterest = 136393.6,
                AdminFee = 5000,
                APR = 2.83
            };

            var callToCountAdminFee = A.CallTo(() => _calculationService.CountAdminFee(1, 10000, 500000));
            callToCountAdminFee.Returns(5000);

            var callToCountMonthlyPayment = A.CallTo(() => _calculationService.CountMonthlyPayment(500000, 5, 120));
            callToCountMonthlyPayment.Returns(5303.28);

            var callToCountAPR = A.CallTo(() => _calculationService.CountAPR(500000, 136393.6, 10, 5000));
            callToCountAPR.Returns(2.83);

            var result = _loanService.GetPaymentOverview(request);

            Assert.Equal(expectedResult.MonthlyPayment, result.MonthlyPayment);
            Assert.Equal(expectedResult.TotAmountOfInterest, result.TotAmountOfInterest);
            Assert.Equal(expectedResult.AdminFee, result.AdminFee);
            Assert.Equal(expectedResult.APR, result.APR);
        }
    }
}
