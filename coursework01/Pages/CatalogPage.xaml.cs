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
using System.Windows.Media.Effects;
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
            grid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffff"));
            grid.Width = 220;
            grid.Height = 250;
            grid.Margin = new Thickness(15, 15, 0, 0);
            grid.MouseLeftButtonDown += (s, e) => OpenCarPage(car);

            grid.Cursor = Cursors.Hand;
            grid.MouseEnter += (s, e) =>
            {
                grid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f8fafc"));
                grid.Effect = new DropShadowEffect
                {
                    Color = Colors.LightGray,
                    Direction = 270,
                    ShadowDepth = 3,
                    Opacity = 0.3,
                    BlurRadius = 5
                };
            };

            grid.MouseLeave += (s, e) =>
            {
                grid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffff"));
                grid.Effect = null;
            };

            Border border = new Border();
            border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e2e8f0"));
            border.BorderThickness = new Thickness(1);
            border.CornerRadius = new CornerRadius(8);

            StackPanel stackPanel = new StackPanel();
            stackPanel.Margin = new Thickness(10);

            Border imageContainer = new Border();
            imageContainer.CornerRadius = new CornerRadius(6);
            imageContainer.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f1f5f9"));
            imageContainer.Width = 200;
            imageContainer.Height = 140;
            imageContainer.HorizontalAlignment = HorizontalAlignment.Center;
            imageContainer.Margin = new Thickness(0, 0, 0, 10);

            System.Windows.Controls.Image image = new System.Windows.Controls.Image();
            image.Width = 190;
            image.Height = 130;
            image.Source = new BitmapImage(new Uri($"/cars/{car.Image}", UriKind.Relative));
            image.Stretch = Stretch.UniformToFill;
            image.HorizontalAlignment = HorizontalAlignment.Center;
            image.VerticalAlignment = VerticalAlignment.Center;

            imageContainer.Child = image;

            TextBlock nameTextBlock = new TextBlock();
            nameTextBlock.Text = $"{car.Manufacturer.Trim()} {car.Model.Trim()}";
            nameTextBlock.FontSize = 16;
            nameTextBlock.FontWeight = FontWeights.SemiBold;
            nameTextBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1e293b"));
            nameTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            nameTextBlock.TextAlignment = TextAlignment.Center;
            nameTextBlock.Margin = new Thickness(0, 0, 0, 5);
            nameTextBlock.TextTrimming = TextTrimming.CharacterEllipsis;

            StackPanel yearPanel = new StackPanel();
            yearPanel.Orientation = Orientation.Horizontal;
            yearPanel.HorizontalAlignment = HorizontalAlignment.Center;
            yearPanel.Margin = new Thickness(0, 0, 0, 5);

            TextBlock yearLabel = new TextBlock();
            yearLabel.Text = "Год: ";
            yearLabel.FontSize = 13;
            yearLabel.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#64748b"));

            TextBlock yearTextBlock = new TextBlock();
            yearTextBlock.Text = car.Year.ToString();
            yearTextBlock.FontSize = 13;
            yearTextBlock.FontWeight = FontWeights.Medium;
            yearTextBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1e293b"));

            yearPanel.Children.Add(yearLabel);
            yearPanel.Children.Add(yearTextBlock);

            TextBlock priceTextBlock = new TextBlock();
            priceTextBlock.Text = car.Price.ToString("N0") + " ₽";
            priceTextBlock.FontSize = 18;
            priceTextBlock.FontWeight = FontWeights.Bold;
            priceTextBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1e40af"));
            priceTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            priceTextBlock.Margin = new Thickness(0, 5, 0, 0);

            stackPanel.Children.Add(imageContainer);
            stackPanel.Children.Add(nameTextBlock);
            stackPanel.Children.Add(yearPanel);
            stackPanel.Children.Add(priceTextBlock);

            border.Child = stackPanel;
            grid.Children.Add(border);

            return grid;
        }

        private void OpenCarPage(Car car)
        {
            App.CurrentCar = car;

            NavigatePage("CarPage");
        }

        private void MinCostTBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Convert.ToInt32(MinCostTBox.Text); 
            }

            catch (Exception)
            {
                MinCostTBox.Text = "";
            }

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
            try
            {
                Convert.ToInt32(MaxCostTBox.Text);
            }

            catch (Exception)
            {
                MaxCostTBox.Text = "";
            }

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
