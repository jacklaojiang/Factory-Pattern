// See https://aka.ms/new-console-template for more information
using Factory_Pattern;
using Factory_Pattern.Factories;
using Factory_Pattern.Models;



var order = new Order
{
    Id = 1,
    Name = "Test",
    Sender = new Sender
    {
        Country = "Australia"
    },
};

// still needs to use condition to tell which factory to be used
var cart1 = new ShoppingCart(order, new GlobalExpressShippingProviderFactory());
var shippingLabel1 = cart1.Finalize();
Console.WriteLine(shippingLabel1);

var cart2 = new ShoppingCart(order, new StandardShippingProviderFactory());
var shippingLabel2 = cart2.Finalize();
Console.WriteLine(shippingLabel2);


