using Hospital.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Entities.Dtos
{
    public class NurseAddDto : IDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        //set other properties
        public string Gender = "Veri Yok";
        public string Region = "Veri Yok";
        public string Description = "Veri Yok";
    }
}
