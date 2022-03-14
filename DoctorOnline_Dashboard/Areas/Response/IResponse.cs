using DoctorOnline_Dashboard.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorOnline_Dashboard.Areas
{
    public interface IResponse
    {
        public int errorCode { get; set; }
        public string errorDescription { get; set; }
        public IList data { get; set; }
    }
}
