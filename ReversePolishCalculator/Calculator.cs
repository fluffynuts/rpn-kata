using System;
using System.Collections.Generic;
using System.Linq;

namespace ReversePolishCalculator
{
    public interface ICalculator
    {
        int Calculate(string input);
    }

    public class Calculator : ICalculator
    {
        public int Calculate(string input)
        {
            var parts = input
                .EmptyIfNull()
                .Split(new[] {" "}, StringSplitOptions.None)
                .ToInts();
            return parts
                     .Sum()
                     .ValidateDoesNotExceedDisplayConstraints();
        }
    }

    internal static class Extensions
    {
        internal static int ValidateDoesNotExceedDisplayConstraints(this int value)
        {
            return value.ToString().Length > 8
                    ? throw new InvalidOperationException("Calculation output may not exceed 8 characters")
                    : value;
        }

        internal static string EmptyIfNull(this string str)
        {
            return str ?? "";
        }

        internal static int[] ToInts(this string[] strings)
        {
            return strings
                .TryConvertToInts()
                .ValidateHaveTwoInts();
        }

        internal static IEnumerable<int> TryConvertToInts(this string[] strings)
        {
            return strings.Select(s =>
                int.TryParse(s, out var result)
                    ? result
                    : throw new ArgumentException());
        }

        internal static int[] ValidateHaveTwoInts(this IEnumerable<int> ints)
        {
            var result = ints.ToArray();
            return result.Length == 2
                ? result
                : throw new ArgumentException();
        }
    }
}