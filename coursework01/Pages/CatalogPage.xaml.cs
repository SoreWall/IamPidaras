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

            Car car = App.DB.Cars.FirstOrDefault(x=>x.Id == 33);
            SetCarBlock(car);
        }

        private void SetCarBlock(Car car)
        {
            StackPanel stackPanel = new();

            System.Windows.Controls.Image image = new();
            image.Width = 172;
            image.Height = 195;
            image.Source = new BitmapImage(new Uri($"/cars/{car.Image}", UriKind.Relative));
            image.HorizontalAlignment = HorizontalAlignment.Left;
            stackPanel.Children.Add(image);

            TextBlock textBlock = new();
            textBlock.Text = $"{car.Manufacturer.Trim()} {car.Model.Trim()}";
            stackPanel.Children.Add(textBlock);

            grid.Children.Add(stackPanel);
        }
    }
}
