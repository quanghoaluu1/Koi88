using Koi88_Service;
using System.Windows;
using System.Windows.Controls;

namespace Koi88_WPF
{
    public partial class BookingDetailsPage : Page
    {
        private int _bookingId;
        private readonly IOrderManagementService _orderManagementService;

        public BookingDetailsPage(int bookingId, IOrderManagementService orderManagementService)
        {
            InitializeComponent();
            _bookingId = bookingId;
            _orderManagementService = orderManagementService;
            LoadBookingDetails();
        }
            
        private void LoadBookingDetails()
        {
            var booking = _orderManagementService.GetBookingById(_bookingId);

            if (booking != null)
            {
                // Populate the fields with booking details
                TextBlockBookingId.Text = booking.BookingId.ToString();
                TextBlockFullName.Text = booking.Fullname;
                TextBlockPhone.Text = booking.Phone;
                TextBlockEmail.Text = booking.Email;
                TextBlockStatus.Text = booking.Status;
                TextBlockQuotedAmount.Text = booking.QuotedAmount?.ToString("C"); 
                TextBlockStartDate.Text = booking.StartDate?.ToString("d"); 
                TextBlockEndDate.Text = booking.EndDate?.ToString("d"); 
                TextBlockConsultantName.Text = booking.Consultant?.Username ?? "N/A"; 
                TextBlockNotes.Text = booking.Note; 
            }
            else
            {
                MessageBox.Show("Booking not found.");
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}