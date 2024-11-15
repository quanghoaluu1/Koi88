using Koi88_BusinessObject;
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
    /// Interaction logic for ConsultantStaffOnCheckin.xaml
    /// </summary>
    public partial class ConsultantStaffOnCheckin : Page
    {
        private int _accountId;
        private IBookingService bookingService;

        public ConsultantStaffOnCheckin(int accountId)
        {
            InitializeComponent();
            this._accountId = accountId;
            bookingService = new BookingService();
        }

        private void dtgBookingsConsultant_Loaded(object sender, RoutedEventArgs e)
        {
            dtgBookingsConsultant.ItemsSource = bookingService.GetBookingsByConsultantId(_accountId);
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnDetail_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                int poId = (int)button.Tag;
                NavigationService.Navigate(new PoDetailPage(poId));

            }
        }

        private void btnDeposite_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                int bookingId = (int)button.Tag;
                MessageBoxResult messageBoxResult = MessageBox.Show("Do you sure that customer deposite?", "Deposite confirm", MessageBoxButton.YesNo);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    Booking booking = bookingService.GetBookingById(bookingId);
                    booking.Status = "Deposited";
                    if (bookingService.EditBooking(booking))
                    {
                        MessageBox.Show("Set deposited successfully!");
                        dtgBookingsConsultant.ItemsSource = bookingService.GetBookingsByConsultantId(_accountId);
                    }
                    else
                    {
                        MessageBox.Show("Some thing wrong!");

                    }
                }

                
            }
        }
    }
}
