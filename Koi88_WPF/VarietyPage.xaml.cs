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
using Koi88_Repository;
using Koi88_Service;

namespace Koi88_WPF
{
    /// <summary>
    /// Interaction logic for VarietyPage.xaml
    /// </summary>
    public partial class VarietyPage : Page
    {
        private IVarietyService _varietyService;
        public VarietyPage()
        {
            InitializeComponent();
            _varietyService = new VarietyService();
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var image = sender as Image;
            var textBlock = sender as TextBlock;
            if (image != null)
            {
                int varietyId = (int)image.Tag;
                NavigationService.Navigate(new VarietyDetail(varietyId));
            }
            if(textBlock != null)
            {
                int varietyId = (int)textBlock.Tag;
                NavigationService.Navigate(new VarietyDetail(varietyId));
            }
        }

        private void VarietyPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            DataGridVariety.ItemsSource = _varietyService.GetVarieties();
        }

        private void ButtonDetail_OnClick(object sender, RoutedEventArgs e)
        {
            var image = sender as Image;
            if (image != null)
            {
                int varietyId = (int)image.Tag;
                NavigationService.Navigate(new VarietyDetail(varietyId));
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
