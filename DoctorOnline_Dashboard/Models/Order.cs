using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DoctorOnline_Dashboard.Models
{
    //TODO:add error code and error description to be used as log
    public class Order
    {
        [Key]
        public int orderId { get; set; }

        public double orderCost { get; set; }

        [Required]
        [ForeignKey("Patient")]
        public int patientId { get; set; }

       // [ForeignKey("doctor")]
        public int doctorId { get; set; }

        [Required]
        public DateTime requestedDate { get; set; }

        [Required]
        public DateTime changeStatusDate { get; set; }

        [Required]
        public string orderStatus { get; set; }
            
        [Required]
        public int specialityId { get; set; }
        public string specialityTitle { get; set; }
        public string doctorName { get; set; }

        [IgnoreDataMember]
        public virtual Patient Patient { get; set; }

        //[IgnoreDataMember]
        //public virtual Doctor doctor { get; set; }
    }
}
