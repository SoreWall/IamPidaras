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

            List<Car> car = App.DB.Cars.Select(x=>x).ToList();
            DisplayCars(car);
        }

        private void DisplayCars(List<Car> cars)
        {
            int i = 0;
            StackPanel stackPanel = new();
            stackPanel.Orientation = Orientation.Horizontal;

            foreach (var car in cars)
            {
                if (i == 4)
                {
                    mainStackPanel.Children.Add(stackPanel);
                    stackPanel = new();
                    stackPanel.Orientation = Orientation.Horizontal;
                    i = 0;
                }

                stackPanel.Children.Add(SetCarBlock(car));
                i++;
            }

            if (stackPanel.Children.Count > 0)
            {
                mainStackPanel.Children.Add(stackPanel);
            }
        }

        private Grid SetCarBlock(Car car)
        {
            Grid grid = new();
            grid.Background = new SolidColorBrush(Colors.Red);
            grid.Width = 199;
            grid.Height = 202;
            grid.Margin = new Thickness(10, 10, 0, 0);
            grid.MouseLeftButtonDown += (s, e) => OpenCarInfoPage(car);

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

        private void OpenCarInfoPage(Car car)
        {
            MessageBox.Show($"This is {car.Manufacturer.Trim()} {car.Model.Trim()}");
        }
    }
}
