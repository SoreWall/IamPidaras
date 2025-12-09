using coursework01.Models;

namespace Tests;

[TestClass]
public class DomainModelsTests
{
    [TestMethod]
    public void Car_Properties_WorkCorrectly()
    {
        var car = new Car
        {
            Id = 999,
            Vin = "TESTVIN123456789",
            Year = 2024,
            Mileage = 0,
            Quantity = 10,
            Price = 1000000,
            Image = "None.jpg",
            CarModel = 1
        };

        Assert.AreEqual(2024, car.Year);
        Assert.AreEqual(1000000, car.Price);
        Assert.AreEqual(10, car.Quantity);
    }

    [TestMethod]
    public void PurchaseRequisition_Properties_WorkCorrectly()
    {
        var requisition = new PurchaseRequisition
        {
            Id = 999,
            Customer = 1,
            Car = 1
        };

        Assert.AreEqual(999, requisition.Id);
        Assert.AreEqual(1, requisition.Customer);
        Assert.AreEqual(1, requisition.Car);
    }
}
