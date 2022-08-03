using Hospital.Core.Utilities.Results;
using Hospital.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Business.Abstract
{
    public interface INurseService
    {
        IDataResult<List<Nurse>> GetAll();
        IDataResult<Nurse> GetByNurse(int id);
        IResult Add(Nurse nurse);
        IResult Update(Nurse nurse);
        IResult Delete(Nurse nurse);
    }
}
