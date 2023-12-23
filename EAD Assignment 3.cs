using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class StudentDatabase
    {
       static  Dictionary<int, string> studentDictionary = new Dictionary<int, string>();

        public void PopulateStudentDatabase()
        {
            studentDictionary.Add(101, "Rehman");
            studentDictionary.Add(102, "Ali");
            studentDictionary.Add(103, "Hamza");
            studentDictionary.Add(104, "Khizar");
        }

        public void DisplayStudentDatabase()
        {
            Console.WriteLine("\nStudent Database:");
            foreach (var p in studentDictionary)
            {
                Console.WriteLine($"Student ID: {p.Key}, Name: {p.Value}");
            }
        }

        public void SearchStudentByID()
        {
            Console.Write("Enter Student ID to search: ");
            if (int.TryParse(Console.ReadLine(), out int studentID))
            {
                if (studentDictionary.ContainsKey(studentID))
                {
                    Console.WriteLine($"Student ID: {studentID}, Name: {studentDictionary[studentID]}");
                }
                else
                {
                    Console.WriteLine("Student ID not found in the database.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid Student ID.");
            }
        }

        public void UpdateStudentName()
        {
            Console.Write("Enter Student ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int studentID))
            {
                if (studentDictionary.ContainsKey(studentID))
                {
                    Console.Write("Enter new name: ");
                    string newName = Console.ReadLine();
                    studentDictionary[studentID] = newName;
                    Console.WriteLine($"Student ID: {studentID} updated with the new name: {newName}");
                }
                else
                {
                    Console.WriteLine("Student ID not found in the database.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid Student ID.");
            }
        }

        class MyList<T>
    {
        List<T> elementList=new List<T>();
        public void AddElement(T element)
        {
         
            this.elementList.Add(element);
        }
        public void removeElement(T element)
        {
            this.elementList.Remove(element);
        }
        public void display()
        {
            foreach (var element in this.elementList)
            {
                Console.Write(element);
                Console.Write(" ");
            }
        }
    }
      
        class Book
    {
        private string title;
       private string author;
        public Book(string title,string author="Unkown") {
       this.author = author;
            this.title = title;
        }
        public void display()
        {
            Console.WriteLine($"Title: {title}, Author:{author}");
        }
    }

        internal class Program
        {
            
            static public void Greet(String greeting = "hello", string name = "word")
            {
                Console.WriteLine($"{greeting} , {name}");

            }

            static public double CalculateArea(double length = 1.0, double width = 1.0)
            {
                return length * width;
            }
            static public int AddNumbers(int a, int b)
            {
                return a + b;
            }
            static public int AddNumbers(int a, int b, int c = 0)
            {
                return a + b + c;

            }

            static public void swap<T>(ref T a, ref T b)
            {
                T temp;
                temp = a;
                a = b;
                b = temp;
            }

            public static T Sum<T>(T[] array)
            {
                if (array == null || array.Length == 0)
                {
                    throw new ArgumentException("Array is null or empty");
                }

                if (!IsAdditionSupported(typeof(T)))
                {
                    throw new ArgumentException("Type does not support addition");
                }

                dynamic sum = 0;
                foreach (T element in array)
                {
                    sum += element;
                }

                return sum;
            }

            private static bool IsAdditionSupported(Type type)
            {
                return type == typeof(int) ||
                       type == typeof(long) ||
                       type == typeof(float) ||
                       type == typeof(double);
            }

            static void Main(string[] args)
            {
                /* Book b = new Book("the age of ultron");
                 b.display();*/

                /*MyList<int> myList = new MyList<int>();
                myList.AddElement(1);
                myList.AddElement(2);
                myList.AddElement(3);
                myList.AddElement(4);
                myList.display();*/
                /*int a = 1;
                int b = 2;
                swap<int>(ref a, ref b);
                Console.Write(a);
                Console.Write(" ");
                Console.Write(b);*/
                StudentDatabase s1 = new StudentDatabase();
                s1.PopulateStudentDatabase();
                bool isTrue = true;
                while (isTrue)
                {
                    Console.WriteLine("\nStudent Database Menu:");
                    Console.WriteLine("1. View the student database");
                    Console.WriteLine("2. Search for a student by ID");
                    Console.WriteLine("3. Update a student's name");
                    Console.WriteLine("4. Exit the program");
                    Console.Write("Enter your choice (1-4): ");

                    int choice;
                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                s1.DisplayStudentDatabase();
                                break;
                            case 2:
                               s1.SearchStudentByID();
                                break;
                            case 3:
                                s1.UpdateStudentName();
                                break;
                            case 4:
                                Console.WriteLine("Exiting the program.");
                                isTrue = false;
                                return;
                            default:
                                Console.WriteLine("Invalid choice. Please enter a valid option (1-4).");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid option (1-4).");
                    }
                }


            }
        }

    
    }
}
