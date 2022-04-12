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
            throw new System.NotImplementedException();
        }
    }
}
