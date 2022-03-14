using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DoctorOnline_Dashboard.Models
{
    public class Patient_Doctor
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("Patient")]
        public int patientId { get; set; }

        [ForeignKey("Doctor")]
        public int doctorId { get; set; }

        [IgnoreDataMember]
        public virtual Patient Patient { get; set; }

        [IgnoreDataMember]
        public virtual Doctor doctor { get; set; }
    }
}
