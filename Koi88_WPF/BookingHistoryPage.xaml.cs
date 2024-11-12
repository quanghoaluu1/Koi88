using Koi88_Repository;
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
    /// Interaction logic for BookingHistoryPage.xaml
    /// </summary>
    public partial class BookingHistoryPage : Page
    {
        private int _accountId;
        private IBookingRepository _bookingRepository;
        public BookingHistoryPage(int accountId)
        {
            InitializeComponent();
            this._accountId = accountId;
            _bookingRepository = new BookingRepository();
        }

        private void DataGridYourBooking_OnLoadingRow(object? sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();

        }

        private void ButtonDetail_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void BookingHistoryPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            DataGridBookingHistory.ItemsSource = _bookingRepository.GetDeliveredBookingsByAccountId(_accountId);
            int count = 1;
            count++;
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
