using System;
public class Subjects {
    private string subject_name;
    private int subject_grade;

    public Subjects(string name, int grade) {
        subject_name = name;
        subject_grade = grade;
    }

    public string GetSubjectName()
    {
        return subject_name;
    }
    public int GetGrade()
    {
        return subject_grade;
    }
}

public class Student_Grade
{
    public static void Main(String[] args) {
        Console.WriteLine("Enter student name: ");
        string name = Console.ReadLine()!;
        
        Console.WriteLine("Enter number of Subjects: ");
        int num = int.Parse(Console.ReadLine()!);
        
        int sum = 0;
        double average = 0;
        List<Subjects> grades = new List<Subjects>();

        for (int i = 0; i < num; i++) {
            Console.WriteLine("Enter subject name: ");
            string subject_name = Console.ReadLine()!;

            Console.WriteLine("Enter subject grade: ");
            int subject_grade = int.Parse(Console.ReadLine()!);
            
            grades.Add(new Subjects(subject_name, subject_grade));
        }

        for (int i = 0; i < num; i++) {
            sum += grades[i].GetGrade();
        }

        average = sum / num;


        Console.Clear();
        Console.WriteLine($"====================================");
        Console.WriteLine($"Student name: {name}");
        Console.WriteLine($"====================================\n");

        Console.WriteLine($"{"Subject", -30} {"Grade"}");
        Console.WriteLine($"------------------------------------");
        
        foreach (Subjects subject in grades)
        {
            Console.WriteLine($"{subject.GetSubjectName(), -30} {subject.GetGrade()}");
            Console.WriteLine($"------------------------------------");
        }

        Console.WriteLine($"\n====================================");
        Console.WriteLine($"Average grade: {average.ToString("0.00")}");
        Console.WriteLine($"====================================");

    }
}