using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    class Task3
    {
        // --- Завдання 1: Постфікс -> Префікс ---
        public static void SolvePostfixToPrefix()
        {
            Console.WriteLine("Enter a postfix expression (without spaces):");
            string postfix = Console.ReadLine();

            ArrayList stack = new ArrayList();

            foreach (char c in postfix)
            {
                if (IsOperator(c))
                {
                    string op2 = (string)stack[stack.Count - 1];
                    stack.RemoveAt(stack.Count - 1);
                    string op1 = (string)stack[stack.Count - 1];
                    stack.RemoveAt(stack.Count - 1);

                    string expression = c + op1 + op2;
                    stack.Add(expression);
                }
                else
                {
                    stack.Add(c.ToString());
                }
            }

            string prefix = (string)stack[0];
            Console.WriteLine("The prefix expression is:");
            Console.WriteLine(prefix);
        }

        private static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        // --- Завдання 2: Обробка співробітників ---
        public static void SolveEmployeesProcessing()
        {
            Console.WriteLine("Enter the path to the file:");
            string filePath = Console.ReadLine();

            ArrayList lowSalary = new ArrayList();
            ArrayList highSalary = new ArrayList();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        Employee employee = Employee.FromString(line);

                        if (employee.Salary < 10000)
                        {
                            lowSalary.Add((Employee)employee.Clone());
                        }
                        else
                        {
                            highSalary.Add((Employee)employee.Clone());
                        }
                    }
                }

                Console.WriteLine("Employees with salary less than 10000:");
                foreach (Employee emp in lowSalary)
                {
                    Console.WriteLine(emp);
                }

                Console.WriteLine("\nOther employees:");
                foreach (Employee emp in highSalary)
                {
                    Console.WriteLine(emp);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading file: " + ex.Message);
            }
        }

        // --- Клас Employee ---
        class Employee : ICloneable
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

            public object Clone()
            {
                return this.MemberwiseClone();
            }
        }

        // --- Клас для порівняння зарплати ---
        class SalaryComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                Employee emp1 = (Employee)x;
                Employee emp2 = (Employee)y;

                return emp1.Salary.CompareTo(emp2.Salary);
            }
        }
    }
}
