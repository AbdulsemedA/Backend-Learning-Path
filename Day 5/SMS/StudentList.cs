using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;


namespace SMS
{
    public class StudentList<T>
    {
        private List<T> students;

        public StudentList()
        {
            students = new List<T>();
        }

        public void Add(T student)
        {
            students.Add(student);
        }


        // Search student by name
        public T SearchByName(string name)
        {
            var foundStudent = from student in students
                               where student.GetType().GetProperty("Name")?.GetValue(student)?.ToString()?.Equals(name, StringComparison.OrdinalIgnoreCase) == true
                               select student;
            return foundStudent.FirstOrDefault()!;

        }


        // Search student by ID
        public T SearchByID(int rollNumber)
        {
            var foundStudent = students.FirstOrDefault(s =>
            {
                if (s is Student student && student.RollNumber == rollNumber)
                    return true;
                return false;
            });

            return foundStudent!;
        }


        // Update student
        public void UpdateStudent(int rollNumber, T updatedStudent)
        {
            var existingStudent = students.FirstOrDefault(s =>
            {
                if (s is Student student && student.RollNumber == rollNumber)
                    return true;
                return false;
            });

            if (existingStudent != null)
            {
                students[students.IndexOf(existingStudent)] = updatedStudent;
                Console.WriteLine("Student information updated successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        // Delete student
        public void DeleteStudent(int rollNumber)
        {
            var existingStudent = students.FirstOrDefault(s =>
            {
                if (s is Student student && student.RollNumber == rollNumber)
                    return true;
                return false;
            });

            if (existingStudent != null)
            {
                students.Remove(existingStudent);
                Console.WriteLine("Student deleted successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }


        // Sort students by name or age
        public void SortStudents(string sortBy)
        {
            switch (sortBy.ToLower())
            {
                case "name":
                    students = students.OrderBy(s => (s as Student)?.Name, StringComparer.OrdinalIgnoreCase).ToList();
                    Console.WriteLine("Students sorted by name.");
                    break;

                case "age":
                    students = students.OrderBy(s => (s as Student)?.Age).ToList();
                    Console.WriteLine("Students sorted by age.");
                    break;

                default:
                    Console.WriteLine("Invalid sort criteria.");
                    break;
            }
        }



        // Display student
        public void Display(T student)
        {
            if (student != null && student is Student validStudent)
            {
                Console.WriteLine("\n----------------------------------------------------");
                Console.WriteLine($"{"Name", -20} {"Age", -5} {"Roll Number", -15} {"Grade", -10}");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine($"{validStudent.Name, -20} {validStudent.Age, -5} {validStudent.RollNumber, -15} {validStudent.Grade, -10}");
                Console.WriteLine("----------------------------------------------------\n");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        // Display all students
        public void DisplayAll()
        {
            if (students != null && students.Any())
            {
                Console.WriteLine("\n----------------------------------------------------");
                Console.WriteLine($"{"Name", -20} {"Age", -5} {"Roll Number", -15} {"Grade", -10}");
                Console.WriteLine("----------------------------------------------------");
                
                foreach (var student in students)
                {
                    if (student is Student validStudent)
                    {
                        Console.WriteLine($"{validStudent.Name, -20} {validStudent.Age, -5} {validStudent.RollNumber, -15} {validStudent.Grade, -10}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid student data.");
                    }
                }
                Console.WriteLine("----------------------------------------------------\n");
            }
            
            else
            {
                Console.WriteLine("No students found.");
            }
        }

        public void SaveToJson(string fileName)
        {
            var json = JsonConvert.SerializeObject(students, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }

        public void LoadFromJson(string fileName)
        {
            if (File.Exists(fileName))
            {
                var json = File.ReadAllText(fileName);
                students = JsonConvert.DeserializeObject<List<T>>(json)!;
            }
        }
    }
}
