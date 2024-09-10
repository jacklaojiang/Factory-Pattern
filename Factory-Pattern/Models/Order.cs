using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Pattern.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Sender Sender { get; set; }

        public ShippingStatus ShippingStatus { get; set; }
    }
}
