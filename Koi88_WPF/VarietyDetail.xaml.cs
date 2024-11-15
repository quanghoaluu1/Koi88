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
    /// Interaction logic for VarietyDetail.xaml
    /// </summary>
    public partial class VarietyDetail : Page
    {
        private int _varietyId;
        private VarietyService _varietyService;
        public VarietyDetail(int varietyId)
        {
            InitializeComponent();
            _varietyService = new VarietyService();
            _varietyId = varietyId;
        }


        private void VarietyDetail_OnLoaded(object sender, RoutedEventArgs e)
        {
           Variety variety = _varietyService.GetById(_varietyId);
           LabelTitle.Content = variety.VarietyName ;
           TextBlockDescription.Text = variety.Description;
           ImageTitle.Source = converToBitmapImage(variety.ImageUrl);
           LabelType.Content = "Types of " + variety.VarietyName;
           switch (_varietyId)
           {
                case 3:
                    ImageAsagi.Visibility = Visibility.Visible;
                    break;
                case 4:
                    ImageKohaku.Visibility = Visibility.Visible;
                    break;
                case 5:
                    ImageTancho.Visibility = Visibility.Visible;
                    break;
           }

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
    }
}
