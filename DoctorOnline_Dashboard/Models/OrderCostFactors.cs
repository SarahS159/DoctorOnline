using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorOnline_Dashboard.Models
{
    public class OrderCostFactors
    {
        [Key]
        public int id { get; set; }
        public double actual_KMs_in_1LT { get; set; }
        public double fuel_Price_Of_1lt { get; set; }
        public double uncertanityFactor { get; set; }
        public bool oneWayDirection { get; set; }

    }
}
