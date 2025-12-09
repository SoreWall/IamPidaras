using coursework01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace coursework01.Pages
{
    /// <summary>
    /// Логика взаимодействия для CarPage.xaml
    /// </summary>
    public partial class CarPage : Page
    {
        public CarPage()
        {
            InitializeComponent();

            Models.Car car = App.CurrentCar;

            CarNameTB.Text = $"{car.Manufacturer.Trim()} {car.Model.Trim()}";
            PriceTB.Text = $"{FormatPrice(car.Price)} ₽";
            YearTB.Text = car.Year.ToString();
            BodyTypeTB.Text = car.BodyType;
            EngineTypeTB.Text = car.EngineType;
            CountyTB.Text = car.Country;
            PhoneTB.Text = car.HotlinePhoneNumber;
            SiteTB.Text = car.Website;

            CarImg.Source = new BitmapImage(new Uri($"/cars/{car.Image}", UriKind.Relative));
            CarNameTB.Text = $"{car.Manufacturer.Trim()} {car.Model.Trim()}";
        }

        private static string FormatPrice(int price)
        {
            return price.ToString("N0", System.Globalization.CultureInfo.InvariantCulture)
                            .Replace(",", " ");
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigatePage("CatalogPage");
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            App.DB.Add(new PurchaseRequisition {Car=App.CurrentCar.Id, Customer=App.CurrentCustomer.Id});
            App.DB.SaveChanges();
            MessageBox.Show("Заяка успешно отправлена, наш сотрудник свяжется с вами");
            NavigatePage("CatalogPage");
        }

        private void NavigatePage(string page)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.MainFrame.Navigate(new Uri($"Pages/{page}.xaml", UriKind.Relative));
        }
    }
}
