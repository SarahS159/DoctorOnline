using DoctorOnline_Dashboard.Areas;
using DoctorOnline_Dashboard.Areas.SpecialityManagement;
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
    public class SpecialityController : ControllerBase
    {
        private ISpecialityManagement _specialityManagement;
        public SpecialityController(ISpecialityManagement specialityManagement)
        {
            _specialityManagement = specialityManagement;
        }

        [HttpGet]
        [Route("getAllSpecialities")]
        public IResponse GetAllSpecialties()
        {
            return _specialityManagement.GetAllSpacialities();
        }
    }
}
