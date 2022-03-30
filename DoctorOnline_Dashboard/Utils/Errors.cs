using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorOnline_Dashboard.Utils
{
    public enum Errors
    {
        Success = 0,
        Patient_Exsit_And_Activated = 1,//sign Up
        Patient_Exsit_But_Not_Active = 3, //login
        Verification_Code_Is_Wrong = 4,//verify
        Wrong_GSM_or_Password = 5,//login
        Patient_Not_Exsit = 6 ,//forget password
        No_Availble_Doctors_To_Handle_The_Order = 7,
        Doctor_Not_Exsit = 8,
        GeneralError = 2
    }
}
