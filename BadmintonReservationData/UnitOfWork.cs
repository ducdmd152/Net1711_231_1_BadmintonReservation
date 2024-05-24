using BadmintonReservationData.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonReservationData
{
    public class UnitOfWork
    {
        private NET1711_231_1_BadmintonReservationContext _context;
        private BookingRepository _bookingRepository;
        private BookingDetailRepository _bookingDetailRepository;

        public UnitOfWork()
        {

        }

        public BookingRepository BookingRepository
        {
            get
            {
                return _bookingRepository ??= new BookingRepository();
            }
        }

        public BookingDetailRepository BookingDetailRepository
        {
            get
            {
                return _bookingDetailRepository ??= new BookingDetailRepository();
            }
        }
    }
}
