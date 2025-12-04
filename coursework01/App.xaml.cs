using coursework01.Models;
using System.Configuration;
using System.Data;
using System.Windows;

namespace coursework01
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static CarSalesCenterContext DB { get; } = new();
        public static Customer currentCustomer { get; set; }
    }

}
