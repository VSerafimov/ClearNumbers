using System.Collections.Generic;

namespace NumbersLibrary
{
    public class NumbersGenerator
    {
        public int StartingNumber { get; set; }
        public int EndingNumber { get; set; }
        private List<DivisibleNumberActionParameter> divisibleNumberActionParameters = new List<DivisibleNumberActionParameter>();

        public NumbersGenerator(int startingNumber, int endingNumber)
        {
            if (startingNumber <= endingNumber)
            {
                StartingNumber = startingNumber;
                EndingNumber = endingNumber;
            }
            else
            {
                StartingNumber = endingNumber;
                EndingNumber = startingNumber;
            }
        }

        public IEnumerable<Number> Generate()
        {
            var numbersToReturn = new List<Number>();

            for (int i = StartingNumber; i <= EndingNumber; i++)
            {
                var lineToPrint = i.ToString();

                foreach (var divisibleNumberActionParameter in divisibleNumberActionParameters)
                {
                    if (i % divisibleNumberActionParameter.DivisibleBy == 0)
                    {
                        lineToPrint += " " + divisibleNumberActionParameter.ValueResponse;
                    }
                }

                numbersToReturn.Add(new Number() { Id = i, Value = lineToPrint });
            }

            return numbersToReturn;
        }

        public void AddDivisibleParameter(int divisibleBy, string valueResponse)
        {
            divisibleNumberActionParameters.Add(new DivisibleNumberActionParameter() { DivisibleBy = divisibleBy, ValueResponse = valueResponse });
        }
    }
}
