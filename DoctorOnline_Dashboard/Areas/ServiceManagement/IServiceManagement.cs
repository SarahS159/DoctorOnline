using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorOnline_Dashboard.Areas.ServiceManagement
{
    public interface IServiceManagement
    {
        public IResponse GetSpecialityServices(int specialityId);
    }
}
