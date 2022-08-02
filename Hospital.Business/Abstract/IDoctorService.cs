using Hospital.Core.Utilities.Results;
using Hospital.Entities.Concrete;
using Hospital.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Business.Abstract
{
    public interface IDoctorService
    {
        IDataResult<List<Doctor>> GetAll();
        IDataResult<Doctor> GetByDoctor(int id);
        IResult Add(Doctor doctor);
        IResult Delete(Doctor doctor);
        IResult Update(Doctor doctor);

        IResult AddDoctorDto(DoctorAddDto doctorAddDto);
    }
}
