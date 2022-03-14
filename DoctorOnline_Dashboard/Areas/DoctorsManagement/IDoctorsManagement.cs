using DoctorOnline_Dashboard.ModelDto;
using DoctorOnline_Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorOnline_Dashboard.Areas.DoctorsManagement
{
   public interface IDoctorsManagement
    {
        public IQueryable<Doctor> GetFreeDoctorsBySpeciality(int specialityId);
        public IQueryable<int> GeDoctorsByShedule();
      //  public Doctor GetDoctorToHandleOrder(int specialityId);

        public DoctorDto GetDoctorToHandleRequest(int specialityId, string city); 
    }
}
