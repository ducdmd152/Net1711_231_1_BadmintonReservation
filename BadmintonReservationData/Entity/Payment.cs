using BadmintonReservationData.Entity;
using System;
using System.Collections.Generic;

namespace BadmintonReservationData
{
    public partial class Payment : BaseEntity
    {
        public Payment()
        {
            Bookings = new HashSet<Booking>();
            PurchasedHoursMonthlies = new HashSet<PurchasedHoursMonthly>();
        }

        public int Id { get; set; }
        public double Amount { get; set; }
        public int Status { get; set; }
        public int? ThirdPartyPaymentId { get; set; }
        public int? ThirdPartyResponse { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<PurchasedHoursMonthly> PurchasedHoursMonthlies { get; set; }
    }
}
