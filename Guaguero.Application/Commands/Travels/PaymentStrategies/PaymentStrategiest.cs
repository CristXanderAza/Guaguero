using CXAD.NetStrategist;

namespace Guaguero.Application.Commands.Travels.PaymentStrategies
{
    public class PaymentStrategiest : Strategist<IPayStrategy, string>
    {
        public PaymentStrategiest(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            RegisterStrategy("Credit", typeof(CreditPayStrategy));
        }
    }
}
