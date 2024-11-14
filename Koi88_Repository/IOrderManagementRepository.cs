using Koi88_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi88_Repository
{
    public interface IOrderManagementRepository
    {
        public Booking GetBookingById(int bookingId);
        public List<Booking> GetBooking();
        public bool UpdateBooking(Booking booking);
        public List<Booking> GetBookingWithConsultants();

    }
}
