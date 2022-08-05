using Hospital.Business.Abstract;
using Hospital.Business.Constants;
using Hospital.Business.ValidationRules.FluentValidation;
using Hospital.Core.Aspects.Autofac.Validation;
using Hospital.Core.Utilities.Business;
using Hospital.Core.Utilities.Results;
using Hospital.DataAccess.Abstract;
using Hospital.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hospital.Business.Concrete
{
    public class PatientManager : IPatientService
    {
        private readonly IPatientDal _patientDal;
        public PatientManager(IPatientDal patientDal)
        {
            _patientDal = patientDal;
        }
        [ValidationAspect(typeof(PatientValidator))]
        public IResult Add(Patient patient)
        {
            IResult result = BusinessRules.Run(CheckTCKN(patient.TCKN),RegexTCKN(patient.TCKN));
            if(result != null)
            {
                return result;
            }
            _patientDal.Add(patient);
            return new SuccessResult(Messages.AddNewPatient);
        }

        public IResult Delete(Patient patient)
        {
            _patientDal.Delete(patient);
            return new SuccessResult(Messages.DeletePatient);
        }

        public IDataResult<List<Patient>> GetAll()
        {
            return new SuccessDataResult<List<Patient>>(_patientDal.GetList().ToList());
        }

        public IDataResult<Patient> GetByPatient(int id)
        {
            return new SuccessDataResult<Patient>(_patientDal.GetById(x => x.Id == id));
        }

        //TCKN getPatient
        public IDataResult<Patient> GetByTCKN(string TCKN)
        {
            return new SuccessDataResult<Patient>(_patientDal.GetById(x => x.TCKN == TCKN));
        }

        public IResult Update(Patient patient)
        {
            _patientDal.Update(patient);
            return new SuccessResult(Messages.UpdatePatient);
        }


        //Aynı TCKN 'ye sahip 2 kişi olamaz.
        private IResult CheckTCKN(string TCKN)
        {
            var result = _patientDal.GetList(x => x.TCKN == TCKN).Any();
            if (result)
            {
                return new ErrorResult(Messages.TCKNIsAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult RegexTCKN(string TCKN)
        {
            Regex regex = new Regex(@"^\d+$");

            Match match = regex.Match(TCKN);
            if (!match.Success)
            {
                return new ErrorResult(Messages.TCKNError);
            }
            return new SuccessResult();
        }

        
    }


}
