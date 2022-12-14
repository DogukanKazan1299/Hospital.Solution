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
    public class NurseManager : INurseService
    {
        private readonly INurseDal _nurseDal;
        public NurseManager(INurseDal nurseDal)
        {
            _nurseDal= nurseDal;
        }
        public IResult Add(Nurse nurse)
        {
            IResult result = BusinessRules.Run(CheckTelNR(nurse.TelNR));
            if (result != null)
            {
                return result;
            }
            _nurseDal.Add(nurse);
            return new SuccessResult(Messages.AddNurse);
        }

        public IResult AddNurseDto(NurseAddDto nurseAddDto)
        {
            _nurseDal.Add(new Nurse
            {
                Name = nurseAddDto.Name,
                Surname = nurseAddDto.Surname,
                Region=nurseAddDto.Region,
                Gender=nurseAddDto.Gender,
                Description=nurseAddDto.Description
            });
            return new SuccessResult(Messages.AddNurseDto);
        }

        public IResult Delete(Nurse nurse)
        {
            _nurseDal.Delete(nurse);
            return new SuccessResult(Messages.DeleteNurse);
        }

        public IDataResult<List<Nurse>> GetAll()
        {
            return new SuccessDataResult<List<Nurse>>(_nurseDal.GetList().ToList());
        }

        public IDataResult<Nurse> GetByNurse(int id)
        {
            return new SuccessDataResult<Nurse>(_nurseDal.GetById(x => x.Id == id));
        }

        public IDataResult<NurseListDto> GetNurseListDto()
        {
            var nurses = _nurseDal.GetList();
            if (nurses.Count > -1)
            {
                return new SuccessDataResult<NurseListDto>(new NurseListDto
                {
                    Nurses = nurses
                });
            }
            return new ErrorDataResult<NurseListDto>(Messages.ErrorNurseListDto);
        }

        public IResult Update(Nurse nurse)
        {
            _nurseDal.Update(nurse);
            return new SuccessResult(Messages.UpdatedNurse);
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
