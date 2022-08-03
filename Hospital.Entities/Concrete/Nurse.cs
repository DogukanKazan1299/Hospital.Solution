using Hospital.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Entities.Concrete
{
    public class Nurse : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Salary { get; set; }
        public string Gender { get; set; }
        public string Region { get; set; }
        public string Description { get; set; }

    }
}
