using Hospital.Core.Utilities.Results;
using Hospital.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Business.Abstract
{
    public interface IPatientService
    {
        IDataResult<List<Patient>> GetAll();
        IDataResult<Patient> GetByPatient(int id);
        IResult Add(Patient patient);
        IResult Update(Patient patient);
        IResult Delete(Patient patient);
        IDataResult<Patient> GetByTCKN(string TCKN);
    }
}
