using coursework01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xaml;

namespace coursework01.DBAccess
{
    public static class DBAccess
    {
        public static async Task<Customer> GetUser(string login, string password)
        {
            return App.DB.Customers.FirstOrDefault(x => x.Login==login && x.Password==password);
        }

        public static async Task CreateUser(Customer customer)
        {
            App.DB.Customers.Add(customer);
            App.DB.SaveChanges();
        }

        public static async Task RemoveUser(Customer customer)
        {
            App.DB.Remove(customer);
            App.DB.SaveChanges();
        }

        public static async Task<int> CountUsers()
        {
            return App.DB.Customers.Count();
        }
    }
}
