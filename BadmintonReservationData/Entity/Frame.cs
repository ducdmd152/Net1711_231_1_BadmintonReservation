using BadmintonReservationData.Entity;
using System;
using System.Collections.Generic;

namespace BadmintonReservationData
{
    public partial class Frame : BaseEntity
    {
        public Frame()
        {
        }

        public int Id { get; set; }
        public int TimeFrom { get; set; }
        public int TimeTo { get; set; }
        public int Status { get; set; }
        public double Price { get; set; }
        public int CourtId { get; set; }

        public virtual Court Court { get; set; } = null!;
    }
}
