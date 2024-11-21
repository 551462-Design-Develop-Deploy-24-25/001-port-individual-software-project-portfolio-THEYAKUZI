using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace softwareproject
{
    public class SeniorTutor
    {
        public int TutorId { get; }
        public string Name { get; }

        public SeniorTutor(int id, string name) { TutorId = id; Name = name; }

        public void ViewAllStudentEngagement(List<PersonalSupervisor> supervisors)
        {
            foreach (var ps in supervisors)
            {
                Console.WriteLine($"Supervisor: {ps.Name}");
                ps.ReviewStudentEngagement();
            }
        }
    }
}
