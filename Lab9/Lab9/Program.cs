namespace Lab9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChooseTask();

        }


        static void ChooseTask()
        {
            Console.WriteLine("Choose a task:");
            Console.WriteLine("1. Task1");
            Console.WriteLine("2. Task2");
            Console.WriteLine("3. Task3");
            Console.WriteLine("3. Exit");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter a postfix expression (without spaces):");
                    string postfix = Console.ReadLine();

                    string prefix = Task1.PostfixToPrefix(postfix);

                    Console.WriteLine("The prefix expression is:");
                    Console.WriteLine(prefix);
                    break;
                case "2":
                    Console.WriteLine("Enter the path to the file:");
                    //C:\Users\danel\source\repos\csharplab9-BoHdANchIck\text.txt
                    string filePath = Console.ReadLine();
                    Task2.ProcessEmployees(filePath);
                    break;
                case "3":
                    Console.WriteLine("Choose task (1 - Postfix to Prefix, 2 - Employees processing):");
                    string choice1 = Console.ReadLine();

                    if (choice1 == "1")
                    {
                        Task3.SolvePostfixToPrefix();
                    }
                    else if (choice1 == "2")
                    {
                        Task3.SolveEmployeesProcessing();
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice.");
                    }

                    break;
                case "4":
                    Console.WriteLine("Exiting the program.");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    ChooseTask();
                    break;
            }
        }
    }
}
