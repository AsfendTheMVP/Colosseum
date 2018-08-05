using System;
using System.Collections.Generic;
using System.Text;

namespace Colosseum.Models
{
    public class BookTicket
    {
        public string MovieName { get; set; }
        public string CustomerName { get; set; }
        public string BookingDate { get; set; }
        public string Qty { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string TotalPayment { get; set; }
    }
}
