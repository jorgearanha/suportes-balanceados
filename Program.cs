using System;

namespace SuportesBalanceados
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                Console.WriteLine(arg);
                Console.WriteLine("A entrada" + (isValid(arg) ? "" : " não") + " é um suporte balanceado.");
            }
        }

        static Boolean isValid(string text)
        {
            Dictionary<char, char> closeToOpen = new Dictionary<char, char>(){
                {']', '['},
                {'}', '{'},
                {')', '('}
            };

            char[] validOpen = new char[] { '{', '[', '(' };
            char[] validClose = new char[] { '}', ']', ')' };

            Stack<char> stack = new Stack<char>();
            foreach (var word in text.ToCharArray())
            {
                if (validClose.Contains(word) && stack.Count > 0)
                {
                    char temp = stack.Pop();

                    if (!temp.Equals(closeToOpen[word]))
                    {
                        return false;
                    }
                }
                else
                {
                    stack.Push(word);
                }
            }

            return stack.Count <= 0;
        }
    }
}