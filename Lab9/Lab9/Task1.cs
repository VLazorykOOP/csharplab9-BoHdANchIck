using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    public class Task1
    {
        private static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        public static string PostfixToPrefix(string postfix)
        {
            Stack<string> stack = new Stack<string>();

            foreach (char c in postfix)
            {
                if (IsOperator(c))
                {
                    string operand2 = stack.Pop();
                    string operand1 = stack.Pop();

                    string expression = c + operand1 + operand2;
                    stack.Push(expression);
                }
                else
                {
                    stack.Push(c.ToString());
                }
            }

            return stack.Pop();
        }
    }
}
