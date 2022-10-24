using System.Text.RegularExpressions;

namespace String_Calculator2 {
    public class StringCalculator {
        public int Add(string numbers) {

            //return 0 if empty
            if (string.IsNullOrEmpty(numbers)) {
                return 0;
            }

            //split into array of 2 to capture delimiter line only
            string[] strArray = numbers.Split("\n");

            //initial delimiter, used if no custom delimiter is set
            List<string> delimArray = new List<string> {","};
            
            //If input has a custom delimiter
            if (numbers.StartsWith("//[")) {

                //split multiple delimiters into array
                //order by longest delimiter so it doesn't find a shorter version
                //e.g finding "limit" within "delimiter" 
                delimArray = Regex.Matches(strArray[0], @"\[(.+?)\]")
                    .Select(r => r.Groups[1].Value)
                    .OrderByDescending(s => s.Length)
                    .ToList();

                strArray = strArray.Skip(1).ToArray();
            }

            //split by multiple in each number array
            var result = strArray
                .SelectMany(s => s.Split(delimArray.ToArray(), StringSplitOptions.None)
                .Select(s => CheckForDisallowedInput(s, delimArray)))
                .Where(s => s <= 1000)
                .Sum();

                return result;
        }

        //return exception if a negative number is added
        //retun exception if value is blank
        private int CheckForDisallowedInput(string input, List<string> delimArray) {
            if (delimArray.Contains(input)){
                throw new ArgumentException("Delimiter stealing input number");
            }
            if (int.TryParse(input, out int result)) {

                if (result < 0) {
                    throw new ArgumentException("Negatives Not Allowed");
                }
                return result;
            }

            throw new ArgumentException("Invalid input");
        }
    }
}

