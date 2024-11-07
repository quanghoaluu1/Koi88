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
        private BookingDAO _bookingDAO = new BookingDAO();
        public bool CreateBooking(Booking booking)
        {
            return _bookingDAO.Instance.CreateBooking(booking);
        }

        public List<Booking> GetBookingsByAccountId(int accountId)
        {
            return _bookingDAO.Instance.GetBookingsByAccountId(accountId);
        }

        public bool CancelBooking(int bookingId)
        {
            return _bookingDAO.Instance.CancelBooking(bookingId);
        }
    }
}
