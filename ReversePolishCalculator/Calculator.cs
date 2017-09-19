using System;

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
            throw new NotImplementedException();
        }
    }
}
