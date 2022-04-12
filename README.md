## Longest Increasing Subsequence
To calculate the longest increasing subsequence of a given string input of any number of integers separated by single whitespace.

### Function

```CSharp
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
  ```

### Consume API
The API is hosted as an `Azure App Service Container` which can be consumed via,

https://longest-increasing-sequence.azurewebsites.net/swagger/index.html

### API Endpoint
		
		URL: https://longest-increasing-sequence.azurewebsites.net/api/LongestIncreasingSubsequence/calculate
		Method: Post
            Body: { "numbers": "6 1 5 9 2" }
          
### Design & Architecture
The API is developed as an `ASP.NET Core WebAPI` that targets to .NET 5.0 with Docker support enabled.

### Unit Tests
`Nunit` is used to write unit tests. The tests covers all 11 test cases given in the coding challenge. 

### Validations
A regular expression is used to validate the input  number of integers separated by single whitespace.

```CSharp
public class NumbersModel
    {
        [RegularExpression(@"^(\d+( \d+)+)", ErrorMessage = "Please enter numbers separated by single whitespace in the middle.")]
        public string Numbers { get; set; }
    }
  ```

### Continuous Integration
`Githib Actions` used for continuous integration. Each time a new code is commited to `master` branch, it will build the code and run all unit tests in the solution.

### Continuous Deployment
Each time a new code is commited/merged into the `master` branch, the deployment pipelines will be triggered. Docker container to the `Azure Container Registry` and then deployed to `Azure App Service Container`. 

