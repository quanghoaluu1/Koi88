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
using Koi88_Repository;

namespace Koi88_WPF
{
    /// <summary>
    /// Interaction logic for YourBooking.xaml
    /// </summary>
    public partial class YourBookingPage : Page
    {
        private int _accountId;
        private IBookingRepository _bookingRepository;
        public YourBookingPage(int accountId)
        {
            InitializeComponent();
            this._accountId = accountId;
            _bookingRepository = new BookingRepository();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CustomerPage(_accountId));
        }

        private void YourBookingPage_OnLoaded(object sender, RoutedEventArgs e)
        {

            DataGridYourBooking.ItemsSource = _bookingRepository.GetBookingsByAccountId(_accountId);
            int count = 1;
            count++;
        }

        private void DataGridYourBooking_OnLoadingRow(object? sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
            
        }


        private void ButtonDetail_OnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var bookingId = (int)button.Tag;
                Booking booking = _bookingRepository.GetBookingById(bookingId);
                if (booking.Status.Equals("Rejected"))
                {
                    NavigationService.Navigate(new NewBookingPage(booking, _accountId));
                }
                else
                {
                    NavigationService.Navigate(new BookingDetailPage(bookingId));
                }
                
            }

        }
    }
}
