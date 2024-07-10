using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonReservationData.DTO
{
    public class PurchasedFilterDTO
    {
        public string SearchText { get; set; }
        public double AmountHour { get; set; }
        public int Status { get; set; }
        public int PaymentId { get; set; }
    }
}
