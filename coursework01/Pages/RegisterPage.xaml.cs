using coursework01.Models;
using System;
using System.Collections.Generic;
using System.Text;
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
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string surname = SurnameTB.Text;
            string firstName = FirstNameTB.Text;
            string middleName = MiddleNameTB.Text;
            string phoneNumber = PhoneNumberTB.Text;
            string login = LoginTB.Text;
            string password = PasswordPB.Password;
            string email = EmailTB.Text;
            string address = AddressTB.Text;

            if (string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(firstName) 
                || string.IsNullOrWhiteSpace(middleName) || string.IsNullOrWhiteSpace(phoneNumber)
                || string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password)
                || string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            int id = await DBAccess.DBAccess.CountUsers()+1;
            Customer customer = new(id, surname, firstName, middleName, phoneNumber, login, password, email, address);
            await DBAccess.DBAccess.CreateUser(customer);
            MessageBox.Show("Пользователь успешно создан");

            GoLoginPage();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e) => GoLoginPage();

        private void GoLoginPage()
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.MainFrame.Navigate(new Uri("Pages/LoginPage.xaml", UriKind.Relative));
        }
    }
}
