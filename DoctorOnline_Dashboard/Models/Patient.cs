using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorOnline_Dashboard.Models
{
    public class Patient
    {
        [Key]
        public int patientId { get; set; }
        [Required]
        public string patientName { get; set; }
        [Required]
        public string patientPassword { get; set; }
        [Required]
        public string patientGsm { get; set; }
        [Required]
        public int patientAge { get; set; }
        [Required]
        public string patientGender { get; set; }
        public string patientCity { get; set; }
        [Required]
        public string verificationCode { get; set; }
        [Required]
        public int isActive { get; set; }
    }
}
