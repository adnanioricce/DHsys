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

namespace UI.Views.Product
{
    /// <summary>
    /// Interação lógica para ProductCardControl.xam
    /// </summary>
    public partial class ProductCardControlView : UserControl
    {
        public ProductCardControlView()
        {
            InitializeComponent();
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("https://www.google.com/url?sa=i&url=https%3A%2F%2Fbrokerhunter.com.br%2Fplaceholder-png-3%2F&psig=AOvVaw3iAmSYF5lX9Hw9iXtzP4cC&ust=1585764499779000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCMC9y5-nxegCFQAAAAAdAAAAABAI");
            bitmap.EndInit();
            cardImage.Source = bitmap;
        }
    }
}
