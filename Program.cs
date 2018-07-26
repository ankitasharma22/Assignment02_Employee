using System;
using System.Collections.Generic;
using System.IO;
delegate string PrintMessage(string Message);
namespace Assignment03
{
    class HelloWorld
    {
        //print exceptions, using delegate concept
        public static string PrintException(string FinalMessage)
        {
            Console.WriteLine("{0} ", FinalMessage);
            return FinalMessage;
        }

        static void Main(string[] args)
        {
            int userChoice = 0;
            int tempId = 101;

            PrintMessage pm1 = new PrintMessage(PrintException);  //instance of delegate, passing method 'PrintException'

            List<Employee> employees = new List<Employee>();
            Console.WriteLine("Enter employee details \n");
            Employee e1 = new Employee();
            do
            {
                e1.employeeId = tempId;
                Console.WriteLine("Employee ID-- {0}", e1.employeeId);
                Console.WriteLine("Employee Name-- ");
                e1.employeeName = Console.ReadLine();
                Console.WriteLine("Qualification-- ");
                e1.qualification = Console.ReadLine();
                Console.WriteLine("Qualifications allowed: BE, BSC, BCA, BCom, MCom, CA-- ");

                try
                {
                    if (string.IsNullOrEmpty(e1.qualification))
                    {
                        Exception ex = new Exception();
                        ex = new EmptyQualification();
                        RecordException(ex);
                        throw (ex);
                    }
                    else if (!(e1.qualification == "BE" || e1.qualification == "BSC" || e1.qualification == "BCA" || e1.qualification == "BCom" || e1.qualification == "MCom" || e1.qualification == "CA"))
                    {
                        Exception ex = new Exception();
                        ex = new QualificationException(e1.qualification);
                        RecordException(ex);
                        throw (ex);
                    }
                }
                catch (QualificationException exe)
                {
                    pm1(exe.Message());
                }
                catch (EmptyQualification exe)
                {
                    pm1(exe.Message());
                }

                if (e1.qualification == "BE" || e1.qualification == "BSC" || e1.qualification == "BCA")
                {
                    e1.department = "IT";
                    Console.WriteLine("Employee has been added to IT Department.");
                }
                else if (e1.qualification == "BCom" || e1.qualification == "MCom" || e1.qualification == "CA")
                {
                    e1.department = "Accounts";
                    Console.WriteLine("Employee has been added to ACcounts Department.");
                }

                employees.Add(e1);
                tempId++;
                Console.WriteLine("Do you want to continue? Press 0 to Exit, any other digit to continue ");
                userChoice = Convert.ToInt32(Console.ReadLine());
            } while (userChoice != 0);
        }

        //To keep track of the exceptions thrown
        public static void RecordException(Exception ex)
        {
            try
            {
                string filepath = @"C:\Ankita\Assignment03.txt";  //Text File Path

                if (!File.Exists(filepath))
                {
                    File.Create(filepath).Dispose();

                }
                using (StreamWriter writer = new StreamWriter(filepath, true))
                {
                    writer.WriteLine("Message :" + ex.Message + "StackTrace :" + ex.StackTrace);
                    writer.WriteLine("-----------------------------------------------------------------------------");
                }
            }
            catch (Exception e)
            {
                ;
            }
            finally
            {
                Console.WriteLine(); //This will be executed everytime, will print a new line
            }
        }

        //Exception for wrong Qualification
        public class QualificationException : Exception
        {
            string exc;
            public QualificationException(string invalid)
            {
                exc = invalid;
            }
            public string Message()
            {
                return "Invalid type of qualification";
            }
        }

        //Exception for empty qualification
        public class EmptyQualification : Exception
        {
            string exc;
            public EmptyQualification() {; }
            public string Message()
            {
                return "Qualification can't be empty";
            }
        }

        //Class of employees
        public class Employee
        {
            public string employeeName, qualification, department;
            public int employeeId;
        }
    }
}