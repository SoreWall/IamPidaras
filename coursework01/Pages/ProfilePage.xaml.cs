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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();

            Customer customer = App.CurrentCustomer;
            TB.Text = $"Name: {customer.Surname} | First name: {customer.FirstName} || Middle name: {customer.MiddleName}";
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            NavigatePage("LoginPage");
        }

        private void CatalogButton_Click(object sender, RoutedEventArgs e)
        {
            NavigatePage("CatalogPage");
        }

        private void NavigatePage(string pageName)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.MainFrame.Navigate(new Uri($"Pages/{pageName}.xaml", UriKind.Relative));
        }
    }
}
