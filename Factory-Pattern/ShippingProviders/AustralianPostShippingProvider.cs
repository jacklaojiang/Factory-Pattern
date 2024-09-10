using Factory_Pattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Pattern.ShippingProviders
{
    public class AustralianPostShippingProvider : ShippingProvider
    {
        public AustralianPostShippingProvider(string clientId, string secret,
            ShippingCostCalculator sc, CustomsHandlingOptions co, InsuranceOptions io) {

            this.ClientId = clientId;
            this.Secret = secret;
            this.ShippingCostCalculator = sc;
            this.InsuranceOptions = io;
            this.CustomsHandlingOptions = co;
        }

        public string ClientId { get; set; }
        public string Secret { get; set; }
        public ShippingCostCalculator ShippingCostCalculator { get; set; }
        public CustomsHandlingOptions CustomsHandlingOptions { get; set;}
        public InsuranceOptions InsuranceOptions { get; set; }

        public override string GenerateShippingLabelFor(Order order)
        {
            return "Australia Post";
        }
    }
}
