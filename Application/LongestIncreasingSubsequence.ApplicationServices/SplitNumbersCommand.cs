using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace LongestIncreasingSubsequence.ApplicationServices
{
    public class SplitNumbersCommand : IRequest<IEnumerable<int>>
    {
        public SplitNumbersCommand(string numbers)
        {
            Numbers = numbers;
        }

        public string Numbers { get; }

    }

    public class SplitNumbersCommandHandler : IRequestHandler<SplitNumbersCommand, IEnumerable<int>>
    {
        public Task<IEnumerable<int>> Handle(SplitNumbersCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(request.Numbers.Split(" ").Select(int.Parse));
        }
    }
}
