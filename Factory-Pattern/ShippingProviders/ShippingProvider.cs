using System.Diagnostics.Contracts;
using Factory_Pattern.Models;

namespace Factory_Pattern.ShippingProviders
{
    public abstract class ShippingProvider
    {
        public InsuranceOptions InsuranceOptions { get; protected set; }
        public CustomsHandlingOptions CustomsHandlingOptions { get; protected set; }
        public ShippingCostCalculator ShippingCostCalculator { get; protected set; }

        public bool RequireSignature { get; set; }
        public abstract string GenerateShippingLabelFor(Order order);
    }

    public class ShippingCostCalculator
    {
        public ShippingCostCalculator(float internationalShippingFee, float extraWeightFee)
        {
            InternationalShippingFee = internationalShippingFee;
            ExtraWeightFee = extraWeightFee;
        }

        public float InternationalShippingFee { get; set; }
        public float ExtraWeightFee { get; set; }
        public string ShippingType { get; set; }

    }

    public class CustomsHandlingOptions
    {
        public string TaxOptions { get; set; }
    }

    public class InsuranceOptions
    {
        public bool ProviderHasInsurance { get; set; }
        public bool ProviderHasExtendedInsurance { get; set; }
    }
}
