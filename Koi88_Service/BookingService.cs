using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi88_BusinessObject;
using Koi88_Repository;

namespace Koi88_Service
{
    public class BookingService: IBookingService
    {
        private IBookingRepository _bookingRepository;
        public BookingService()
        {
            _bookingRepository = new BookingRepository();
        }
        public bool CreateBooking(Booking booking)
        {
            return _bookingRepository.CreateBooking(booking);
        }

        public List<Booking> GetBookingsByAccountId(int accountId)
        {
            return _bookingRepository.GetBookingsByAccountId(accountId);
        }


        public bool CancelBooking(int bookingId)
        {
            return _bookingRepository.CancelBooking(bookingId);
        }

        public Booking GetBookingById(int bookingId)
        {
            return _bookingRepository.GetBookingById(bookingId);
        }

        public bool EditBooking(Booking booking)
        {
            return _bookingRepository.EditBooking(booking);
        }

        public List<Booking> GetDeliveredBookingsByAccountId(int accountId)
        {
            return _bookingRepository.GetDeliveredBookingsByAccountId(accountId);
        }

        public List<Booking> GetDepositAndDeliveredBookingsByAccountId()
        {
            return _bookingRepository.GetDepositAndDeliveredBookingsByAccountId();
        }

        public List<Booking> GetCurrentBookingsByAccountId(int accountId)
        {
            return _bookingRepository.GetCurrentBookingsByAccountId(accountId);
        }

        public List<Booking> GetBookingsByStatus(string status)
        {
            return _bookingRepository.GetBookingsByStatus(status);
        }
    }
}
