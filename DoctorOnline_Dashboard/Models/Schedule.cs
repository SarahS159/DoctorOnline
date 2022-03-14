using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DoctorOnline_Dashboard.Models
{
    public class Schedule
    {
        [Key]
        public int scheduleId { get; set; }

        [ForeignKey("doctor")]
        public int doctorId { get; set; }

        [Required]
        public DateTime startDate { get; set; }
        [Required]
        public DateTime endDate { get; set; }
        [Required]
        public DateTime creationDate { get; set; }

        [IgnoreDataMember]
        public virtual Doctor doctor { get; set; }
    }
}
