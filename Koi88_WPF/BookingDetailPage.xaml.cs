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
    /// Interaction logic for BookingDetailPage.xaml
    /// </summary>
    public partial class BookingDetailPage : Page
    {
        private int _bookingId;
        private IBookingService _bookingService;
        public BookingDetailPage(int bookingId)
        {
            InitializeComponent();
            _bookingService = new BookingService();
            _bookingId = bookingId;
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }


        private void BookingDetailPage_OnLoaded(object sender, RoutedEventArgs e)
        {
           Booking booking = _bookingService.GetBookingById(_bookingId);
           TextBoxName.Text = booking.Fullname;
           TextBoxEmail.Text = booking.Email;
           TextBoxPhone.Text = booking.Phone;
           DatePickerStart.Text = booking.StartDate.ToString();
           DatePickerEnd.Text = booking.EndDate.ToString();
           TextBoxFarm.Text = booking.Favoritefarm;
           TextBoxKoi.Text = booking.FavoriteKoi;
           TextBoxNote.Text = booking.Note;
           TextBoxCost.Text = booking.EstimatedCost.ToString();
           TextBoxHotel.Text = booking.HotelAccommodation;
           TextBoxBookingDate.Text = booking.BookingDate.ToString();
           TextBoxStatus.Text = booking.Status;
           if (booking.QuotedAmount == null)
           {
               TextBoxQuoteAmount.Text = "0";
           }
           else
           {
               TextBoxQuoteAmount.Text = booking.QuotedAmount.ToString();
           }

           if (booking.QuoteSentDate == null)
           {
                TextBoxQuoteSent.Text = "Not sent";
           }
           else
           {
                TextBoxQuoteSent.Text = booking.QuoteSentDate.ToString();
           }

           if (booking.QuoteApprovedDate == null)
           {
               TextBoxQuoteApproved.Text = "Not approved";
           }
           else
           {
               TextBoxQuoteApproved.Text = booking.QuoteApprovedDate.ToString();
           }

           disableAllFields();

           if (!canCancelStatus(booking.Status))
           {
                ButtonCancel.IsEnabled = false;
           }

           if (!canEditStatus(booking.Status))
           {
                ButtonEdit.IsEnabled = false;
           }

           if (!canPayStatus(booking.Status))
           {
                ButtonPay.IsEnabled = false;
           }


        }

        private bool canCancelStatus(string status)
        {
            return status != "Canceled" && status != "Confirmed" && status != "Checked in" && status != "Checked out" &&
                   status != "Delivering" && status != "Delivered";
        }

        private void disableAllFields()
        {
            TextBoxName.IsReadOnly = true;
            TextBoxEmail.IsReadOnly = true;
            TextBoxPhone.IsReadOnly = true;
            DatePickerStart.IsEnabled = false;
            DatePickerEnd.IsEnabled = false;
            TextBoxFarm.IsReadOnly = true;
            TextBoxKoi.IsReadOnly = true;
            TextBoxNote.IsReadOnly = true;
            TextBoxCost.IsReadOnly = true;
            TextBoxHotel.IsReadOnly = true;
            TextBoxBookingDate.IsReadOnly = true;
            TextBoxStatus.IsReadOnly = true;
            TextBoxQuoteAmount.IsReadOnly = true;
            TextBoxQuoteSent.IsReadOnly = true;
            TextBoxQuoteApproved.IsReadOnly = true;
            TextBoxStatus.IsReadOnly = true;

        }

        private bool canEditStatus(string status)
        {
            return status != "Canceled" && status != "Confirmed" && status != "Checked in" && status != "Checked out" &&
                   status != "Delivering" && status != "Delivered";
        }

        private bool canPayStatus(string status)
        {
            return status == "Accepted" || status == "Confirmed" || status == "Checked in" ||
                status == "Checked out" || status == "Delivering" || status == "Delivered";
        }
    }
}
