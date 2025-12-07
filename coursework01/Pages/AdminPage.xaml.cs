using coursework01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();

            MainDG.ItemsSource = App.DB.PurchaseRequisitions.ToList();
        }

        private void MainDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = MainDG.SelectedItem;

            if (MainDG == null || MainDG.SelectedItem == null || !MainDG.IsInitialized)
            {
                return;
            }

            if (selectedItem is Models.PurchaseRequisition request)
            {
                App.currentPurchase = request;
            }
        }

        private void SetPurchaseBTN_Click(object sender, RoutedEventArgs e)
        {
            if (App.currentPurchase == null)
            {
                MessageBox.Show("Нужно выбрать заявку");
                return;
            }

            NavigatePage("PurchasePage");
        }

        private void RemoveBTN_Click(object sender, RoutedEventArgs e)
        {
            PurchaseRequisition purchase = App.currentPurchase;

            if (purchase == null)
            {
                MessageBox.Show("Нужно выбрать заявку");
                return;
            }

            App.DB.PurchaseRequisitions.Remove(purchase);
            App.DB.SaveChanges();
            MainDG.ItemsSource = App.DB.PurchaseRequisitions.ToList();
        }

        private void ShowCustomers_Click(object sender, RoutedEventArgs e)
        {
            NavigatePage("CustomersPage");
        }

        private void BackBTB_Click(object sender, RoutedEventArgs e)
        {
            NavigatePage("LoginPage");
        }

        private void SalesBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigatePage("SalesPage");
        }

        private void EmployeesBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigatePage("EmployeesPage");
        }

        private void NavigatePage(string page)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.MainFrame.Navigate(new Uri($"Pages/{page}.xaml", UriKind.Relative));
        }
    }
}
