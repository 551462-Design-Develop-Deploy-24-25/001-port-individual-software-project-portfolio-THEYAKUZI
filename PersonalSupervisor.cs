using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace softwareproject
{
    public class PersonalSupervisor
    {
        public int SupervisorId { get; }
        public string Name { get; }
        public List<Student> Students { get; } = new List<Student>();
        public List<Meeting> Meetings { get; } = new List<Meeting>();

        public PersonalSupervisor(int id, string name) { SupervisorId = id; Name = name; }

        public void ReviewStudentEngagement()
        {
            foreach (var student in Students)
            {
                Console.WriteLine($"Student: {student.Name}");
                foreach (var report in student.Reports)
                {
                    Console.WriteLine($"- {report.Date.ToShortDateString()}: {report.Status} - {report.Comments}");
                }
            }
        }

        public override string ToString() => Name;
    }
}
