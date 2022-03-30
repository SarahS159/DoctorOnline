using DoctorOnline_Dashboard.Areas;
using DoctorOnline_Dashboard.Areas.DoctorsManagement;
using DoctorOnline_Dashboard.ModelDto;
using DoctorOnline_Dashboard.Models;
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
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorsManagement _doctorManagement;
        public DoctorController(IDoctorsManagement doctorManagement)
        {
            _doctorManagement = doctorManagement;
        }

        [HttpGet]
        [Route("getAvailbleDoctors")]
        public IQueryable<Doctor> GetAvailbleDoctors()
        {
            return _doctorManagement.GetAvailbleDoctors();
        }

        [HttpPost]
        [Route("doctorLogIn")]
        public IResponse DoctorLogIn(DoctorDto doctorDto)
        {
            return _doctorManagement.DoctorLogIn(doctorDto);
        }

        [HttpGet]
        [Route("changeDoctorStatus")]
        public IResponse ChangeDoctorStatus(int doctorId, string doctorStatus)
        {
            return _doctorManagement.ChangeDoctorStatus(doctorId, doctorStatus);
        }
       
    }
}
