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
using Koi88_BusinessObject;
using Koi88_Service;

namespace Koi88_WPF
{
    /// <summary>
    /// Interaction logic for FarmPage.xaml
    /// </summary>
    public partial class FarmPage : Page
    {
        private IFarmService _farmService;
        private List<KoiFarm> koiFarms;
        private int currentIndex = 0;
        public FarmPage()
        {
            InitializeComponent();
            _farmService = new FarmService();
            koiFarms = _farmService.GetFarms();
            FarmListBox.ItemsSource = koiFarms;
            FarmListBox.SelectedIndex = currentIndex;
        }

        private BitmapImage converToBitmapImage(string url)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(url, UriKind.RelativeOrAbsolute);
            bitmap.EndInit();
            return bitmap;
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                FarmListBox.SelectedIndex = currentIndex;
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentIndex < koiFarms.Count - 1)
            {
                currentIndex++;
                FarmListBox.SelectedIndex = currentIndex;
            }
        }
    }
}
