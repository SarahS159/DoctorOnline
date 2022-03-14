using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DoctorOnline_Dashboard.Models
{
    public class Doctor
    {
        [Key]
        public int doctorId { get; set; }
        [Required]
        public string doctorName { get; set; }
        [Required]
        public string doctorPassword { get; set; }
        [Required]
        public string doctorGsm { get; set; }
        [Required]
        public string doctorSpeciality { get; set; }
        [Required]
        public string doctorCity { get; set; }
        [Required]
        public string doctorAddress { get; set; }
        //[Required]
        //public string doctorSchedule { get; set; }
      //  [Required]
        public string doctorStatus { get; set; }    

        [Required]
        [ForeignKey("Speciality")]
        public int specialityId { get; set; }

        [IgnoreDataMember]
        public virtual Speciality speciality { get; set; }
    }
}
