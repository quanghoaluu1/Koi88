﻿using Koi88_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi88_DAO
{
    public class BookingDAO
    {
        private Koi88Context _dbContext;
        private BookingDAO instance;
        public BookingDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BookingDAO();
                return instance;
            }
        }
        public BookingDAO()
        {
            _dbContext = new Koi88Context();
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
    }
}