using AutoMapper;
using DoctorOnline_Dashboard.ModelDto;
using DoctorOnline_Dashboard.Models;
using DoctorOnline_Dashboard.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorOnline_Dashboard.Areas.SpecialityManagement
{
    public class SpecialityManagement : ISpecialityManagement
    {
        private readonly DoctorOnlineContext _doctorOnlineContext;
        private readonly IResponse _response;
        private readonly IMapper _mapper;
        public SpecialityManagement(DoctorOnlineContext doctorOnlineContext, IResponse response, IMapper mapper)
        {
            _doctorOnlineContext = doctorOnlineContext;
            _response = response;
            _mapper = mapper;
        }
        public IResponse GetAllSpacialities()
        {
            //TODO: this Api return image for each speciality.
            try
            {
                List<SpecialityDto> specialityAsList = new List<SpecialityDto>();
                var specialitiesInDataBase = _doctorOnlineContext.Specialities.ToList();
                foreach (var speciality in specialitiesInDataBase)
                {
                    var specialityDto = _mapper.Map<SpecialityDto>(speciality);
                    specialityAsList.Add(specialityDto);
                }
                _response.errorCode = (int)Errors.Success;
                _response.errorDescription = (Errors.Success).ToString();
                _response.data = specialityAsList;
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
