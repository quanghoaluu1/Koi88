using Koi88_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi88_Service
{
    public interface IBookingService
    {
        bool CreateBooking(Booking booking);
        List<Booking> GetBookingsByAccountId(int accountId);

        List<Booking> GetBookingsNeedConsultant();

        public bool CheckinBooking(int bookingId, int consultantId);

        public List<Booking> GetBookingsByConsultantId(int accountId);

        bool CancelBooking(int bookingId);

        Booking GetBookingById(int bookingId);

        bool EditBooking(Booking booking);

        List<Booking> GetDeliveredBookingsByAccountId(int accountId);

        List<Booking> GetDepositAndDeliveredBookingsByAccountId();

        List<Booking> GetCurrentBookingsByAccountId(int accountId);

        List<Booking> GetBookingsByStatus(string status);

    }
}
