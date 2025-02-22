﻿using System;
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

        List<Booking> GetBookingsNeedConsultant();

        public bool CheckinBooking(int bookingId, int consultantId);

        public List<Booking> GetBookingsByConsultantId(int accountId);

        bool CancelBooking(int bookingId);

        List<Booking> GetDeliveredBookingsByAccountId(int accountId);
        Booking GetBookingById(int bookingId);

        List<Booking> GetDepositAndDeliveredBookingsByAccountId();

        List<Booking> GetCurrentBookingsByAccountId(int accountId);

        bool EditBooking(Booking booking);

        List<Booking> GetBookingsByStatus(string status);
    }
}
