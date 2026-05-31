using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainReservationEntities.Models
{
    public class Cancellation
    {
        public int CId { get; set; }

        public int BookingId { get; set; }

        public int NoTickets { get; set; }

        public decimal RefundAmt { get; set; }
    }
}