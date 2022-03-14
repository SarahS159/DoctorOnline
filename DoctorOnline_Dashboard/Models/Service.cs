using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorOnline_Dashboard.Models
{
    public class Service
    {
        [Key]
        public int serviceId { get; set; }

        [Required]
        public string serviceDescription { get; set; }
    }
}
