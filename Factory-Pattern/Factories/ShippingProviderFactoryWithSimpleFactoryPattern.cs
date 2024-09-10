using Factory_Pattern.Models;
using Factory_Pattern.ShippingProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Pattern.Factories
{
    public class ShippingProviderFactoryWithSimpleFactoryPattern
    {
        // simple factory pattern
        public static ShippingProvider CreateShippingProvider(string country)
        {
            ShippingProvider shippingProvider;

            if (country == "Australia")
            {
                var shippingCostCalculator = new ShippingCostCalculator(internationalShippingFee: 250,
                    extraWeightFee: 500)
                {
                    ShippingType = "Standard"
                };

                var customsHandlingOptions = new CustomsHandlingOptions()
                {
                    TaxOptions = "PrePaid"
                };

                var insuranceOptions = new InsuranceOptions()
                {
                    ProviderHasExtendedInsurance = false,
                    ProviderHasInsurance = false
                };

                // shipping card does not need to know clientId, secret
                shippingProvider = new AustralianPostShippingProvider("clientId", "secret",
                    shippingCostCalculator, customsHandlingOptions, insuranceOptions);
            }
            else if (country == "Sweden")
            {
                var shippingCostCalculator = new ShippingCostCalculator(internationalShippingFee: 250,
                    extraWeightFee: 500)
                {
                    ShippingType = "Standard"
                };

                var customsHandlingOptions = new CustomsHandlingOptions()
                {
                    TaxOptions = "PayOnArrival"
                };

                var insuranceOptions = new InsuranceOptions()
                {
                    ProviderHasExtendedInsurance = false,
                    ProviderHasInsurance = true
                };

                // shipping card does not need to know clientId, secret
                shippingProvider = new AustralianPostShippingProvider("API_KEY", "secret",
                    shippingCostCalculator, customsHandlingOptions, insuranceOptions);
            }
            else
            {
                throw new NotSupportedException();
            }

            return shippingProvider;
        }
    }


}
