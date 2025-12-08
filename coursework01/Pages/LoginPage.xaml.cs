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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            LoginTB.Text = "1";
            PasswordPB.Password = "11111";
        }

        private async void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTB.Text;
            string password = PasswordPB.Password;

            if (string.IsNullOrWhiteSpace(login))
            {
                MessageBox.Show("Введите логин");
                return;
            }

            else if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите пароль");
                return;
            }


            if (login == "admin" && password == "admin")
            {
                NavigatePage("AdminPage");
                return;
            }

            try
            {
                var customer = await DBAccess.DBAccess.GetUser(login, password);

                if (customer == null)
                {
                    MessageBox.Show("Пользователь не найден");
                    return;
                }

                App.CurrentCustomer = customer;
                NavigatePage("ProfilePage");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreationButton_Click(object sender, RoutedEventArgs e) => NavigatePage("RegisterPage");

        private void NavigatePage(string pageName)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.MainFrame.Navigate(new Uri($"Pages/{pageName}.xaml", UriKind.Relative));
        }
    }
}
