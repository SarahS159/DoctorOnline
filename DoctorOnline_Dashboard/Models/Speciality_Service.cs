using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorOnline_Dashboard.Models
{
    public class Speciality_Service
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("Speciality")]
        public int specialityId { get; set; }

        [ForeignKey("Service")]
        public int serviceId { get; set; }

        public virtual Speciality Speciality { get; set; }
        public virtual Service Service { get; set; }
    }
}
