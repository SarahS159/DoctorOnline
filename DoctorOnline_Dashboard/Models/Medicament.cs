using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorOnline_Dashboard.Models
{
    public class Medicament
    {
        [Key]
        public int medicamentId { get; set; }

        [Required]
        public string medicamentName { get; set; }

        [Required]
        public int medicamentCount { get; set; }

        [Required]
        public string medicamentSchedule { get; set; }

        public int medicamentCost { get; set; }
      //  public int prId { get; set; }
    }
}
