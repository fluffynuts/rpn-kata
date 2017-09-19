using System;
using NUnit;
using NExpect;
using NUnit.Framework;
using static NExpect.Expectations;

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

        private static ICalculator Create()
        {
            return new Calculator();
        }
    }
}