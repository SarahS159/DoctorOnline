 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorOnline_Dashboard.ModelDto
{
    public class OrderDto
    {   
        public int patientId { get; set; }
        public int specialityId { get; set; }
        public int orderCost { get; set; }
        public string patientCity { get; set; }
        public int doctorId { get; set; }
        public string orderStatus { get; set; }
        public int orderId { get; set; }
    }
}
