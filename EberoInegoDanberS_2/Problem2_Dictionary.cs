using System;
using System.Collections.Generic;

struct Student
{
    public string StudentNumber;
    public string Name;
    public string Program;
    public int YearLevel;
}

class Program
{
    static void Main()
    {
        Dictionary<string, Student> students =
            new Dictionary<string, Student>();

        while (true)
        {
            Console.WriteLine("\n===== STUDENT RECORD SYSTEM =====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Display All Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Update Student");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine()!;

            switch (choice)
            {
            
                case "1":

                    Console.Write("Enter Student Number: ");
                    string studentNumber = Console.ReadLine()!;

                   
                    if (students.ContainsKey(studentNumber))
                    {
                        Console.WriteLine("Student Number already exists.");
                        break;
                    }

                    Student newStudent = new Student();

                    newStudent.StudentNumber = studentNumber;

                    Console.Write("Enter Name: ");
                    newStudent.Name = Console.ReadLine()!;

                    Console.Write("Enter Program: ");
                    newStudent.Program = Console.ReadLine()!;

                    Console.Write("Enter Year Level (1-4): ");
                    newStudent.YearLevel =
                        Convert.ToInt32(Console.ReadLine());

                    students.Add(studentNumber, newStudent);

                    Console.WriteLine("Student added successfully!");

                    break;


              
                case "2":

                    if (students.Count == 0)
                    {
                        Console.WriteLine("No student records found.");
                    }
                    else
                    {
                        Console.WriteLine("\n===== ALL STUDENTS =====");

                        foreach (var item in students)
                        {
                            Student student = item.Value;

                            Console.WriteLine("\nStudent Number: "
                                + student.StudentNumber);

                            Console.WriteLine("Name: "
                                + student.Name);

                            Console.WriteLine("Program: "
                                + student.Program);

                            Console.WriteLine("Year Level: "
                                + student.YearLevel);
                        }
                    }

                    break;


              
                case "3":

                    Console.Write("Enter Student Number to search: ");
                    string searchNumber = Console.ReadLine()!;

                    if (students.TryGetValue(searchNumber, out Student foundStudent))
                    {
                        Console.WriteLine("\n===== STUDENT FOUND =====");

                        Console.WriteLine("Student Number: "
                            + foundStudent.StudentNumber);

                        Console.WriteLine("Name: "
                            + foundStudent.Name);

                        Console.WriteLine("Program: "
                            + foundStudent.Program);

                        Console.WriteLine("Year Level: "
                            + foundStudent.YearLevel);
                    }
                    else
                    {
                        Console.WriteLine("Student Number does not exist.");
                    }

                    break;


           
                case "4":

                    Console.Write("Enter Student Number to update: ");
                    string updateNumber = Console.ReadLine()!;

                    if (students.ContainsKey(updateNumber))
                    {
                        Student student = students[updateNumber];

                        Console.Write("Enter New Name: ");
                        student.Name = Console.ReadLine()!;

                        Console.Write("Enter New Program: ");
                        student.Program = Console.ReadLine()!;

                        Console.Write("Enter New Year Level (1-4): ");
                        student.YearLevel =
                            Convert.ToInt32(Console.ReadLine());

                        students[updateNumber] = student;

                        Console.WriteLine("Student updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Student Number does not exist.");
                    }

                    break;


                case "5":

                    Console.Write("Enter Student Number to delete: ");
                    string deleteNumber = Console.ReadLine()!;

                    if (students.Remove(deleteNumber))
                    {
                        Console.WriteLine("Student deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Student Number does not exist.");
                    }

                    break;


               
                case "6":

                    Console.WriteLine("Program ended.");
                    return;


                default:

                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}