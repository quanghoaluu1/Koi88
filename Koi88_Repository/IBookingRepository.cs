using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koi88_BusinessObject;

namespace Koi88_Repository
{
    public interface IBookingRepository
    {
        bool CreateBooking(Booking booking);
        List<Booking> GetBookingsByAccountId(int accountId);
        bool CancelBooking(int bookingId);
    }
}
