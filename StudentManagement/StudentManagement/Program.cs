using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    class Program
    {
        // Student class to hold student details

        static List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("\n<=== Student Management System ===>");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View All Students");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        ViewStudents();
                        break;
                    case 3:
                        UpdateStudent();
                        break;
                    case 4:
                        DeleteStudent();
                        break;
                    case 5:
                        Console.WriteLine("Exiting the program.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 5);
        }

        static void AddStudent()
        {
            Student student = new Student();
            Console.Write("Enter Student ID: ");
            student.Id = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: ");
            student.Name = Console.ReadLine();
            Console.Write("Enter Age: ");
            student.Age = int.Parse(Console.ReadLine());
            Console.Write("Enter Course: ");
            student.Course = Console.ReadLine();

            students.Add(student);
            Console.WriteLine("Student added successfully.");
        }

        static void ViewStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            Console.WriteLine("\n--- Student List ---");
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Course: {student.Course}");
            }
        }

        static void UpdateStudent()
        {
            Console.Write("Enter the ID of the student to update: ");
            int id = int.Parse(Console.ReadLine());
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.Write("Enter new Name (leave blank to keep current): ");
            string name = Console.ReadLine();
            Console.Write("Enter new Age (leave blank to keep current): ");
            string age = Console.ReadLine();
            Console.Write("Enter new Course (leave blank to keep current): ");
            string course = Console.ReadLine();

            if (!string.IsNullOrEmpty(name)) student.Name = name;
            if (!string.IsNullOrEmpty(age)) student.Age = int.Parse(age);
            if (!string.IsNullOrEmpty(course)) student.Course = course;

            Console.WriteLine("Student details updated successfully.");
        }

        static void DeleteStudent()
        {
            Console.Write("Enter the ID of the student to delete: ");
            int id = int.Parse(Console.ReadLine());
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            students.Remove(student);
            Console.WriteLine("Student deleted successfully.");
        }
    }
}
