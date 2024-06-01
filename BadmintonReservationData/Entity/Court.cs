using BadmintonReservationData.Entity;
using System;
using System.Collections.Generic;

namespace BadmintonReservationData
{
    public partial class Court : BaseEntity
    {
        public Court()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Status { get; set; }
    }
}
