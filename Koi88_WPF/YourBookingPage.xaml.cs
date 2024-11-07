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
            NavigationService.GoBack();
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
            var booking = e.Row.Item as Booking;
            if(booking == null) return;

            var cancelButton = FindVisualChild<Button>(e.Row, "ButtonCancel");
            var payButton = FindVisualChild<Button>(e.Row, "ButtonPay");
            var detailButton = FindVisualChild<Button>(e.Row, "ButtonDetail");

            // Xử lý hiển thị nút "Cancel"
            if (booking.Status != "Canceled" && booking.Status != "Confirmed" &&
                booking.Status != "Checked in" && booking.Status != "Checked out" &&
                booking.Status != "Delivering" && booking.Status != "Delivered")
            {
                cancelButton.Visibility = Visibility.Visible;
            }

            // Xử lý hiển thị nút "Pay"
            if (booking.Status == "Accepted" || booking.Status == "Confirmed" ||
                booking.Status == "Checked in" || booking.Status == "Checked out" ||
                booking.Status == "Delivering" || booking.Status == "Delivered")
            {
                payButton.Visibility = Visibility.Visible;
            }

            // Xử lý hiển thị nút "Detail"
            if (booking.Status == "Confirmed" || booking.Status == "Checked in" ||
                booking.Status == "Checked out" || booking.Status == "Delivering" ||
                booking.Status == "Delivered")
            {
                detailButton.Visibility = Visibility.Visible;
            }
        }

        private T FindVisualChild<T>(DependencyObject parent, string name) where T : FrameworkElement
        {
            if (parent == null) return null;
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is T frameworkElement && frameworkElement.Name == name)
                {
                    return frameworkElement;
                }
                var result = FindVisualChild<T>(child, name);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                int bookingId = (int)button.Tag;
                _bookingRepository.CancelBooking(bookingId);
                DataGridYourBooking.ItemsSource = _bookingRepository.GetBookingsByAccountId(_accountId);
            }
            var result = MessageBox.Show("Are you sure you want to cancel this booking?", "Cancel Booking", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
               
            }
        }

        private bool isRestrictedStatus(string status)
        {
            return status != "Cancelled"
                || status != "Confirmed"
                || status != "Checked in"
                || status != "Checked out"
                || status != "Delivering"
                || status != "Delivered";
        }

        private void ButtonPay_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButtonDetail_OnClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
