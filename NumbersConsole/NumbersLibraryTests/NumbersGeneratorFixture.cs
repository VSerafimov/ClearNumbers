using System.Linq;
using NumbersLibrary;
using NUnit.Framework;

namespace NumbersLibraryTests
{
    public class NumbersGeneratorFixture
    {
        private NumbersGenerator numbersGenerator;

        [SetUp]
        public void Before_each_test()
        {
            numbersGenerator = null;
        }

        [Test]
        public void Should_generate_100_numbers_from_101_to_200()
        {
            const int startingNumber = 101;
            const int endingNumber = 200;
            const int numberOfResultsThatShouldBeGenerated = 100;

            numbersGenerator = new NumbersGenerator(startingNumber, endingNumber);

            var results = numbersGenerator.Generate().ToArray();

            Assert.That(results.Count(), Is.EqualTo(numberOfResultsThatShouldBeGenerated));
            Assert.That(results.First().Id, Is.EqualTo(startingNumber));
            Assert.That(results.Last().Id, Is.EqualTo(endingNumber));
        }

        [Test]
        public void Should_generate_numbers_from_1_to_50_even_if_the_ending_number_is_less_than_the_starting()
        {
            const int startingNumber = 1;
            const int endingNumber = 50;
            const int numberOfResultsThatShouldBeGenerated = 50;

            numbersGenerator = new NumbersGenerator(endingNumber, startingNumber);

            var results = numbersGenerator.Generate().ToArray();

            Assert.That(results.Count(), Is.EqualTo(numberOfResultsThatShouldBeGenerated));
            Assert.That(results.First().Id, Is.EqualTo(startingNumber));
            Assert.That(results.Last().Id, Is.EqualTo(endingNumber));
        }

        [Test]
        public void Should_generate_1000_numbers_and_set_fizz_for_mod_of_3_and_buzz_for_mod_of_5()
        {
            const string fizzValue = "fizz";
            const string buzzValue = "buzz";
            const int numberOfOccurancesOfMod3In1000 = 333;
            const int numberOfOccurancesOfMod5In1000 = 200;
            const int numberOfOccurancesOfMod3And5In1000 = 66;
            const int startingNumber = 1;
            const int endingNumber = 1000;

            numbersGenerator = new NumbersGenerator(startingNumber, endingNumber);

            numbersGenerator.AddDivisibleParameter(3, fizzValue);
            numbersGenerator.AddDivisibleParameter(5, buzzValue);

            var results = numbersGenerator.Generate().ToArray();

            Assert.That(results.Count(), Is.EqualTo(1000));
            Assert.That(results.Count(x => x.Value.Contains(fizzValue)), Is.EqualTo(numberOfOccurancesOfMod3In1000));
            Assert.That(results.Count(x => x.Value.Contains(buzzValue)), Is.EqualTo(numberOfOccurancesOfMod5In1000));
            Assert.That(results.Count(x => x.Value.Contains(fizzValue) &&
                                           x.Value.Contains(buzzValue)
                                     ), Is.EqualTo(numberOfOccurancesOfMod3And5In1000));
        }

        [Test]
        public void Should_generate_500_numbers_and_set_green_for_mod_of_7_and_yellow_for_mod_of_11_and_red_for_mod_of_13()
        {
            const string greenValue = "green";
            const string yellowValue = "yellow";
            const string redValue = "red";
            const int numberOfOccurancesOfMod7In500 = 71;
            const int numberOfOccurancesOfMod11In500 = 45;
            const int numberOfOccurancesOfMod13In500 = 38;
            const int numberOfOccurancesOfMod7And11In500 = 6;
            const int numberOfOccurancesOfMod7And13In500 = 5;
            const int numberOfOccurancesOfMod11And13In500 = 3;
            const int numberOfOccurancesOfMod7And11And13In500 = 0;
            const int startingNumber = 501;
            const int endingNumber = 1000;

            numbersGenerator = new NumbersGenerator(startingNumber, endingNumber);

            numbersGenerator.AddDivisibleParameter(7, greenValue);
            numbersGenerator.AddDivisibleParameter(11, yellowValue);
            numbersGenerator.AddDivisibleParameter(13, redValue);

            var results = numbersGenerator.Generate().ToArray();

            Assert.That(results.Count(), Is.EqualTo(500));
            Assert.That(results.Count(x => x.Value.Contains(greenValue)), Is.EqualTo(numberOfOccurancesOfMod7In500));
            Assert.That(results.Count(x => x.Value.Contains(yellowValue)), Is.EqualTo(numberOfOccurancesOfMod11In500));
            Assert.That(results.Count(x => x.Value.Contains(redValue)), Is.EqualTo(numberOfOccurancesOfMod13In500));

            Assert.That(results.Count(x => x.Value.Contains(greenValue) &&
                                           x.Value.Contains(yellowValue)
                                     ), Is.EqualTo(numberOfOccurancesOfMod7And11In500));

            Assert.That(results.Count(x => x.Value.Contains(greenValue) &&
                                           x.Value.Contains(redValue)
                                     ), Is.EqualTo(numberOfOccurancesOfMod7And13In500));

            Assert.That(results.Count(x => x.Value.Contains(yellowValue) &&
                                           x.Value.Contains(redValue)
                                     ), Is.EqualTo(numberOfOccurancesOfMod11And13In500));


            Assert.That(results.Count(x => x.Value.Contains(greenValue) &&
                                           x.Value.Contains(yellowValue) &&
                                           x.Value.Contains(redValue)
                                     ), Is.EqualTo(numberOfOccurancesOfMod7And11And13In500));
        }
    }
}
