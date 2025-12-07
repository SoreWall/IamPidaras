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
    /// Логика взаимодействия для CustomersPage.xaml
    /// </summary>
    public partial class CustomersPage : Page
    {
        public CustomersPage()
        {
            InitializeComponent();

            MainDG.ItemsSource = App.DB.Customers.ToList();
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigatePage("adminPage");
        }

        private void NavigatePage(string page)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.MainFrame.Navigate(new Uri($"Pages/{page}.xaml", UriKind.Relative));
        }
    }
}
