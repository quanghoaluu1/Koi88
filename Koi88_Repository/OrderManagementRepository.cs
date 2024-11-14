using Koi88_BusinessObject;
using Koi88_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi88_Repository
{
    public class OrderManagementRepository : IOrderManagementRepository
    {
        private OrderManagementDAO orderManagementDAO;

        public OrderManagementRepository()
        {
            orderManagementDAO = OrderManagementDAO.Instance;
        }

        public Booking GetBookingById(int bookingId)
        {
            return orderManagementDAO.GetBookingById(bookingId);
        }

        public List<Booking> GetBooking()
        {
            return orderManagementDAO.GetBooking();
        }

        public bool UpdateBooking(Booking booking)
        {
            return orderManagementDAO.UpdateBooking(booking);
        }

        public List<Booking> GetBookingWithConsultants()
        {
            return orderManagementDAO.GetBookingWithConsultants();
        }
    }
}
