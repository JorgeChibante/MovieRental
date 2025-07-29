namespace MovieRental.PaymentProviders
{
    public class PaymentProviderFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public PaymentProviderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IPaymentProvider? GetPaymentProvider(string paymentMethod)
        {
            if(string.IsNullOrEmpty(paymentMethod))
                throw new ArgumentNullException(nameof(paymentMethod));

            return paymentMethod.ToLower() switch
            {
                "mbway" => _serviceProvider.GetService<MbWayProvider>(),
                "paypal" => _serviceProvider.GetService<PayPalProvider>(),
                _ => throw new ArgumentException($"Payment method {paymentMethod} is not supported")
            };
        }
    }
}