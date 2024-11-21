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

                // Print engagement reports
                foreach (var report in student.Reports)
                {
                    Console.WriteLine($"- {report.Date.ToShortDateString()}: {report.Status} - {report.Comments}");
                }

                // Print scheduled meetings
                var studentMeetings = Meetings.FindAll(m => m.Student == student);
                foreach (var meeting in studentMeetings)
                {
                    Console.WriteLine($"Meeting on {meeting.Date.ToShortDateString()} with {Name}");
                }
            }
        }

        public override string ToString() => Name;
    }

}
