using Hospital.Core.DataAccess;
using Hospital.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DataAccess.Abstract
{
    public interface INurseDal : IEntityRepository<Nurse>
    {
    }
}
