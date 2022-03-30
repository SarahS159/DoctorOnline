using DoctorOnline_Dashboard.ModelDto;
using DoctorOnline_Dashboard.Models;
using DoctorOnline_Dashboard.Utils;
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
        private readonly IResponse _response;
        static public Random rnd = new Random();
        public DoctorsManagement(DoctorOnlineContext doctorOnlineContext, IResponse response)
        {
            _doctorOnlineContext = doctorOnlineContext;
            _response = response;
        }

        public IResponse DoctorLogIn(DoctorDto doctorDto)
        {
            try
            {
                var doctorInDataBase = _doctorOnlineContext.Doctors.SingleOrDefault(d => (d.doctorGsm == doctorDto.doctorGsm)
                                                                                      && (d.doctorPassword == doctorDto.doctorPassword));
                if (doctorInDataBase == null)
                {
                    _response.errorCode = (int)Errors.Wrong_GSM_or_Password;
                    _response.errorDescription = (Errors.Wrong_GSM_or_Password).ToString();
                }
                else
                {
                    List<DoctorDto> doctorAsList = new List<DoctorDto>();
                    DoctorDto doctor = new DoctorDto();
                    doctor.doctorId = doctorInDataBase.doctorId;
                    doctor.userType = 'D';
                    doctorAsList.Add(doctor);
                    _response.errorCode = (int)Errors.Success;
                    _response.errorDescription = (Errors.Success).ToString();
                    _response.data = doctorAsList;
                }
            }
            catch(Exception ex) {
                Console.WriteLine(ex.InnerException.Message);
                _response.errorCode = (int)Errors.GeneralError;
                _response.errorDescription = (Errors.GeneralError).ToString();
                var data = new List<String>();
                data.Add(ex.StackTrace);//recheck
                _response.data = data;
            }
            return _response;
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

        public IQueryable<Doctor> GetAvailbleDoctors()
        {
           return  _doctorOnlineContext.Doctors.Where(d => d.doctorStatus == null);
        }

        public IResponse ChangeDoctorStatus(int doctorId, string doctorStatus)
        {
            var doctorInDatabase = _doctorOnlineContext.Doctors.SingleOrDefault(d => d.doctorId == doctorId);

            if(doctorInDatabase != null)
            {
                doctorInDatabase.doctorStatus = doctorStatus;
                _doctorOnlineContext.SaveChanges();

                _response.errorCode = (int)Errors.Success;
                _response.errorDescription = (Errors.Success).ToString();

            }
            else
            {
                _response.errorCode = (int)Errors.Doctor_Not_Exsit;
                _response.errorDescription = (Errors.Doctor_Not_Exsit).ToString();
            }

            return _response;
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
