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
using static System.Net.Mime.MediaTypeNames;

namespace coursework01.Pages
{
    /// <summary>
    /// Логика взаимодействия для CatalogPage.xaml
    /// </summary>
    public partial class CatalogPage : Page
    {

        public CatalogPage()
        {
            InitializeComponent();

            SearchTBox.Text = App.SearchFilter;
            MinCostTBox.Text = App.MinCostFilter.ToString();
            MaxCostTBox.Text = App.MaxCostFilter.ToString();
            if (App.MarkFilter != "Все")
            {
                foreach (var item in MarkCB.Items) 
                {
                    if (item.ToString().Contains(App.MarkFilter))
                    {
                        MarkCB.SelectedItem = item;
                        break;
                    }
                }
            }
                FilterCars();
        }

        private void FilterCars()
        {
            List<Car> cars = App._cars;

            cars = cars.Where(x => x.Model.Trim().ToLower().Contains(App.SearchFilter.ToLower())).ToList();

            if (MarkCB.SelectedIndex != 0)
            {
                cars = cars.Where(x => x.Manufacturer.Trim() == App.MarkFilter).ToList();
            }

            if (App.MinCostFilter > 0 || App.MaxCostFilter > 0)
            {
                if (App.MaxCostFilter == 0)
                {
                    App.MaxCostFilter = App.DB.Cars.Max(x => x.Price);
                }

                cars = cars.Where(x => x.Price <= App.MaxCostFilter && x.Price >= App.MinCostFilter).ToList();
            }

            DisplayCars(cars);
        }

        private void DisplayCars(List<Car> cars)
        {
            carsStackPanel.Children.Clear();

            int i = 0;
            StackPanel stackPanel = new();
            stackPanel.Orientation = Orientation.Horizontal;

            foreach (var car in cars)
            {
                if (i == 4)
                {
                    carsStackPanel.Children.Add(stackPanel);
                    stackPanel = new();
                    stackPanel.Orientation = Orientation.Horizontal;
                    i = 0;
                }

                stackPanel.Children.Add(SetCarBlock(car));
                i++;
            }

            if (stackPanel.Children.Count > 0)
            {
                carsStackPanel.Children.Add(stackPanel);
            }
        }

        private Grid SetCarBlock(Car car)
        {
            Grid grid = new();
            grid.Background = new SolidColorBrush(Colors.Red);
            grid.Width = 199;
            grid.Height = 202;
            grid.Margin = new Thickness(10, 10, 0, 0);
            grid.MouseLeftButtonDown += (s, e) => OpenCarPage(car);

            StackPanel stackPanel = new();

            System.Windows.Controls.Image image = new();
            image.Width = 172;
            image.Height = 129;
            image.Source = new BitmapImage(new Uri($"/cars/{car.Image}", UriKind.Relative));
            image.Stretch = Stretch.UniformToFill;
            image.Margin = new Thickness(13, 10, 0, 0);
            image.HorizontalAlignment = HorizontalAlignment.Left;

            TextBlock nameTextBlock = new();
            nameTextBlock.Text = $"{car.Manufacturer.Trim()} {car.Model.Trim()}";
            nameTextBlock.FontSize = 15;
            nameTextBlock.HorizontalAlignment = HorizontalAlignment.Center;

            TextBlock yearTextBlock = new();
            yearTextBlock.Text = car.Year.ToString();
            yearTextBlock.FontSize = 15;
            yearTextBlock.HorizontalAlignment = HorizontalAlignment.Center;

            TextBlock priceTextBlock = new();
            priceTextBlock.Text = car.Price.ToString() + " ₽";
            priceTextBlock.FontSize = 15;
            priceTextBlock.HorizontalAlignment = HorizontalAlignment.Center;

            stackPanel.Children.Add(image);
            stackPanel.Children.Add(nameTextBlock);
            stackPanel.Children.Add(yearTextBlock);
            stackPanel.Children.Add(priceTextBlock);
            grid.Children.Add(stackPanel);

            return grid;
        }

        private void OpenCarPage(Car car)
        {
            App.CurrentCar = car;

            NavigatePage("CarPage");
        }

        private void MinCostTBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(MinCostTBox.Text))
            {
                if (App.MaxCostFilter == App.DB.Cars.Max(x=>x.Price))
                {
                    App.MaxCostFilter = 0;
                }

                App.MinCostFilter = 0;
            }

            else
            {
                App.MinCostFilter = Convert.ToInt32(MinCostTBox.Text);
            }

                FilterCars();
        }

        private void MaxCostTBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(MaxCostTBox.Text))
            {
                App.MaxCostFilter = 0;
            }

            else
            {
                App.MaxCostFilter = Convert.ToInt32(MaxCostTBox.Text);
            }

            FilterCars();
        }

        private void MarkCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                App.MarkFilter = MarkCB.Text;
                FilterCars();
            }));

            
        }

        private void SearchTBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            App.SearchFilter = SearchTBox.Text;
            FilterCars();
        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigatePage("ProfilePage");
        }

        private void NavigatePage(string page)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.MainFrame.Navigate(new Uri($"Pages/{page}.xaml", UriKind.Relative));
        }
    }
}
