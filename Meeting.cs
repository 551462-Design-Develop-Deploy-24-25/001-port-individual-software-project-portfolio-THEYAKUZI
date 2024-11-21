using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace softwareproject
{
    public class Meeting
    {
        public Student Student { get; set; }
        public PersonalSupervisor Supervisor { get; set; }
        public DateTime Date { get; set; }
    }

}
