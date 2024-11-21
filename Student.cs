using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace softwareproject
{
    public class Student
    {
        public int StudentId { get; }
        public string Name { get; }
        public List<EngagementReport> Reports { get; } = new List<EngagementReport>();
        public List<Meeting> Meetings { get; } = new List<Meeting>();

        public Student(int id, string name) { StudentId = id; Name = name; }

        public void SelfReport(string status, string comments)
        {
            Reports.Add(new EngagementReport { Date = DateTime.Now, Status = status, Comments = comments });
        }

        public void ScheduleMeeting(PersonalSupervisor ps, DateTime date)
        {
            ps.Meetings.Add(new Meeting { Student = this, Supervisor = ps, Date = date });
        }

        public override string ToString() => Name;
    }
}
