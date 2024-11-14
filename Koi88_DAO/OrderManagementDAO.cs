using Koi88_BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi88_DAO
{
    public class OrderManagementDAO
    {
        private static OrderManagementDAO instance;
        private static Koi88Context _dbContext;

        private OrderManagementDAO()
        {

        }
        public static OrderManagementDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderManagementDAO();
                    _dbContext = new Koi88Context();
                }

                return instance;
            }

        }

        public Booking GetBookingById(int bookingId)
        {
            return _dbContext.Bookings
                .Include(b => b.Trip)
                .FirstOrDefault(b => b.BookingId == bookingId);
        }

        public List<Booking> GetBooking()
        {
            return _dbContext.Bookings
                .Include(b => b.Trip) // Include the Trip data
                .ToList();
        }

        public List<Booking> GetBookingWithConsultants()
        {
            return _dbContext.Bookings.Include(b => b.Consultant).ToList(); // Ensure you include the Consultant
        }

        public bool UpdateBooking(Booking booking)
        {
            try
            {
                // Assuming _dbContext is your database context
                _dbContext.Bookings.Update(booking);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log the error)
                return false;
            }
        }

    }
}
