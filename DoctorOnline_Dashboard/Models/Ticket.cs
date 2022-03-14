using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DoctorOnline_Dashboard.Models
{
    public class Ticket
    {
        [Key]
        public int ticketId { get; set; }   
        [Required]
        public string ticketDescription { get; set; }
        [Required]
        [ForeignKey("Patient")]
        public int patientId { get; set; }

        [IgnoreDataMember]
        public virtual Patient patient { get; set; }
    }
}
