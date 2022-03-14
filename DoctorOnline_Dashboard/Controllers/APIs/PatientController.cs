using DoctorOnline_Dashboard.Areas;
using DoctorOnline_Dashboard.Areas.UserManagement;
using DoctorOnline_Dashboard.ModelDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorOnline_Dashboard.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IPatientManagement _patientManagement;

        // Assign the object in the constructor for dependency injection
        public PatientController(IPatientManagement patientManagement)
        {
            _patientManagement = patientManagement;
        }

        [HttpPost]
        [Route("patientSignUp")]
        public IResponse PatientSignUp(PatientDto patientDto)
        {
            return _patientManagement.PatientSignUp(patientDto);
        }

        [HttpPost]
        [Route("patientVerify")]
        public IResponse PatientVerify(PatientDto patientDto)
        {
            return _patientManagement.PatientVerify(patientDto);
        }

        [HttpPost]
        [Route("patientLogIn")]
        public IResponse PatientLogIn(PatientDto patientDto)
        {
            return _patientManagement.PatientLogIn(patientDto);
        }

        [HttpPost]
        [Route("forgetPassword")]
        public IResponse ForgetPassword(PatientDto patientDto)
        {
            return _patientManagement.ForgetPassword(patientDto);
        }

        [HttpPost]
        [Route("verifyForgetPassword")]
        public IResponse VerifyForgetPassword(PatientDto patientDto)
        {
            return _patientManagement.VerfiyForgetPassword(patientDto);
        }

        [HttpPost]
        [Route("resetPassword")]
        public IResponse ResetPassword(PatientResetPasswordDto patientResetPasswordDto)
        {
            return _patientManagement.ResetPassword(patientResetPasswordDto);
        }

        [HttpPost]
        [Route("requestVerify")]
        public IResponse RequestVerify(PatientDto patientDto)
        {
            return _patientManagement.RequestVerify(patientDto);
        }
    }
}
