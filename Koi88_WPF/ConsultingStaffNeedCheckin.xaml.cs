using Koi88_BusinessObject;
using Koi88_DAO;
using Koi88_Repository;
using Koi88_Service;
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
    /// Interaction logic for ConsultingStaffNeedCheckin.xaml
    /// </summary>
    public partial class ConsultingStaffNeedCheckin : Page
    {
        private int _accountId;
        private IBookingService bookingService;

        public ConsultingStaffNeedCheckin(int accountId)
        {
            InitializeComponent();
            this._accountId = accountId;
            bookingService = new BookingService();
        }

        private void dtgBookingsConsultant_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            //e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void dtgBookingsConsultant_Loaded(object sender, RoutedEventArgs e)
        {
            dtgBookingsConsultant.ItemsSource = bookingService.GetBookingsNeedConsultant();
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnCheckin_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                int bookingId = (int)button.Tag;

                MessageBoxResult messageBoxResult = MessageBox.Show("Do you really want to check in this booking?", "Booking check in", MessageBoxButton.YesNo);

                if (messageBoxResult == MessageBoxResult.Yes)
                {

                    if (bookingService.CheckinBooking(bookingId, _accountId)) {
                        MessageBox.Show("Checkin booking id " + bookingId + " successfully!");
                        dtgBookingsConsultant.ItemsSource = bookingService.GetBookingsNeedConsultant();
                    } else
                    {
                        MessageBox.Show("Something wrong!");
                    }
                     
                }
            }
        }
    }
}
