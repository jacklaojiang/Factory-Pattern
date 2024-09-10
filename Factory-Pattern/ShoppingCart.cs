using Factory_Pattern.Factories;
using Factory_Pattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Pattern
{

    public class ShoppingCart
    {
        private Order order;
        private ShippingProviderFactory shippingProviderFactory;
        public ShoppingCart(Order order, ShippingProviderFactory shippingProviderFactory) 
        {
            this.order = order;
            this.shippingProviderFactory = shippingProviderFactory;
        }

        public string Finalize()
        {
            // create shipping provider, but this is not extensible , need to move it out from shippingCart, 
            // so shopping Card does not need to know which shippingProvider will be used
            //ShippingProvider shippingProvider;

            //if (order.Sender.Country == "Australia")
            //{
            //    var shippingCostCalculator = new ShippingCostCalculator(internationalShippingFee: 250,
            //        extraWeightFee: 500)
            //    {
            //        ShippingType = "Standard"
            //    };

            //    var customsHandlingOptions = new CustomsHandlingOptions()
            //    {
            //        TaxOptions = "PrePaid"
            //    };

            //    var insuranceOptions = new InsuranceOptions()
            //    {
            //        ProviderHasExtendedInsurance = false,
            //        ProviderHasInsurance = false
            //    };

            //    // shipping card does not need to know clientId, secret
            //    shippingProvider = new AustraliaPostShippingProvider("clientId", "secret",
            //        shippingCostCalculator, customsHandlingOptions, insuranceOptions);
            //}
            //else if (order.Sender.Country == "Sweden")
            //{
            //    var shippingCostCalculator = new ShippingCostCalculator(internationalShippingFee: 250,
            //        extraWeightFee: 500)
            //    {
            //        ShippingType = "Standard"
            //    };

            //    var customsHandlingOptions = new CustomsHandlingOptions()
            //    {
            //        TaxOptions = "PayOnArrival"
            //    };

            //    var insuranceOptions = new InsuranceOptions()
            //    {
            //        ProviderHasExtendedInsurance = false,
            //        ProviderHasInsurance = true
            //    };

            //    // shipping card does not need to know clientId, secret
            //    shippingProvider = new AustraliaPostShippingProvider("API_KEY", "secret",
            //        shippingCostCalculator, customsHandlingOptions, insuranceOptions);
            //}
            //else
            //{
            //    throw new NotSupportedException();
            //}
            var shippingProvider = shippingProviderFactory.GetShippingProvider(order.Sender.Country);

            order.ShippingStatus = ShippingStatus.ReadyForShippment;

            return shippingProvider.GenerateShippingLabelFor(order);
        }
    }
}
