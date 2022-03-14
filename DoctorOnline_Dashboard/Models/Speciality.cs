using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorOnline_Dashboard.Models
{
    public class Speciality
    {
        [Key]
        public int specialityId { get; set; }

        [Required]
        public string specialityTitle { get; set; }
        [Required]  
        public double specialityCost { get; set; }
        [Required]
        public string spacialityImageTitle { get; set; }
        public string specialityDescription { get; set; }   
    }
}
