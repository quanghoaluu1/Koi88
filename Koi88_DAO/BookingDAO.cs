using Koi88_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Koi88_DAO
{
    public class BookingDAO
    {
        private static Koi88Context _dbContext;
        private static BookingDAO instance;
        public static BookingDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    _dbContext = new Koi88Context();
                    instance = new BookingDAO();
                }
                    
                return instance;
            }
        }
        private BookingDAO()
        {
            
        }

        public bool CreateBooking(Booking booking)
        {
            try
            {
                _dbContext.Bookings.Add(booking);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Booking> GetBookingsByAccountId(int accountId)
        {
            return _dbContext.Bookings.Include(b => b.Trip).Where(b => b.Customer.AccountId == accountId).ToList();
        }

        public List<Booking> GetBookingsByConsultantId(int accountId)
        {
            return _dbContext.Bookings.Include(b => b.Trip).Where(b => b.Consultant.AccountId == accountId).ToList();
        }

        public List<Booking> GetBookingsNeedConsultant()
        {
            //return _dbContext.Bookings.Where(m => m.Status.Equals("Confirmed")).Include(b => b.Trip).Include(b => b.Customer).ThenInclude(c => c.Account).ToList();
            return _dbContext.Bookings.Where(m => m.Status.Equals("Confirmed")).Include(b => b.Trip).ToList();
        }

        public bool CancelBooking(int bookingId)
        {
            try
            {
                var booking = _dbContext.Bookings.SingleOrDefault(b => b.BookingId == bookingId);
                if (booking != null)
                {
                    booking.Status = "Cancelled";
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CheckinBooking(int bookingId, int consultantId)
        {
            try
            {
                var booking = _dbContext.Bookings.SingleOrDefault(b => b.BookingId == bookingId);
                if (booking != null)
                {
                    booking.ConsultantId = consultantId;
                    booking.Status = "Checkin";
                    booking.PoId = 30;
                    _dbContext.Update(booking);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Booking> GetDeliveredBookingsByAccountId(int accountId)
        {
            return _dbContext.Bookings.Include(b => b.Trip).Where(b => b.Status == "Delivered" || b.Status == "Canceled" && b.Customer.AccountId.Equals(accountId) ).ToList();
        }


        public Booking GetBookingById(int bookingId)
        {
            return _dbContext.Bookings.Include(b => b.Trip).SingleOrDefault(b => b.BookingId == bookingId);
        }

        public bool EditBooking(Booking editBooking)
        {
            try
            {
                if (editBooking != null)
                {
                   _dbContext.Bookings.Update(editBooking); 
                   _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
