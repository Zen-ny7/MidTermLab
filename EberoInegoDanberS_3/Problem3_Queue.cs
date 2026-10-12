using System;
using System.Collections.Generic;

struct StudentRequest
{
    public string StudentNumber;
    public string StudentName;
    public string RequestType;
}

class Program
{
    static void Main()
    {
        Queue<StudentRequest> requestQueue =
            new Queue<StudentRequest>();

        while (true)
        {
            Console.WriteLine("\n===== STUDENT REQUEST SYSTEM =====");
            Console.WriteLine("1. Add Request");
            Console.WriteLine("2. View Pending Requests");
            Console.WriteLine("3. Process Request");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine()!;

            switch (choice)
            {
               
                case "1":

                    StudentRequest request = new StudentRequest();

                    Console.Write("Enter Student Number: ");
                    request.StudentNumber = Console.ReadLine()!;

                    Console.Write("Enter Student Name: ");
                    request.StudentName = Console.ReadLine()!;

                    Console.WriteLine("\nRequest Types:");
                    Console.WriteLine("1. Certificate of Enrollment");
                    Console.WriteLine("2. Student ID");
                    Console.WriteLine("3. Transcript Request");

                    Console.Write("Enter Request Type: ");
                    string requestChoice = Console.ReadLine()!;

                    if (requestChoice == "1")
                    {
                        request.RequestType = "Certificate of Enrollment";
                    }
                    else if (requestChoice == "2")
                    {
                        request.RequestType = "Student ID";
                    }
                    else if (requestChoice == "3")
                    {
                        request.RequestType = "Transcript Request";
                    }
                    else
                    {
                        Console.WriteLine("Invalid request type.");
                        break;
                    }

                   
                    requestQueue.Enqueue(request);

                    Console.WriteLine("Request added successfully!");

                    break;


                case "2":

                    if (requestQueue.Count == 0)
                    {
                        Console.WriteLine("There are no pending requests.");
                    }
                    else
                    {
                        Console.WriteLine("\n===== PENDING REQUESTS =====");

                        int number = 1;

                        foreach (StudentRequest item in requestQueue)
                        {
                            Console.WriteLine("\nRequest #" + number);
                            Console.WriteLine("Student Number: "
                                + item.StudentNumber);
                            Console.WriteLine("Student Name: "
                                + item.StudentName);
                            Console.WriteLine("Request Type: "
                                + item.RequestType);

                            number++;
                        }
                    }

                    break;


                case "3":

                    if (requestQueue.Count == 0)
                    {
                        Console.WriteLine("There are no pending requests.");
                    }
                    else
                    {
            
                        StudentRequest processedRequest =
                            requestQueue.Dequeue();

                        Console.WriteLine("\n===== PROCESSING REQUEST =====");

                        Console.WriteLine("Student Number: "
                            + processedRequest.StudentNumber);

                        Console.WriteLine("Student Name: "
                            + processedRequest.StudentName);

                        Console.WriteLine("Request Type: "
                            + processedRequest.RequestType);

                        Console.WriteLine("Request processed successfully!");
                    }

                    break;

                case "4":

                    Console.WriteLine("Program ended.");
                    return;


                default:

                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}


