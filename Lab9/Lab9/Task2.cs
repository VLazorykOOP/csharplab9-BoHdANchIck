using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    class Employee
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }

        public static Employee FromString(string line)
        {
            var parts = line.Split(',');

            return new Employee
            {
                LastName = parts[0].Trim(),
                FirstName = parts[1].Trim(),
                MiddleName = parts[2].Trim(),
                Gender = parts[3].Trim(),
                Age = int.Parse(parts[4]),
                Salary = decimal.Parse(parts[5])
            };
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName} {MiddleName}, {Gender}, {Age} years old, Salary: {Salary}";
        }
    }

    public class Task2
    {
        public static void ProcessEmployees(string filePath)
        {
            Queue<Employee> lowSalary = new Queue<Employee>();
            Queue<Employee> highSalary = new Queue<Employee>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Employee employee = Employee.FromString(line);

                    if (employee.Salary < 10000)
                    {
                        lowSalary.Enqueue(employee);
                    }
                    else
                    {
                        highSalary.Enqueue(employee);
                    }
                }
            }

            Console.WriteLine("Employees with salary less than 10000:");
            while (lowSalary.Count > 0)
            {
                Console.WriteLine(lowSalary.Dequeue());
            }

            Console.WriteLine("\nOther employees:");
            while (highSalary.Count > 0)
            {
                Console.WriteLine(highSalary.Dequeue());
            }
        }
    }
}
