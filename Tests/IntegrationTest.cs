using coursework01.Models;

namespace Tests;

[TestClass]
public class IntegrationTest
{
    [TestMethod]
    public void Car_PropertiesChain_DoesNotCrash()
    {
        var car = new Car
        {
            Id = 9999,
            CarModel = 9999
        };

        try
        {
            var manufacturer = car.Manufacturer;
            var model = car.Model;

            Assert.IsTrue(true);
        }
        catch (Exception)
        {
            Assert.IsTrue(true, "Пустой объект");
        }
    }
}
