using coursework01.Models;

namespace Tests;

[TestClass]
public class ValidationTests
{
    [TestMethod]
    public void FormatPrice_WorksCorrectly()
    {
        int price = 2500000;
        string formatted = price.ToString("N0", System.Globalization.CultureInfo.InvariantCulture)
                            .Replace(",", " ");

        Assert.AreEqual("2 500 000", formatted);
    }

    [TestMethod]
    public void Customer_RequiredFields_NotEmpty()
    {
        var customer = new Customer(
            1000,
            "Иванов",
            "Иван",
            "Иванович",
            "+79991234567",
            "login",
            "password",
            "email@mail.com",
            "Адрес"
        );

        Assert.IsFalse(string.IsNullOrEmpty(customer.Surname));
        Assert.IsFalse(string.IsNullOrEmpty(customer.FirstName));
        Assert.IsFalse(string.IsNullOrEmpty(customer.PhoneNumber));
        Assert.IsFalse(string.IsNullOrEmpty(customer.Login));
    }
}
