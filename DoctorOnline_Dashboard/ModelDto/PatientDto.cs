using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorOnline_Dashboard.ModelDto
{
    public class PatientDto
    {
        public int patientId { get; set;  }
        public string patientName { get; set; }
        public string patientPassword { get; set; }
        public string patientGsm { get; set; }
        public int patientAge { get; set; }
        public string patientGender { get; set; }
        public string patientCity { get; set; }
        public char userType { get; set; }
        public string verificationCode { get; set; }//used for testing purpose, only to send the verification code in the response.
    }
}
