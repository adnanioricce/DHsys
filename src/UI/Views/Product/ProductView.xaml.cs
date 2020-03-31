using System;
using System.Windows;
using System.Windows.Controls;

namespace UI.Views.Product
{
    /// <summary>
    /// Interação lógica para ProductListView.xam
    /// </summary>
    public partial class ProductView : Page
    {
        public ProductView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Source = new Uri("AddProductView.xaml");
        }
    }
}
