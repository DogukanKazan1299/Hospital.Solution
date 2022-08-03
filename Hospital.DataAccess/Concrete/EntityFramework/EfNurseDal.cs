using Hospital.Core.DataAccess.EntityFramework;
using Hospital.DataAccess.Abstract;
using Hospital.DataAccess.Concrete.Contexts;
using Hospital.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DataAccess.Concrete.EntityFramework
{
    public class EfNurseDal : EfEntityRepositoryBase<Nurse,HospitalContext> , INurseDal
    {
    }
}
