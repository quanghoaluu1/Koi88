using Koi88_Service;
using Microsoft.Identity.Client;
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

namespace Koi88_WPF
{
    /// <summary>
    /// Interaction logic for PoDetailPage.xaml
    /// </summary>
    public partial class PoDetailPage : Page
    {
        private int poId;
        private IPodetailsService podetailsService;
        public PoDetailPage(int poId)
        {
            InitializeComponent();
            podetailsService = new PodetailsService();
            this.poId = poId;
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void dtgFishList_Loaded(object sender, RoutedEventArgs e)
        {
            dtgFishList.ItemsSource = podetailsService.GetPodetailsByPoId(poId);
        }

        private void btnAddFish_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddFishPage(poId));
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                int poDetailId = (int)button.Tag;

                MessageBoxResult messageBoxResult = MessageBox.Show("Do you really want to remove this type of fish?", "Remove fish confirm", MessageBoxButton.YesNo);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    podetailsService.RemoveDodetail(poDetailId);
                    MessageBox.Show("Remove successfully!");
                    dtgFishList.ItemsSource = podetailsService.GetPodetailsByPoId(poId);
                }

            }
        }
    }
}
