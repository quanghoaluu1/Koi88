using Koi88_BusinessObject;
using Koi88_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi88_Service
{
    public class OrderManagementService : IOrderManagementService
    {
        private IOrderManagementRepository _orderManagementRepository;

        public OrderManagementService()
        {
            _orderManagementRepository = new OrderManagementRepository();
        }

        public Booking GetBookingById(int bookingId)
        {
            return _orderManagementRepository.GetBookingById(bookingId);
        }

        public List<Booking> GetBooking()
        {
            return _orderManagementRepository.GetBooking();
        }

        public bool UpdateBooking(Booking booking)
        {
            return _orderManagementRepository.UpdateBooking(booking);
        }

        public List<Booking> GetBookingWithConsultants()
        {
            return _orderManagementRepository.GetBookingWithConsultants();
        }
    }
}
