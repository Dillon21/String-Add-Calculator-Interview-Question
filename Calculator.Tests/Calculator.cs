using NUnit.Framework;
using String_Calculator2;

namespace Calculator.Tests {
    [TestFixture]
    public class Calculator {

        private StringCalculator sut;

        [SetUp] public void SetUp() {
            sut = new StringCalculator();
        }

        [Test]
        public void Add_WhenEmtpyString_ReturnsZero() {

            //Act
            var result = sut.Add("");

            //Assert
            Assert.That(result, Is.Zero);

        }

        [TestCase("1", 1)]
        [TestCase("5", 5)]
        [TestCase("1000", 1000)]
        public void Add_WhenSingleNumber_ReturnsValueOfSingelNumber(string input, int expectedResult) {

            //Act
            var result = sut.Add(input);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));

        }

        [TestCase("1,2", 3)]
        [TestCase("5,10", 15)]
        [TestCase("100,50", 150)]
        [TestCase("10,5", 15)]
        public void Add_WhenTwoNumbers_ReturnsSumOfSuppliedNumbers(string input, int expectedResult) {
 
            var result = sut.Add(input);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));

        }

        [TestCase("1,2,3", 6)]
        [TestCase("5,10,15", 30)]
        [TestCase("100,50,23,23", 196)]
        [TestCase("10,5,23", 38)]
        public void Add_WhenInputHasMoreThanTwoNumbers_ReturnsSumOfSuppliedNumbers(string input, int expectedResult) {

            var result = sut.Add(input);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));

        }

        [TestCase("1\n2,4", 7)]
        [TestCase("1\n15,15", 31)]

        public void Add_WhenInputContainsNewLineAtStart_ReturnSumOfSuppliedNumbers(string input, int expectedResult) {

            var result = sut.Add(input);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));

        }

        [TestCase("1,2,\n", 6)]
        [TestCase("5,\n,15", 30)]
        public void Add_WhenInputContainsNewLineInsteadOfNumbers_ReturnsException(string input, int expectedResult) {

            //Assert
            Assert.Throws<ArgumentException>(() => sut.Add(input));

        }

        [TestCase("//;\n1;2", 3)]
        [TestCase("//;\n3;3", 6)]
        [TestCase("//foo\n1foo2", 3)]

        public void Add_WithWordsInInput(string input, int expectedResult) {

            var result = sut.Add(input);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));

        }

        [TestCase("-5,10,15", 30)]
        [TestCase("100,50,23,-23", 173)]
        [TestCase("-10,5,23", 18)]
        public void Add_WithNegativeNumbers_ReturnException(string input, int expectedResult) {

            //Assert
            Assert.Throws<ArgumentException>(() => sut.Add(input));
        }

        [TestCase("1001,10,15", 25)]
        public void Add_WithNumbersOverOneThousand_ReturnSumOfNumbers(string input, int expectedResult) {

            var result = sut.Add(input);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
