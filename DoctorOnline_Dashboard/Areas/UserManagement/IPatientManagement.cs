using DoctorOnline_Dashboard.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorOnline_Dashboard.Areas.UserManagement
{
    public interface IPatientManagement
    {
        public IResponse PatientSignUp(PatientDto patientDto);
        public IResponse PatientVerify(PatientDto patientDto);
        public IResponse PatientLogIn (PatientDto patientDto);
        public IResponse ForgetPassword(PatientDto patientDto);
        public IResponse VerfiyForgetPassword(PatientDto patientDto);
        public IResponse ResetPassword(PatientResetPasswordDto patientResetPasswordDto);
        public IResponse RequestVerify(PatientDto patientDto);
    }
}
