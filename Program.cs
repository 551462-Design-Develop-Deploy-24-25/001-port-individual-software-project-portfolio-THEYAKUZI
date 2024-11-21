using Newtonsoft.Json;
using softwareproject;
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    private const string DataFilePath = "university_data.json";

    static void Main()
    {
        // Load the existing data
        var (students, supervisors, seniorTutor) = LoadData();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("University Engagement System");
            Console.WriteLine("1. Student Self-Report");
            Console.WriteLine("2. Review Engagement (PS)");
            Console.WriteLine("3. Schedule Meeting");
            Console.WriteLine("4. View All Engagement (Senior Tutor)");
            Console.WriteLine("5. Exit and Save Data");
            Console.Write("Choose an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    SelfReport(students);
                    break;
                case "2":
                    ReviewEngagement(supervisors);
                    break;
                case "3":
                    ScheduleMeeting(students, supervisors);
                    break;
                case "4":
                    seniorTutor.ViewAllStudentEngagement(supervisors);
                    Pause();
                    break;
                case "5":
                    SaveData(students, supervisors, seniorTutor);
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    Pause();
                    break;
            }
        }
    }
    // Student self report
    static void SelfReport(List<Student> students)
    {
        var student = Select("Select a student", students);
        if (student == null) return;

        Console.Write("Enter status: ");
        var status = Console.ReadLine();
        Console.Write("Enter comments: ");
        var comments = Console.ReadLine();

        student.SelfReport(status, comments);
        Console.WriteLine("Report submitted.");
        Pause();
    }
    // PS student status review
    static void ReviewEngagement(List<PersonalSupervisor> supervisors)
    {
        var supervisor = Select("Select a supervisor", supervisors);
        if (supervisor == null) return;

        supervisor.ReviewStudentEngagement();
        Pause();
    }
    // Schedule a meeting with a Supervisor
    static void ScheduleMeeting(List<Student> students, List<PersonalSupervisor> supervisors)
    {
        var student = Select("Select a student", students);
        var supervisor = Select("Select a supervisor", supervisors);
        if (student == null || supervisor == null) return;

        Console.Write("Enter meeting date (yyyy-mm-dd): ");
        if (DateTime.TryParse(Console.ReadLine(), out var date))
        {
            student.ScheduleMeeting(supervisor, date);
            Console.WriteLine("Meeting scheduled.");
        }
        else
        {
            Console.WriteLine("Invalid date.");
        }
        Pause();
    }
    // Console menu 
    static T Select<T>(string prompt, List<T> items)
    {
        Console.WriteLine($"\n{prompt}:");
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i]}");
        }

        Console.Write("Enter your choice: ");
        if (int.TryParse(Console.ReadLine(), out var index) && index > 0 && index <= items.Count)
        {
            return items[index - 1];
        }

        Console.WriteLine("Invalid selection.");
        Pause();
        return default;
    }

    static void Pause()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    // Save data to JSON file
    static void SaveData(List<Student> students, List<PersonalSupervisor> supervisors, SeniorTutor seniorTutor)
    {
        var data = new UniversityData
        {
            Students = students,
            Supervisors = supervisors,
            SeniorTutor = seniorTutor
        };

        var json = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(DataFilePath, json);
        Console.WriteLine("Data saved.");
    }

    // Load data from JSON file
    static (List<Student>, List<PersonalSupervisor>, SeniorTutor) LoadData()
    {
        if (File.Exists(DataFilePath))
        {
            var json = File.ReadAllText(DataFilePath);
            var data = JsonConvert.DeserializeObject<UniversityData>(json);

            return (data.Students, data.Supervisors, data.SeniorTutor);
        }
        else
        {
            // Return default data if file doesn't exist
            var students = new List<Student> { new Student(1, "Alice"), new Student(2, "Bob") };
            var supervisors = new List<PersonalSupervisor> { new PersonalSupervisor(101, "Dr. Smith") };
            var seniorTutor = new SeniorTutor(201, "Professor Johnson");

            //Add student
            supervisors[0].Students.Add(students[0]);
            supervisors[0].Students.Add(students[1]);
            return (students, supervisors, seniorTutor);
        }
    }
}
