using AutoMapper;
using DoctorOnline_Dashboard.ModelDto;
using DoctorOnline_Dashboard.Models;
using DoctorOnline_Dashboard.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorOnline_Dashboard.Areas.UserManagement
{
    public class PatientManagement : IPatientManagement
    {
        private readonly DoctorOnlineContext _doctorOnlineContext;
        private readonly IMapper _mapper;
        private readonly IResponse _response;
        public PatientManagement(DoctorOnlineContext doctorOnlineContext, IResponse response, IMapper mapper)
        {
            _doctorOnlineContext = doctorOnlineContext;
            _mapper = mapper;
            _response = response;
        }
        public IResponse PatientSignUp(PatientDto patientDto)
        {
            try
            {
                List<PatientDto> patientAsList = new List<PatientDto>();//used for testing purpose, only to send the verification code in the response.
                //check if the GSM is alrady exsit in the database
                var patientInDataBase = _doctorOnlineContext.Patients.SingleOrDefault(p => p.patientGsm == patientDto.patientGsm);
                if (patientInDataBase is null)
                {
                    Random random = new Random();
                    string verificationcode = (random.Next(1000, 9999)).ToString();
                    var patient = _mapper.Map<Patient>(patientDto);
                    patient.verificationCode = verificationcode;
                    patient.isActive = 0;
                    _doctorOnlineContext.Patients.Add(patient);
                    _doctorOnlineContext.SaveChanges();

                    var responsePatient = new PatientDto();//used for testing purpose, only to send the verification code in the response.
                    responsePatient.verificationCode = verificationcode;
                    patientAsList.Add(responsePatient);
                    _response.errorCode = (int)Errors.Success;
                    _response.errorDescription = (Errors.Success).ToString();
                    _response.data = patientAsList;

                }
                else
                {
                    //if the GSM already exsit in database and active
                    if (patientInDataBase.isActive == 1)
                    {
                        _response.errorCode = (int)Errors.Patient_Exsit_And_Activated;
                        _response.errorDescription = (Errors.Patient_Exsit_And_Activated).ToString();
                    }
                    else
                    {
                        _response.errorCode = (int)Errors.Patient_Exsit_But_Not_Active;
                        _response.errorDescription = (Errors.Patient_Exsit_But_Not_Active).ToString();
                    }
                }
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

        public IResponse PatientVerify(PatientDto patientDto)
        {
            try
            {
                var patientInDataBase = _doctorOnlineContext.Patients.SingleOrDefault(p => (p.patientGsm == patientDto.patientGsm)
                                                                                        && (p.verificationCode == patientDto.verificationCode)
                                                                                        && (p.isActive == 0));
                if (patientInDataBase != null)
                {
                    patientInDataBase.isActive = 1;
                    _doctorOnlineContext.SaveChanges();
                    _response.errorCode = (int)Errors.Success;
                    _response.errorDescription = (Errors.Success).ToString();
                }
                else
                {
                    _response.errorCode = (int)Errors.Verification_Code_Is_Wrong;
                    _response.errorDescription = (Errors.Verification_Code_Is_Wrong).ToString();
                }
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

        //TODO: in this api we should return the patient id to front end .
        public IResponse PatientLogIn(PatientDto patientDto)
        {
            List<PatientDto> patientAsList = new List<PatientDto>();
            try
            {
                var patientInDatabase = _doctorOnlineContext.Patients.SingleOrDefault(p => (p.patientGsm == patientDto.patientGsm)
                                                                                        && (p.patientPassword == patientDto.patientPassword));
                if (patientInDatabase is null)
                {
                    _response.errorCode = (int)Errors.Wrong_GSM_or_Password;
                    _response.errorDescription = (Errors.Wrong_GSM_or_Password).ToString();
                }
                else
                {
                    //if the patient not active
                    if (patientInDatabase.isActive == 0)
                    {
                        var responsePatient = new PatientDto();
                        responsePatient.patientId = patientInDatabase.patientId;
                        responsePatient.userType = 'P';
                        patientAsList.Add(responsePatient);
                        _response.errorCode = (int)Errors.Patient_Exsit_But_Not_Active;
                        _response.errorDescription = (Errors.Patient_Exsit_But_Not_Active).ToString();
                        _response.data = patientAsList;
                    }
                    else
                    {
                        var responsePatient = new PatientDto();
                        responsePatient.patientId = patientInDatabase.patientId;
                        responsePatient.userType = 'P';
                        patientAsList.Add(responsePatient);
                        _response.errorCode = (int)Errors.Success;
                        _response.errorDescription = (Errors.Success).ToString();
                        _response.data = patientAsList;
                    }
                }
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

        public IResponse ForgetPassword(PatientDto patientDto)
        {
            List<PatientDto> patientAsList = new List<PatientDto>();
            try
            {
                var patientInDataBase = _doctorOnlineContext.Patients.SingleOrDefault(p => p.patientGsm == patientDto.patientGsm);
                if (patientInDataBase != null)
                {
                    Random random = new Random();
                    string verificationcode = (random.Next(1000, 9999)).ToString();
                    patientInDataBase.verificationCode = verificationcode;
                    _doctorOnlineContext.SaveChanges();

                    var responsePatient = _mapper.Map<PatientDto>(patientInDataBase);
                    patientAsList.Add(responsePatient);
                    _response.errorCode = (int)Errors.Success;
                    _response.errorDescription = (Errors.Success).ToString();
                    _response.data = patientAsList;

                }
                else
                {
                    _response.errorCode = (int)Errors.Patient_Not_Exsit;
                    _response.errorDescription = (Errors.Patient_Not_Exsit).ToString();
                }
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

        public IResponse VerfiyForgetPassword(PatientDto patientDto)
        {
            try
            {
                var patientInDataBase = _doctorOnlineContext.Patients.
                                         SingleOrDefault(p => (p.patientGsm == patientDto.patientGsm)
                                                           && (p.verificationCode == patientDto.verificationCode));
                if (patientInDataBase != null)
                {
                    if (patientInDataBase.isActive == 0)
                        patientInDataBase.isActive = 1;
                    patientInDataBase.patientPassword = patientDto.patientPassword;
                    _doctorOnlineContext.SaveChanges();
                    _response.errorCode = (int)Errors.Success;
                    _response.errorDescription = (Errors.Success).ToString();
                }
                else
                {
                    _response.errorCode = (int)Errors.Verification_Code_Is_Wrong;
                    _response.errorDescription = (Errors.Verification_Code_Is_Wrong).ToString();
                }
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

        public IResponse ResetPassword(PatientResetPasswordDto patientResetPasswordDto)
        {
            try
            {
                var patientInDataBase = _doctorOnlineContext.Patients.SingleOrDefault(p => (p.patientGsm == patientResetPasswordDto.patientGsm)
                                                                                       // && (p.verificationCode == patientResetPasswordDto.verificationCode)
                                                                                        &&(p.patientPassword == patientResetPasswordDto.oldPassword));
                if (patientInDataBase != null)
                {
                    if (patientInDataBase.isActive == 0)
                    {
                        _response.errorCode = (int)Errors.Patient_Exsit_But_Not_Active;
                        _response.errorDescription = (Errors.Patient_Exsit_But_Not_Active).ToString();
                    }
                    else
                    {
                        patientInDataBase.patientPassword = patientResetPasswordDto.newPassword;
                        _doctorOnlineContext.SaveChanges();

                        _response.errorCode = (int)Errors.Success;
                        _response.errorDescription = (Errors.Success).ToString();
                    }
                }
                else
                {
                    _response.errorCode = (int)Errors.Patient_Not_Exsit;
                    _response.errorDescription = (Errors.Patient_Not_Exsit).ToString();
                }
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

        public IResponse RequestVerify(PatientDto patientDto)
        {
            try
            {
                List<PatientDto> patientAsList = new List<PatientDto>();
                var patientInDataBase = _doctorOnlineContext.Patients.SingleOrDefault(p => p.patientGsm == patientDto.patientGsm);
                if (patientInDataBase != null)
                {
                    Random random = new Random();
                    string verificationcode = (random.Next(1000, 9999)).ToString();
                    patientInDataBase.verificationCode = verificationcode;
                    _doctorOnlineContext.SaveChanges();

                    var responsePatient = _mapper.Map<PatientDto>(patientInDataBase);
                    patientAsList.Add(responsePatient);
                    _response.errorCode = (int)Errors.Success;
                    _response.errorDescription = (Errors.Success).ToString();
                    _response.data = patientAsList;
                }
                else
                {
                    _response.errorCode = (int)Errors.Patient_Not_Exsit;
                    _response.errorDescription = (Errors.Patient_Not_Exsit).ToString();
                }
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
