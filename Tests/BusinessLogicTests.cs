using coursework01.Models;

namespace Tests;

[TestClass]
public class BusinessLogicTests
{
    [TestMethod]
    public void Car_DecreaseQuantity_Works()
    {
        var car = new Car
        {
            Quantity = 5
        };

        int initialQuantity = car.Quantity;
        car.Quantity--;

        Assert.AreEqual(initialQuantity - 1, car.Quantity);
    }

    [TestMethod]
    public void Sale_Constructor_Works()
    {
        var sale = new Sale
        {
            Id = 999,
            SalePrice = 1500000,
            Commission = 75000,
            PaymentMethod = "Карта"
        };

        Assert.AreEqual(1500000, sale.SalePrice);
        Assert.AreEqual(75000, sale.Commission);
        Assert.AreEqual("Карта", sale.PaymentMethod);
    }
}
