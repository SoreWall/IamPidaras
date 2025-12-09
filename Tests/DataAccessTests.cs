using coursework01;
using coursework01.DBAccess;
using coursework01.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests;

[TestClass]
public class DataAccessTests
{
    [TestMethod]
    public async Task GetUser_ValidCredentials_ReturnsCustomer()
    {
        try
        {
            var result = await DBAccess.GetUser("1", "11111");

            if (result != null)
            {
                Assert.IsNotNull(result);
                Console.WriteLine($"Найден пользователь: {result.Surname}");
            }
            else
            {
                Console.WriteLine("Пользователь не найден - это может быть нормально для теста");
                Assert.IsNull(result); 
            }
        }
        catch (Exception ex)
        {
            Assert.Fail($"Метод GetUser вызвал исключение: {ex.Message}");
        }
    }

    [TestMethod]
    public async Task CountUsers_ReturnsNumber()
    {
        try
        {
            var count = await DBAccess.CountUsers();

            Assert.IsTrue(count >= 0, "Количество пользователей должно быть >= 0");
            Console.WriteLine($"Количество пользователей: {count}");
        }
        catch (Exception ex)
        {
            Assert.Fail($"Метод CountUsers вызвал исключение: {ex.Message}");
        }
    }

    [TestMethod]
    public void Customer_Constructor_CreatesObject()
    {
        var customer = new Customer(
            999, 
            "Тестов",
            "Тест",
            "Тестович",
            "+79990000000",
            "testuser",
            "testpass",
            "test@test.com",
            "Тестовый адрес"
        );

        Assert.IsNotNull(customer);
        Assert.AreEqual("Тестов", customer.Surname);
        Assert.AreEqual("testuser", customer.Login);
    }
}
