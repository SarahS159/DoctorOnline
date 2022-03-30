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
        public IResponse DoctorLogIn(DoctorDto doctorDto);
        public IQueryable<Doctor> GetFreeDoctorsBySpeciality(int specialityId);
        public IQueryable<int> GeDoctorsByShedule();
        public IQueryable<Doctor> GetAvailbleDoctors();
        public DoctorDto GetDoctorToHandleRequest(int specialityId, string city);
        public IResponse ChangeDoctorStatus(int doctorId, string doctorStatus);
    }
}
