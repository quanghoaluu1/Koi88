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
    /// Interaction logic for DeliveryStaffPage.xaml
    /// </summary>
    public partial class DeliveryStaffPage : Page
    {
        private int _accountId;
        private IBookingService _bookingService;

        public DeliveryStaffPage(int accountId)
        {
            InitializeComponent();
            _bookingService = new BookingService();
            this._accountId = accountId;
            DataGridBooking.ItemsSource = _bookingService.GetDepositAndDeliveredBookingsByAccountId();
            
            
        }

        private void ButtonDelivery_OnClick(object sender, RoutedEventArgs e)
        {
            

            
               
                if (sender is Button button)
                {
                    var bookingId = (int)button.Tag;
                    var booking = _bookingService.GetBookingById(bookingId);
                    if (booking.Status == "Deposited")
                    {
                        booking.Status = "Delivering";
                        button.Content = "Paid";
                    }
                    else if (booking.Status == "Delivering")
                    {
                        booking.Status = "Delivered";
                        button.Visibility = Visibility.Hidden;
                    }

                    _bookingService.EditBooking(booking);
                    DataGridBooking.ItemsSource = _bookingService.GetDepositAndDeliveredBookingsByAccountId();
                }
            

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = ComboBoxStatus.SelectedItem as ComboBoxItem;

            if (selectedItem != null)
            {
                // Get the selected status as a string
                string selectedStatus = selectedItem.Content.ToString();

                // Call your method to get bookings by status
                var bookings = _bookingService.GetBookingsByStatus(selectedStatus);

                // Update your DataGrid or any UI element with the retrieved bookings
                DataGridBooking.ItemsSource = bookings;
            }
        }
    }
}
