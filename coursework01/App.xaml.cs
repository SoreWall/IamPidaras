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
        public static Customer CurrentCustomer { get; set; }
        public static Car CurrentCar { get; set; }
        public static readonly List<Car> _cars = App.DB.Cars.Select(x => x).ToList();
        public static string SearchFilter { get; set; } = "";
        public static string MarkFilter { get; set; } = "";
        public static int MinCostFilter { get; set; } = 0;
        public static int MaxCostFilter { get; set; } = 0;
        public static PurchaseRequisition currentPurchase { get; set; }
    }

}
