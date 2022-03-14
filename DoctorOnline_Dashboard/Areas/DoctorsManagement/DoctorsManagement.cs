using DoctorOnline_Dashboard.ModelDto;
using DoctorOnline_Dashboard.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorOnline_Dashboard.Areas.DoctorsManagement
{
    public class DoctorsManagement : IDoctorsManagement
    {
        private readonly DoctorOnlineContext _doctorOnlineContext;
        //  private readonly IResponse _response;
        static public Random rnd = new Random();
        public DoctorsManagement(DoctorOnlineContext doctorOnlineContext, IResponse response)
        {
            _doctorOnlineContext = doctorOnlineContext;
          //  _response = response;
        }

        //TODO:handle Exceptions in this class
        public IQueryable<Doctor> GetFreeDoctorsBySpeciality(int specialityId)
        {
            var doctors = _doctorOnlineContext.Doctors.Where(d => (d.doctorStatus != "1") && (d.specialityId == specialityId));//1=doctor is busy
            return doctors;
        }

        public IQueryable<int> GeDoctorsByShedule()
        {
            DateTime sysDate = DateTime.Now;
            var doctorIds = _doctorOnlineContext.Schedules.Where(s => (sysDate >= s.startDate) && (sysDate > s.endDate))
                                                         .Select(d => d.doctorId);

            return doctorIds;
        }

        public DoctorDto GetDoctorToHandleRequest(int specialityId, string city)
        {
            DoctorDto doctorToHanleOrder = null;
            Doctor chosenDoctor = null;
            try
            {
                List<DoctorDto> doctorsDtoList = new List<DoctorDto>();
                DateTime sysDate  = DateTime.Now;

                var doctors = _doctorOnlineContext.Doctors.Join(
                     _doctorOnlineContext.Schedules,
                     doctor => doctor.doctorId,
                     schedule => schedule.doctorId,
                     (doctor, schedule) => new
                     {
                         doctorId = doctor.doctorId,
                         doctorName = doctor.doctorName,
                         doctorGsm = doctor.doctorGsm,
                         specialityId = doctor.specialityId,
                         doctorCity = doctor.doctorCity,
                         doctorAddress = doctor.doctorAddress,
                         doctorStatus = doctor.doctorStatus,
                         scheduleStartDate = schedule.startDate,
                         scheduleEndDate = schedule.endDate
                     }).Where(d=> (d.specialityId == specialityId)
                           && (d.doctorStatus == null)
                           && (d.doctorCity == city)
                           && (sysDate > d.scheduleStartDate)
                           && (sysDate < d.scheduleEndDate)
                           ).Select(d => new
                           {
                               doctorId = d.doctorId,
                               doctorName = d.doctorName,
                               doctorGsm = d.doctorGsm,
                               doctorCity = d.doctorCity,
                               doctorAddress = d.doctorAddress,
                               doctorStatus = d.doctorStatus
                           }).ToList();

                if (doctors.Count != 0 )
                {
                    foreach (var doctor in doctors)
                    {
                        DoctorDto doctorDto = new DoctorDto(doctor.doctorId, doctor.doctorName, doctor.doctorGsm, doctor.doctorCity, doctor.doctorAddress);
                        doctorsDtoList.Add(doctorDto);
                    }
                    if(doctorsDtoList.Count == 1)
                       doctorToHanleOrder = doctorsDtoList[0];
                    
                    if (doctorsDtoList.Count > 1)
                    {
                        int doctorIndex = rnd.Next(doctorsDtoList.Count);//TODO:cahnge this Random chosen to better way
                        doctorToHanleOrder = doctorsDtoList[doctorIndex];
                    }
                    while (chosenDoctor == null)
                    {
                         chosenDoctor = _doctorOnlineContext.Doctors.SingleOrDefault(d => d.doctorId == doctorToHanleOrder.doctorId && d.doctorStatus == null);
                        if (chosenDoctor != null)
                        {
                            chosenDoctor.doctorStatus = "2"; //2=requested
                            _doctorOnlineContext.SaveChanges();
                            break;
                        }
                        else
                        {
                            if (doctorsDtoList.Count > 1)
                            {
                                int doctorIndex = rnd.Next(doctorsDtoList.Count);
                                doctorToHanleOrder = doctorsDtoList[doctorIndex];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                doctorToHanleOrder.doctorId = -1;
                Console.WriteLine(ex.StackTrace);
            }

            return doctorToHanleOrder;
        }

        //public Doctor GetDoctorToHandleOrder(int specialityId)
        //{
        //    Doctor doctorToHandleTheRequest = null;
        //    List<Doctor> availbleDoctors = new List<Doctor>();

        //    List<Doctor> doctors = GetFreeDoctorsBySpeciality(specialityId).ToList();
        //    List<int> doctorIds = GeDoctorsByShedule().ToList();

        //    if (doctors.Count != 0 && doctorIds.Count != 0)
        //    {
        //        foreach (var doctor in doctors)
        //        {
        //            if (doctorIds.Contains(doctor.doctorId))
        //            {
        //                availbleDoctors.Add(doctor);
        //            }
        //        }
        //        if (availbleDoctors.Count == 1)
        //            doctorToHandleTheRequest = availbleDoctors[0];

        //        if (availbleDoctors.Count > 1)
        //        {
        //            //Random rnd = new Random();
        //            int doctorIndex = rnd.Next(availbleDoctors.Count);
        //            doctorToHandleTheRequest = availbleDoctors[doctorIndex];
        //        }
        //    }

        //    return doctorToHandleTheRequest;
        //}


    }

}
