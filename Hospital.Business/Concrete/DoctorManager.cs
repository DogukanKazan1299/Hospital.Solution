using Hospital.Business.Abstract;
using Hospital.Business.Constants;
using Hospital.Core.Utilities.Business;
using Hospital.Core.Utilities.Results;
using Hospital.DataAccess.Abstract;
using Hospital.Entities.Concrete;
using Hospital.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hospital.Business.Concrete
{
    public class DoctorManager : IDoctorService
    {
        private readonly IDoctorDal _doctorDal;
        public DoctorManager(IDoctorDal doctorDal)
        {
            _doctorDal=doctorDal;
        }
        public IResult Add(Doctor doctor)
        {
            IResult result = BusinessRules.Run(CheckTelNR(doctor.TelNR));
            if (result != null)
            {
                return result;
            }
            _doctorDal.Add(doctor);
            return new SuccessResult(Messages.AddDoctor);
        }

        public IResult AddDoctorDto(DoctorAddDto doctorAddDto)
        {
            _doctorDal.Add(new Doctor { 
                Name=doctorAddDto.Name,
                Surname=doctorAddDto.Surname,
                Region=doctorAddDto.Region,
                Salary=doctorAddDto.Salary
            });
            return new SuccessResult(Messages.AddDoctorDto);
        }

        public IResult Delete(Doctor doctor)
        {
            _doctorDal.Delete(doctor);
            return new SuccessResult(Messages.DeleteDoctor);
        }

        public IDataResult<List<Doctor>> GetAll()
        {
            return new SuccessDataResult<List<Doctor>>(_doctorDal.GetList().ToList());
        }

        public IDataResult<Doctor> GetByDoctor(int id)
        {
            return new SuccessDataResult<Doctor>(_doctorDal.GetById(x => x.Id == id));
        }

        public IResult Update(Doctor doctor)
        {
            _doctorDal.Update(doctor);
            return new SuccessResult(Messages.UpdatedDoctor);
        }


        private IResult CheckTelNR(string TelNR)
        {
            Regex regex = new Regex(@"^05");
            Match match = regex.Match(TelNR);
            if (!match.Success)
            {
                return new ErrorResult(Messages.TelNRError);
            }
            return new SuccessResult();
        }
    }
}
