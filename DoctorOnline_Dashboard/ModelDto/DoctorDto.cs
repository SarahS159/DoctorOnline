using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorOnline_Dashboard.ModelDto
{
    public class DoctorDto
    {
        public DoctorDto(int id, string name, string gsm, string city, string address)
        {
            doctorId = id;
            doctorName = name;
            doctorGsm = gsm;
            doctorCity = city;
            doctorAddress = address;
               
        }
        public int doctorId { get; set; }
        public string doctorName { get; set; }
        public string doctorGsm { get; set; }
        //public int specialityId { get; set; }
        public string doctorCity { get; set; }
        public string doctorAddress { get; set; }
        //public string doctorStatus { get; set; }
    }
}
