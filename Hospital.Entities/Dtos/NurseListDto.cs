using Hospital.Core.Entities;
using Hospital.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Entities.Dtos
{
    public class NurseListDto : IDto
    {
        public IList<Nurse> Nurses { get; set; }
    }
}
