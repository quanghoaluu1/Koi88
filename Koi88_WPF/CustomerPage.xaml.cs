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
    /// Interaction logic for CustomerPage.xaml
    /// </summary>
    public partial class CustomerPage : Page
    {
        private int _accountId;
        public CustomerPage(int accountId)
        {
            InitializeComponent();
            this._accountId = accountId;
        }

        private void ButtonNewBooking_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewBookingPage(_accountId));
        }

        private void ButtonYourBooking_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new YourBookingPage(_accountId));
        }

        private void ButtonBookingHistory_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BookingHistoryPage(_accountId));
        }

        private void ButtonAbout_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AboutPage());
        }

        private void ButtonVariety_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new VarietyPage());
        }

        private void ButtonFarm_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FarmPage());
        }
    }
}
