namespace _02._Conditional_Expression_Resolver
{
    using System;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            var expression = Console.ReadLine()
                .Split(' ')
                .Select(x => x[0])
                .ToArray();

            Console.WriteLine(ParseExpression(expression, 0));
        }

        private static int ParseExpression(char[] expression, int index)
        {
            if (char.IsDigit(expression[index]))
            {
                return expression[index] - '0';
            }

            if (expression[index] == 't')
            {
                return ParseExpression(expression, index + 2);
            }

            int foundConditions = 0;

            for (int i = index + 2; i < expression.Length; i++)
            {
                var currentSymbol = expression[i];

                if (currentSymbol == '?')
                {
                    foundConditions++;
                }
                else if (currentSymbol == ':')
                {
                    foundConditions--;

                    if (foundConditions < 0)
                    {
                        return ParseExpression(expression, i + 1);
                    }
                }
            }

            return -1;
        }
    }
}