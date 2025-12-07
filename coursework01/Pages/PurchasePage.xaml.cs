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
    /// Логика взаимодействия для PurchasePage.xaml
    /// </summary>
    public partial class PurchasePage : Page
    {
        public PurchasePage()
        {
            InitializeComponent();

            List<Employee> employees = App.DB.Employees.ToList();
            foreach (Employee employee in employees) 
            {
                EmployeeCB.Items.Add($"{employee.Surname.Trim()} {employee.FirstName.Trim()} {employee.MiddleName.Trim()}");
            }
            EmployeeCB.SelectedIndex = 0;

            SaleDateTB.Text = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).ToString();
            SalePriceTB.Text = App.DB.Cars.FirstOrDefault(x => x.Id == App.currentPurchase.Car).Price.ToString();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            App.currentPurchase = null;
            NavigatePage("AdminPage");
        }

        private async void SetSaleBTN_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SaleDateTB.Text) || string.IsNullOrEmpty(SalePriceTB.Text) || string.IsNullOrEmpty(CommissionTB.Text)
                || EmployeeCB.SelectedItem == null) 
            {
                MessageBox.Show("Нужно заполнить все поля");
                return;
            }

            PurchaseRequisition request = App.currentPurchase;
            Employee employee = null;
            foreach (var item in App.DB.Employees.ToList())
            {
                if ($"{item.Surname.Trim()} {item.FirstName.Trim()} {item.MiddleName.Trim()}" == EmployeeCB.SelectedItem.ToString())
                {
                    employee = item;
                    break;
                }
            }

            if (employee == null)
            {
                MessageBox.Show("Такого сотрудника нет");
                return;
            }

            DateOnly date;
            try
            {
                date = DateOnly.Parse(SaleDateTB.Text);
            }

            catch (Exception)
            {
                MessageBox.Show("Указан неверный формат даты");
                return;
            }

            int price;
            try
            {
                price = Convert.ToInt32(SalePriceTB.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Цена должна быть указана числом");
                return;
            }

            int commission;
            try
            {
                commission = Convert.ToInt32(CommissionTB.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Комиссия должна быть указана числом");
                return;
            }

            string method = PaymentMethodCB.Text;

            await DBAccess.DBAccess.SetPurchase(request, employee, date, price, commission, method);
            MessageBox.Show("Заявка успешно оформлена");
            NavigatePage("AdminPage");
        }

        private void NavigatePage(string page)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.MainFrame.Navigate(new Uri($"Pages/{page}.xaml", UriKind.Relative));
        }
    }
}
