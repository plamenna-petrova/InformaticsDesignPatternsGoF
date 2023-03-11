using System;
using System.Collections.Generic;
using System.Linq;

namespace Third_Party_Billing_System
{
    public class Employee
    {
       public int ID { get; set; }
       
       public string Name { get; set; }

       public string Designation { get; set; }

       public decimal Salary { get; set; }
    }

    public class ThirdPartyBillingSystem
    {
        public void ProcessSalary(List<Employee> employeesList)
        {
            foreach (var employee in employeesList)
            {
                Console.WriteLine($"Salary: {employee.Salary}, " +
                    $"Credited to: {employee.Name} with designation: {employee.Designation}");
            }
        }
    }

    public interface ITarget
    {
        void ProcessCompanySalary(string[,] employeesArray);
    }

    public class EmployeeAdapter : ITarget
    {
        ThirdPartyBillingSystem thirdPartyBillingSystem = new ThirdPartyBillingSystem();

        public void ProcessCompanySalary(string[,] employeesArray)
        {
            List<Employee> adaptedEmployees = new List<Employee>();

            for (int i = 0; i < employeesArray.GetLength(0); i++)
            {
                Employee employee = new Employee();

                for (int j= 0; j < employeesArray.GetLength(1); j++)
                {
                    string employeeDatum = employeesArray[i, j];

                    switch (j)
                    {
                        case 0:
                            employee.ID = int.Parse(employeeDatum);
                            break;
                        case 1:
                            employee.Name = employeeDatum;
                            break;
                        case 2:
                            employee.Designation = employeeDatum;
                            break;
                        default:
                            employee.Salary = decimal.Parse(employeeDatum);
                            break;
                    }
                }

                adaptedEmployees.Add(employee);
            }

            Console.WriteLine("Adapter converted array of employees to a list of employees");
            Console.WriteLine("Then delegate to the ThirdPartyBillingSystem for processing the employees salary\n");
            thirdPartyBillingSystem.ProcessSalary(adaptedEmployees);
        }
    }

    public class Program
    {
        // Enter data in the following format:

        // 101 John Engineer 10000
        // 102 Smith Developer 20000
        // 103 Dean CEO 30000
        // 104 Chris Engineer 40000
        // 105 Sarah Architect 50000

        public static string[,] Fill2DArrayElementsWithRowsAndCols(int rows, int cols)
        {
            string[,] twoDimensionalArray = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] rowArray = Console.ReadLine().Split().ToArray();

                for (int col = 0; col < cols; col++)
                {
                    twoDimensionalArray[row, col] = rowArray[col];
                }
            }

            return twoDimensionalArray;
        }

        static void Main(string[] args)
        {
            string[,] employees2DDataArray = Fill2DArrayElementsWithRowsAndCols(5, 4);
            Console.WriteLine();

            ITarget target = new EmployeeAdapter();
            Console.WriteLine("HR system passes employee string array to Adapter");
            target.ProcessCompanySalary(employees2DDataArray);

            Console.Read();
        }
    }
}
