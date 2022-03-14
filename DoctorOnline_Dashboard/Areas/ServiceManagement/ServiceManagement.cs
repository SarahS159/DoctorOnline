using AutoMapper;
using DoctorOnline_Dashboard.ModelDto;
using DoctorOnline_Dashboard.Models;
using DoctorOnline_Dashboard.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorOnline_Dashboard.Areas.ServiceManagement
{
    public class ServiceManagement : IServiceManagement
    {
        private readonly DoctorOnlineContext _doctorOnlineContext;
        private readonly IResponse _response;
        private IMapper _mapper;
        public ServiceManagement(DoctorOnlineContext doctorOnlineContext, IResponse response, IMapper mapper)
        {
            _doctorOnlineContext = doctorOnlineContext;
            _response = response;
            _mapper = mapper;
        }
        public IResponse GetSpecialityServices(int specialityId)
        {
            try
            {
                List<SpecialityServiceDto> specialityDetails = new List<SpecialityServiceDto>();

                var specialityServicesInDb = _doctorOnlineContext.Services.Join(
                                             _doctorOnlineContext.Specialities,
                                             service => service.serviceId,
                                             speciality => speciality.specialityId,
                                             (service, speciality) => new
                                             {
                                                 specialityId = speciality.specialityId,
                                                 serviceId = service.serviceId,
                                                 serviceDescription = service.serviceDescription
                                             });
                foreach (var specialityService in specialityServicesInDb)
                {
                    var specialityDetailsResponse = new SpecialityServiceDto();
                    specialityDetailsResponse.serviceId = specialityService.serviceId;
                    specialityDetailsResponse.serviceDescription = specialityService.serviceDescription;
                    specialityDetailsResponse.specialityId = specialityService.specialityId;

                    specialityDetails.Add(specialityDetailsResponse);
                }
                _response.errorCode = (int)Errors.Success;
                _response.errorDescription = (Errors.Success).ToString();
                _response.data = specialityDetails;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                _response.errorCode = (int)Errors.GeneralError;
                _response.errorDescription = (Errors.GeneralError).ToString();
                var data = new List<String>();
                data.Add(ex.StackTrace);//recheck
                _response.data = data;
            }

            return _response;
        }

    }
}
