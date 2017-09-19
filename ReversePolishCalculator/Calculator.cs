using System;
using System.Linq;

namespace ReversePolishCalculator
{
    public interface ICalculator
    {
        int Calculate(string input);
    }

    public class Calculator: ICalculator
    {
        public int Calculate(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException();
            }
            var parts = input
                           .Split(new[] { " " }, StringSplitOptions.None)
                           .Select(int.Parse)
                           .ToArray();
            if (parts.Length != 2)
            {
                throw new ArgumentException();
            }
            return parts.Sum();
        }
    }
}
