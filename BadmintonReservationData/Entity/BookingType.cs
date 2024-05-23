using System;
using System.Collections.Generic;

namespace BadmintonReservationData
{
    public partial class BookingType
    {
        public BookingType()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public double PromotionAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
