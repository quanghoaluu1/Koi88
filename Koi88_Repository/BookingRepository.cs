using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi88_BusinessObject;
using Koi88_DAO;

namespace Koi88_Repository
{
    public class BookingRepository: IBookingRepository
    {
        private readonly BookingDAO _bookingDAO;

        public BookingRepository()
        {
            _bookingDAO = BookingDAO.Instance;
        }

        public bool CreateBooking(Booking booking)
        {
            return _bookingDAO.CreateBooking(booking);
        }

        public List<Booking> GetBookingsByAccountId(int accountId)
        {
            return _bookingDAO.GetBookingsByAccountId(accountId);
        }

        public bool CancelBooking(int bookingId)
        {
            return _bookingDAO.CancelBooking(bookingId);
        }

        public List<Booking> GetDeliveredBookingsByAccountId(int accountId)
        {
            return _bookingDAO.GetDeliveredBookingsByAccountId(accountId);
        }

        public List<Booking> GetDepositAndDeliveredBookingsByAccountId()
        {
            return _bookingDAO.GetDepositAndDeliveredBookings();
        }

        public List<Booking> GetCurrentBookingsByAccountId(int accountId)
        {
            return _bookingDAO.GetCurrentBookingByAccountId(accountId);
        }

        public Booking GetBookingById(int bookingId)
        {
            return _bookingDAO.GetBookingById(bookingId);
        }

        public bool EditBooking(Booking booking)
        {
            return _bookingDAO.EditBooking(booking);
        }

        public bool CheckinBooking(int bookingId, int consultantId)
        {
            return _bookingDAO.CheckinBooking(bookingId, consultantId);
        }

        public List<Booking> GetBookingsByConsultantId(int accountId)
        {
            return _bookingDAO.GetBookingsByConsultantId(accountId);
        }


        public List<Booking> GetBookingsNeedConsultant()
        {
            return _bookingDAO.GetBookingsNeedConsultant();
        }
    }
}
