using System;
using System.Collections.Generic;

struct Student
{
    public string StudentNumber;
    public string Name;
    public string Program;
    public int YearLevel;
}
struct Operation
{
    public string Action;
    public string StudentNumber;
    public string StudentName;
}

class Program
{
       static void RecordOperation(Stack<Operation> history, string action,
                                string studentNumber, string studentName)
    {
        Operation op;
        op.Action = action;
        op.StudentNumber = studentNumber;
        op.StudentName = studentName;

        history.Push(op);
    }

    static void OperationHistoryMenu(Stack<Operation> history)
    {
        while (true)
        {
            Console.WriteLine("\n==============================");
            Console.WriteLine("       OPERATION HISTORY");
            Console.WriteLine("==============================");
            Console.WriteLine("1. View Operation History");
            Console.WriteLine("2. View Last Operation");
            Console.WriteLine("3. Remove Last Operation");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");

            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
            
                    if (history.Count == 0)
                    {
                        Console.WriteLine("\nNo operations recorded.");
                    }
                    else
                    {
                        Console.WriteLine("\nOPERATION HISTORY\n");

                        Operation[] ops = history.ToArray();
                        int number = 1;

                        for (int i = ops.Length - 1; i >= 0; i--)
                        {
                            Console.WriteLine(number + ". " + ops[i].Action + " " + ops[i].StudentName);
                            number++;
                        }
                    }
                    break;

                case "2":
                 
                    if (history.Count == 0)
                    {
                        Console.WriteLine("\nNo operations recorded.");
                    }
                    else
                    {
                        Operation last = history.Peek();
                        Console.WriteLine("\nLast Operation: " + last.Action + " " + last.StudentName);
                    }
                    break;

                case "3":
            
                    if (history.Count == 0)
                    {
                        Console.WriteLine("\nNo operations recorded.");
                    }
                    else
                    {
                        history.Pop();
                        Console.WriteLine("\nLast operation removed successfully!");
                    }
                    break;

                case "4":
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter 1-4.");
                    break;
            }
        }
    }

    static void Main()
    {
        Student[] students = new Student[10];
        int studentCount = 0;

        Stack<Operation> operationHistory = new Stack<Operation>();

        while (true)
        {
            Console.WriteLine("\n===== STUDENT RECORD SYSTEM =====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Display All Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Update Student");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("6. Operation History");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
    
                    if (studentCount >= 10)
                    {
                        Console.WriteLine("Cannot add more than 10 students.");
                    }
                    else
                    {
                        Console.Write("Enter Student Number: ");
                        students[studentCount].StudentNumber = Console.ReadLine()!;

                        Console.Write("Enter Name: ");
                        students[studentCount].Name = Console.ReadLine()!;

                        Console.Write("Enter Program: ");
                        students[studentCount].Program = Console.ReadLine()!;

                        Console.Write("Enter Year Level (1-4): ");
                        students[studentCount].YearLevel =
                            Convert.ToInt32(Console.ReadLine());

                        RecordOperation(operationHistory, "Added",
                            students[studentCount].StudentNumber,
                            students[studentCount].Name);

                        studentCount++;

                        Console.WriteLine("Student added successfully!");
                    }

                    break;


                case "2":
            
                    if (studentCount == 0)
                    {
                        Console.WriteLine("No student records found.");
                    }
                    else
                    {
                        Console.WriteLine("\n===== ALL STUDENTS =====");

                        for (int i = 0; i < studentCount; i++)
                        {
                            Console.WriteLine("\nStudent #" + (i + 1));
                            Console.WriteLine("Student Number: "
                                + students[i].StudentNumber);
                            Console.WriteLine("Name: "
                                + students[i].Name);
                            Console.WriteLine("Program: "
                                + students[i].Program);
                            Console.WriteLine("Year Level: "
                                + students[i].YearLevel);
                        }
                    }

                    break;


                case "3":
        
                    Console.Write("Enter Student Number to search: ");
                    string searchNumber = Console.ReadLine()!;

                    bool found = false;

                    for (int i = 0; i < studentCount; i++)
                    {
                        if (students[i].StudentNumber == searchNumber)
                        {
                            Console.WriteLine("\nStudent Found!");
                            Console.WriteLine("Student Number: "
                                + students[i].StudentNumber);
                            Console.WriteLine("Name: "
                                + students[i].Name);
                            Console.WriteLine("Program: "
                                + students[i].Program);
                            Console.WriteLine("Year Level: "
                                + students[i].YearLevel);

                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("Student not found.");
                    }

                    break;


                case "4":
         
                    Console.Write("Enter Student Number to update: ");
                    string updateNumber = Console.ReadLine()!;

                    bool updateFound = false;

                    for (int i = 0; i < studentCount; i++)
                    {
                        if (students[i].StudentNumber == updateNumber)
                        {
                            Console.Write("Enter New Name: ");
                            students[i].Name = Console.ReadLine()!;

                            Console.Write("Enter New Program: ");
                            students[i].Program = Console.ReadLine()!;

                            Console.Write("Enter New Year Level (1-4): ");
                            students[i].YearLevel =
                                Convert.ToInt32(Console.ReadLine());

                            RecordOperation(operationHistory, "Updated",
                                students[i].StudentNumber,
                                students[i].Name);

                            updateFound = true;

                            Console.WriteLine("Student updated successfully!");
                            break;
                        }
                    }

                    if (!updateFound)
                    {
                        Console.WriteLine("Student not found.");
                    }

                    break;


                case "5":
        
                    Console.Write("Enter Student Number to delete: ");
                    string deleteNumber = Console.ReadLine()!;

                    bool deleteFound = false;

                    for (int i = 0; i < studentCount; i++)
                    {
                        if (students[i].StudentNumber == deleteNumber)
                        {
                
                            RecordOperation(operationHistory, "Deleted",
                                students[i].StudentNumber,
                                students[i].Name);

                       
                            for (int j = i; j < studentCount - 1; j++)
                            {
                                students[j] = students[j + 1];
                            }

                            studentCount--;
                            deleteFound = true;

                            Console.WriteLine("Student deleted successfully!");
                            break;
                        }
                    }

                    if (!deleteFound)
                    {
                        Console.WriteLine("Student not found.");
                    }

                    break;


                case "6":
                
                    OperationHistoryMenu(operationHistory);
                    break;


                case "7":
               
                    Console.WriteLine("Program ended.");
                    return;


                default:
                    Console.WriteLine("Invalid choice. Please enter 1-7.");
                    break;
            }
        }
    }
}
