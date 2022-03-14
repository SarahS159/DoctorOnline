using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorOnline_Dashboard.ModelDto
{
    public class SpecialityServiceDto
    {
        public int serviceId { get; set; }  
        public int specialityId { get; set; }
        public string serviceDescription { get; set; }
    }
}
