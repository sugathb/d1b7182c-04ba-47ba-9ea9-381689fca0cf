using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace LongestIncreasingSubsequence.ApplicationServices
{
    public class CalculateLongestIncreasingSubsequenceCommand : IRequest<string>
    {
        public CalculateLongestIncreasingSubsequenceCommand(IEnumerable<int> numbers)
        {
            Numbers = numbers;
        }

        public IEnumerable<int> Numbers { get; }
    }

    public class CalculateLongestIncreasingSubsequenceCommandHandler : IRequestHandler<CalculateLongestIncreasingSubsequenceCommand, string>
    {
        public Task<string> Handle(CalculateLongestIncreasingSubsequenceCommand request, CancellationToken cancellationToken)
        {
            var longestSequence = CalculateLongestIncreasingSubsequence(request.Numbers);
            return Task.FromResult(string.Join(" ", longestSequence));
        }

        private static IEnumerable<int> CalculateLongestIncreasingSubsequence(IEnumerable<int> numbers)
        {
            var currentSequence = new List<int>();
            var longestSequence = new List<int>();
            var currentSequenceNumber = 0;
            var longestSequenceNumber = 0;
            var previousNumber = int.MinValue;

            foreach (var number in numbers)
            {
                if (number > previousNumber)
                {
                    currentSequence.Add(number);
                    currentSequenceNumber += 1;
                    previousNumber = number;
                }
                else
                {
                    if (currentSequenceNumber > longestSequenceNumber)
                    {
                        longestSequenceNumber = currentSequenceNumber;
                        longestSequence.Clear();
                        longestSequence.AddRange(currentSequence);

                    }

                    currentSequenceNumber = 1;
                    currentSequence.Clear();
                    currentSequence.Add(number);
                    previousNumber = number;
                }
            }

            //Include last number for the calculation
            return currentSequenceNumber > longestSequenceNumber ? currentSequence : longestSequence;
        }
    }
}
