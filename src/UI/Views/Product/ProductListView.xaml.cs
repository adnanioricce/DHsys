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
using UI.ViewModels.Product;

namespace UI.Views.Product
{
    /// <summary>
    /// Interação lógica para ProductListView.xam
    /// </summary>
    public partial class ProductListView : Page
    {
        public ProductListView(ProductListViewModel viewModel)
        {
            DataContext = viewModel;            
            InitializeComponent();
        }
    }
}
