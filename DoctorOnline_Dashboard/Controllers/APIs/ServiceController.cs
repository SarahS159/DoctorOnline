using DoctorOnline_Dashboard.Areas;
using DoctorOnline_Dashboard.Areas.ServiceManagement;
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
    public class ServiceController : ControllerBase
    {
        private readonly IServiceManagement _serviceManagement;
        public ServiceController(IServiceManagement serviceManagement)
        {
            _serviceManagement = serviceManagement;
        }

        [HttpGet]
        [Route("specialityDetails")]
        public IResponse GetSpecialityServices(int specialityId)
        {
            return _serviceManagement.GetSpecialityServices(specialityId);
        }
    }
}
