using BadmintonReservationData.Entity;
using System;
using System.Collections.Generic;

namespace BadmintonReservationData
{
    public partial class Frame : BaseEntity
    {
        public Frame()
        {
            CustomFrames = new HashSet<CustomFrame>();
        }

        public int Id { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public int Status { get; set; }
        public double Price { get; set; }
        public int CourtId { get; set; }

        public virtual Court Court { get; set; } = null!;
        public virtual ICollection<CustomFrame> CustomFrames { get; set; }
    }
}
