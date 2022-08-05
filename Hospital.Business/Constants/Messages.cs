using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Business.Constants
{
    public static  class Messages
    {
        public static string AddDoctor = "added new doctor";
        public static string DeleteDoctor = "deleted doctor";
        public static string UpdatedDoctor = "update by doctor";
        public static string AddDoctorDto = "doctor dto added";

        public static string AddNurse = "added new nurse";
        public static string DeleteNurse = "deleted nurse";
        public static string UpdatedNurse = "update by nurse";
        public static string AddNurseDto = "nurse dto is added!";
        public static string ErrorNurseListDto = "nurse list dto is failed";

        public static string AddNewPatient = "new patient added";
        public static string DeletePatient = "deleted patient";
        public static string UpdatePatient = "updated by patient";

        public static string TCKNIsAlreadyExists = "This TCKN is already exists";
    }
}
