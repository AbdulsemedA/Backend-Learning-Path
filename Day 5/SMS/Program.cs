using System;
using SMS;
    
    class Program
    {
        static void Main()
        {
            var studentList = new StudentList<Student>();
            var Std = new StudentList<Student>();
            const string fileName = "students.json";
            studentList.LoadFromJson(fileName);

            while (true)
        {
            Console.WriteLine("\n--- Student Management System ---");
            Console.WriteLine("1. Add New Student");
            Console.WriteLine("2. Search Student by Name");
            Console.WriteLine("3. Search Student by ID");
            Console.WriteLine("4. Display All Students");
            Console.WriteLine("5. Save Data to JSON");
            Console.WriteLine("6. Update Student");
            Console.WriteLine("7. Delete Student");
            Console.WriteLine("8. Sort Students by Name");
            Console.WriteLine("9. Sort Students by Age");
            Console.WriteLine("10. Exit");

            Console.Write("\nEnter your choice (1-10): ");
            string? choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                // Add new student
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine()!;
                    Console.Write("Enter Age: ");
                    int age = int.Parse(Console.ReadLine()!);
                    Console.Write("Enter Roll Number: ");
                    int rollNumber = int.Parse(Console.ReadLine()!);
                    Console.Write("Enter Grade: ");
                    string grade = Console.ReadLine()!;

                    var newStudent = new Student(name, age, rollNumber, grade);
                    studentList.Add(newStudent);
                    break;

                case "2":
                // Search student by name
                    Console.Write("Enter the name of the student to search: ");
                    string searchName = Console.ReadLine()!;
                    var foundByName = studentList.SearchByName(searchName);
                    Console.Clear();
                    studentList.Display(foundByName);
                    break;

                case "3":
                // Search student by ID
                    Console.Write("Enter the ID (Roll Number) of the student to search: ");
                    int searchId = int.Parse(Console.ReadLine()!);
                    var foundById = studentList.SearchByID(searchId);
                    Console.Clear();
                    studentList.Display(foundById);
                    break;

                case "4":
                    // Display all students
                    Console.Clear();
                    Console.WriteLine("\nAll Students:");
                    studentList.DisplayAll();
                    break;

                case "5":
                    // Save data to JSON
                    studentList.SaveToJson(fileName);
                    Console.WriteLine($"Student data saved to '{fileName}'.");
                    break;
                
                case "6":
                    // Update student
                    Console.Write("Enter the ID (Roll Number) of the student to update: ");
                    int updateId = int.Parse(Console.ReadLine()!);
                    var foundStudent = studentList.SearchByID(updateId);
                    if (foundStudent != null)
                    {
                        // Get updated details from the user
                        Console.Write("Enter Name: ");
                        string Newname = Console.ReadLine()!;
                        Console.Write("Enter Age: ");
                        int Newage = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter Grade: ");
                        string Newgrade = Console.ReadLine()!;

                        var updatedStudent = new Student(Newname, Newage, updateId, Newgrade);
                        studentList.UpdateStudent(updateId, updatedStudent);
                    }
                    else
                    {
                        Console.WriteLine("Student not found.");
                    }
                    break;
                
                case "7":
                    // Delete student
                    Console.Write("Enter the ID (Roll Number) of the student to delete: ");
                    int deleteId = int.Parse(Console.ReadLine()!);
                    studentList.DeleteStudent(deleteId);
                    break;
                
                case "8":
                    studentList.SortStudents("name");
                    break;

                case "9":
                    studentList.SortStudents("age");
                    break;

                case "10":
                    // Save data to JSON before exiting
                    studentList.SaveToJson(fileName);
                    Console.WriteLine("Exiting the program.");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}