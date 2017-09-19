using System;
using NExpect;
using NUnit.Framework;
using static NExpect.Expectations;
using static PeanutButter.RandomGenerators.RandomValueGen;

namespace ReversePolishCalculator.Tests
{
    [TestFixture]
    public class TestCalculator
    {
        [TestFixture]
        public class InvalidInputShouldThrowArgumentExceptions
        {
            [Test]
            public void GivenEmptyString_ShouldThrow_ArgumentException()
            {
                // Arrange
                var input = "";
                var sut = Create();
                // Pre-Assert
                // Act
                Expect(() => sut.Calculate(input))
                    .To.Throw<ArgumentException>();
                // Assert
            }

            [Test]
            public void GivenOnlyOneInteger()
            {
                // Arrange
                var input = "1";
                var sut = Create();
                // Pre-Assert
                // Act
                Expect(() => sut.Calculate(input))
                    .To.Throw<ArgumentException>();
                // Assert
            }

            [Test]
            public void GivenNull()
            {
                // Arrange
                var sut = Create();
                // Pre-Assert
                // Act
                Expect(() => sut.Calculate(null))
                    .To.Throw<ArgumentException>();
                // Assert
            }
        }

        [TestFixture]
        public class CalculatingSumOfTwoIntegers
        {
            [Test]
            public void GivenTwoSingleDigitIntegers_ShouldCalculateSum()
            {
                // Arrange
                var input = "1 2";
                var sut = Create();
                // Pre-Assert
                // Act
                var result = sut.Calculate(input);
                // Assert
                Expect(result).To.Equal(3);
            }

            [Test]
            public void GivenTwoArbitraryIntegers_ShouldCalculateSum()
            {
                // Arrange
                var first = GetRandomInt();
                var second = GetAnother(first);
                var input = $"{first} {second}";
                var expected = first + second;
                var sut = Create();
                // Pre-Assert
                // Act
                var result = sut.Calculate(input);
                // Assert
                Expect(result).To.Equal(expected);
            }
        }

        [TestFixture]
        public class ResultShouldFitWithinDisplayLimits
        {
            [Test]
            public void WhenResultIsPositive_And9CharactersLong_ShouldThrow_InvalidOperationException()
            {
                // Arrange
                var first = 99_999_999;
                var second = 1;
                var input = $"{first} {second}";
                var sut = Create();
                // Pre-Assert
                Expect((first + second).ToString().Length).To.Equal(9);
                // Act
                Expect(() => sut.Calculate(input))
                    .To.Throw<InvalidOperationException>()
                    .With.Message.Containing("may not exceed 8 characters");
                // Assert
            }
        }

        private static ICalculator Create()
        {
            return new Calculator();
        }
    }
}