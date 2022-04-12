using System.ComponentModel.DataAnnotations;

namespace LongestIncreasingSubsequence.Api
{
    public class NumbersModel
    {
        [RegularExpression(@"^(\d+( \d+)+)", ErrorMessage = "Please enter numbers separated by single whitespace in the middle.")]
        public string Numbers { get; set; }
    }
}
