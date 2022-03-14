using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorOnline_Dashboard.ModelDto
{
    public class PatientResetPasswordDto
    {
        public string patientGsm { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
        public string verificationCode { get; set; }

    }
}
